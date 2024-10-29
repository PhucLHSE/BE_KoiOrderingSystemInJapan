﻿using KoiOrderingSystemInJapan.Data;
using KoiOrderingSystemInJapan.Data.DBContext;
using KoiOrderingSystemInJapan.Data.Models;
using KoiOrderingSystemInJapan.Data.Repository;
using KoiOrderingSystemInJapan.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KoiOrderingSystemInJapan.APIService.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        private readonly KoiOrderingSystemInJapanContext _context;

        public AuthenticationController(IAuthenticationService authService, KoiOrderingSystemInJapanContext context)
        {
            _authService = authService;
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserLoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var token = _authService.Authenticate(loginDto.Email, loginDto.Password, out var user);

            if (user == null)
                return BadRequest("Invalid email or password.");

            return Ok(new { Token = token, User = user });
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (user == null)
            {
                return BadRequest("User data cannot be null.");
            }

            try
            {
                var registeredUser = await _authService.RegisterAsync(user);
                return Ok(new { Message = "User registered successfully", User = registeredUser });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"An unexpected error occurred: {ex.Message}" });
            }
        }
    }
}
