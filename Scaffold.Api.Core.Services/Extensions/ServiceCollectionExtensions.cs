using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scaffold.Api.Core.Services.Interface;
using Scaffold.Api.Core.Services.Services;
using System.Text;

namespace Scaffold.Api.Core.Services.Extensions
{
    public static class ServiceCollectionExtensionss
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }

        public static IServiceCollection AddBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Jwt");
            var secret = jwtSettings["secret"];
            var issuer = jwtSettings["issuer"];
            var scope = jwtSettings["scope"];

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = scope,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret))
                };
            });

            return services;
        }
    }
}
