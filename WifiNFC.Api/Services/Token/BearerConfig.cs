using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WifiNFC.Api.Services.Token
{
    internal static class BearerConfig
    {
        public static void AddBearerConfig(IServiceCollection service, IConfiguration configuration)
        {
            service.AddAuthorization();
            service.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["JWT:Audience"],
                    ValidateLifetime = true,
                    LifetimeValidator = LifetimeValidation,
                    IssuerSigningKey = GetSigningKey(configuration)


                };
            });
        }

        static SymmetricSecurityKey GetSigningKey(IConfiguration config)
        {
            return new(Encoding.UTF8.GetBytes(
                config["JWT:Key"]!));
        }

        static bool LifetimeValidation(DateTime? notBefore, DateTime? expires,
            SecurityToken securityToken, TokenValidationParameters tokenValidationParameters)
        {
            return (expires is not null && expires > DateTime.UtcNow);
        }
    }
}
