using KoiOrderingSystemInJapan.Data.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly KoiOrderingSystemInJapanContext koiOrderingSystemInJapanContext;
        public IConfiguration Iconfiguration;
        public AuthenticationController(KoiOrderingSystemInJapanContext koiOrderingSystemInJapanContext, IConfiguration IConfiguration)
        {
            this.koiOrderingSystemInJapanContext = koiOrderingSystemInJapanContext;
            this.Iconfiguration = IConfiguration;
        }
        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(String email, String password)
        {
            var user = koiOrderingSystemInJapanContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                var claims = new[]
                {
        new Claim(JwtRegisteredClaimNames.Sub, Iconfiguration["Jwt:Subject"]),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim("UserId", user.UserId.ToString()),
        new Claim("Email", user.Email.ToString())
    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Iconfiguration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    Iconfiguration["Jwt:Issuer"],
                    Iconfiguration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddHours(2),
                    signingCredentials: signIn
                );

                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = tokenValue, User = user });
                // return Ok(user);
            }
            return NoContent();
        }
    }
}
