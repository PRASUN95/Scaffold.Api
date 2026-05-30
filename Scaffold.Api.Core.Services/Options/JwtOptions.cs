namespace Scaffold.Api.Core.Services.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; }
        public string Scope { get; set; }
        public string Secret { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
