using Anbunet.Infrastructure.Modules.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Anbunet.API.OptionsSetup;

public class JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions) : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly JwtOptions _jwtOptions = jwtOptions.Value;

    public void Configure(string? name, JwtBearerOptions options)
    {
        var secretKey = Encoding.UTF8.GetBytes(_jwtOptions.SecretKey);

        options.RequireHttpsMetadata = false;

        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(secretKey)
        };
    }

    public void Configure(JwtBearerOptions options) => Configure(null, options);
}
