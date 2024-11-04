using KoiOrderingSystemInJapan.Common;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Data.Repository;
using KoiOrderingSystemInJapan.Service.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KoiOrderingSystemInJapan.Service
{
    public interface IAuthenticationService
    {
        string Authenticate(string email, string password, out User user);
        Task<IServiceResult> RegisterAsync(User user);
        Task<IServiceResult> ForgotPasswordAsync(string email);
        Task<IServiceResult> ResetPasswordAsync(string token, string newPassword);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AuthenticationService(UnitOfWork unitOfWork, IConfiguration configuration, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _emailService = emailService;
        }

        public string Authenticate(string email, string password, out User user)
        {
            user = _unitOfWork.AuthenticationRepository.GetUserByEmail(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password)) return null;

            var role = _unitOfWork.AuthenticationRepository.GetUserRoleById(user.RoleId);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("UserId", user.UserId.ToString()),
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.Role, role.RoleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IServiceResult> RegisterAsync(User user)
        {
            if (user == null) throw new Exception("User data cannot be null.");

            var existingUser = _unitOfWork.AuthenticationRepository.GetUserByEmail(user.Email);
            if (existingUser != null)
                throw new Exception("User with this email already exists.");

            user.UserId = 0;
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            await _unitOfWork.AuthenticationRepository.AddUserAsync(user);
            await _unitOfWork.AuthenticationRepository.CommitAsync();

            return new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, user);
        }

        public async Task<IServiceResult> ForgotPasswordAsync(string email)
        {
            var user = _unitOfWork.AuthenticationRepository.GetUserByEmail(email);
            if (user == null)
                return new ServiceResult(Const.FAIL_CREATE_CODE, "User with this email does not exist.");

            var claims = new[]
            {
                new Claim("UserId", user.UserId.ToString()),
                new Claim("Email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: signIn
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var resetLink = $"https://yourwebsite.com/reset-password?token={tokenString}";
            var emailMessage = $"<p>Please reset your password by clicking <a href='{resetLink}'>here</a>.</p>";
            await _emailService.SendEmailAsync(email, "Password Reset Request", emailMessage);

            return new ServiceResult(Const.SUCCESS_CREATE_CODE, "Reset link sent to your email.");
        }

        public async Task<IServiceResult> ResetPasswordAsync(string token, string newPassword)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = _configuration["Jwt:Issuer"],
                ValidAudience = _configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                var userIdClaim = principal.FindFirst("UserId")?.Value;
                if (userIdClaim == null) throw new SecurityTokenException("Invalid token.");

                var user = _unitOfWork.AuthenticationRepository.GetUserById(int.Parse(userIdClaim));
                if (user == null) throw new Exception("User does not exist.");

                user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
                _unitOfWork.AuthenticationRepository.UpdateUser(user);
                await _unitOfWork.AuthenticationRepository.CommitAsync();

                return new ServiceResult(Const.SUCCESS_CREATE_CODE, "Password reset successfully.");
            }
            catch (SecurityTokenException)
            {
                return new ServiceResult(Const.FAIL_CREATE_CODE, "Invalid or expired token.");
            }
        }
    }
}
