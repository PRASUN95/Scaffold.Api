using Microsoft.AspNetCore.Mvc;
using Scaffold.Api.Core.Services.Interface;
using Scaffold.Api.Dtos;

namespace Scaffold.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(ITokenService tokenService) : ControllerBase
    {
        private readonly ITokenService _tokenService = tokenService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto request)
        {
            if (request.Email == "user@example.com" && request.Password == "password123")
            {
                var token = _tokenService.GenerateToken("user-123", request.Email);
                return Ok(new { token });
            }

            return Unauthorized("Invalid credentials");
        }
    }
}
