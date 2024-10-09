using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using KoiOrderingSystemInJapan.Service.Base;
using KoiOrderingSystemInJapan.Common;

namespace KoiOrderingSystemInJapan.Service
{
    public interface IAuthenticationService
    {string Authenticate(string email, string password, out User user);
        Task<IServiceResult> RegisterAsync(User user);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly KoiOrderingSystemInJapanContext _context;
        private readonly IConfiguration _configuration;
        private readonly UnitOfWork _unitOfWork;

        public AuthenticationService(KoiOrderingSystemInJapanContext context, IConfiguration configuration, UnitOfWork unitOfWork)
        {
            _context = context;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public string Authenticate(string email, string password, out User user)
        {
            user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);

            if (user == null)
                return null;

            var role = _unitOfWork.RoleRepository.GetById(user.RoleId);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("UserId", user.UserId.ToString()),
            new Claim("Email", user.Email.ToString()),
            new Claim(ClaimTypes.Role, role.RoleName.ToString())
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
            if (user == null)
                throw new Exception("User data cannot be null.");

            try
            {
                var existingUser = _context.Users.FirstOrDefault(x => x.Email == user.Email);
                if (existingUser != null)
                {
                    throw new Exception("User with this email already exists.");
                }

                // Ensure that UserId is not set manually
                user.UserId = 0;  // This will ensure the database auto-generates the value

                // Hash the password before storing it
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = hashedPassword;

                _context.Users.Add(user);  // Add user entity to context
                _context.SaveChanges();    // Save changes to database

                return  new ServiceResult(Const.SUCCESS_CREATE_CODE, Const.SUCCESS_CREATE_MSG, user);
            }
            catch (DbUpdateException dbEx)
            {
                // Handle database-specific exceptions
                throw new InvalidOperationException($"Database error: {dbEx.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                // Handle any general exceptions
                throw new Exception($"An error occurred while registering the user: {ex.Message}");
            }
        }
    }

}
