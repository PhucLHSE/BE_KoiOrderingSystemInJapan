using KoiOrderingSystemInJapan.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using KoiOrderingSystemInJapan.Service.Interfaces;
using KoiOrderingSystemInJapan.Service.Services;
namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class UserRegistrationDto
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(200)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(200)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(200)]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(200)]
        public string UserName { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        [StringLength(300)]
        public string Address { get; set; }

        [Required(ErrorMessage = "IsActive status is required")]
        public bool IsActive { get; set; } = true; // Default to active

        [Required(ErrorMessage = "IsVerified status is required")]
        public bool IsVerified { get; set; } = false; // Default to not verified
    }

    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
    }

    public class ResetPasswordRequest
    {
        [Required(ErrorMessage = "Token is required")]
        public string Token { get; set; }

        [Required(ErrorMessage = "New password is required")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }


    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IEmailService _emailService;

        public AuthenticationController(IAuthenticationService authService, IEmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = _authService.Authenticate(loginDto.Email, loginDto.Password, out var user);

            if (user == null)
                return BadRequest("Invalid email or password.");

            return Ok(new { Token = token, User = user });
        }

        [HttpPost("Register")]
public async Task<IActionResult> Register([FromBody] UserRegistrationDto registrationDto)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    try
    {
        var newUser = new User
        {
            Email = registrationDto.Email,
            Password = registrationDto.Password,
            FullName = registrationDto.FullName,
            UserName = registrationDto.UserName,
            PhoneNumber = registrationDto.PhoneNumber,
            BirthDate = registrationDto.BirthDate,
            Address = registrationDto.Address,
            IsActive = registrationDto.IsActive,
            IsVerified = registrationDto.IsVerified,
            RoleId = 2
            
        };

        var registeredUserResult = await _authService.RegisterAsync(newUser);
        if (registeredUserResult == null)
            return BadRequest("Registration failed.");

        var token = _authService.Authenticate(newUser.Email, registrationDto.Password, out var user);

        return Ok(new { Message = "User registered successfully", Token = token, User = registeredUserResult });
    }
    catch (InvalidOperationException ex)
    {
        return BadRequest(new { Message = ex.Message });
    }
    catch (Exception ex)
    {
                var detailedError = ex.InnerException?.Message ?? ex.Message;
                return StatusCode(500, new { Message = $"An unexpected error occurred: {detailedError}" });
            }
}

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var result = await _authService.ForgotPasswordAsync(request.Email);
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _authService.ResetPasswordAsync(request.Token, request.NewPassword);
            return Ok(result);
        }

    }
}
