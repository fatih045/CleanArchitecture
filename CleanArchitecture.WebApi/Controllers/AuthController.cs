using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {



        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authenticationService.AuthenticateUser(request.Email, request.Password);
            if (token == null)
            {
                return Unauthorized("Geçersiz kullanıcı adı veya şifre.");
            }
            return Ok(new { Token = token });
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            {
                try
                {
                    var registerRequestDto = new RegisterRequestDto
                    {
                        UserName = request.UserName,
                        Email = request.Email,
                        Password = request.Password
                    };

                    var result = await _authenticationService.RegisterAsync(registerRequestDto);

                    return Ok(result); // Successfully registered
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest(ex.Message); // Handle email already in use
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Internal Server Error: " + ex.Message); // Handle other exceptions
                }
            }


        }
        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}

