using Scaffold.Api.Core.Services.Extensions;


namespace Scaffold.Api.Extensions
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddBearerAuthentication(builder.Configuration);
            builder.Services.AddOptions(builder.Configuration);
            builder.Services.AddCoreServices();
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            return builder.Build();
        }
    }
}
