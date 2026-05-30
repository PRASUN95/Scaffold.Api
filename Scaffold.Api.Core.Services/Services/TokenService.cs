using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Scaffold.Api.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Scaffold.Api.Core.Services.Services
{
    public class TokenService: ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(string userId, string email)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var secret = jwtSettings["secret"];
            var issuer = jwtSettings["issuer"];
            var scope = jwtSettings["scope"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Email, email),
            new Claim("scope", scope)
        };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: scope,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
