
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WifiNFC.Api.TokenCreator
{
    public class TokenCreator : ITokenCreator
    {
        private readonly IConfiguration configuration;
        string issuer = default!;
        string audience = default!;
        byte[] key = default!;

        public TokenCreator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GetToken(params Claim[] claims)
        {
            FillSecretsAndCheck();
            SecurityTokenDescriptor descriptor = GetDescriptor(claims);
            JwtSecurityTokenHandler handler = new();
            var tokencreate = handler.CreateToken(descriptor);
            return handler.WriteToken(tokencreate);
        }

        SecurityTokenDescriptor GetDescriptor(Claim[] claims)
        {
            return new()
            {
                Subject = new ClaimsIdentity(claims) ?? default!,
                Issuer = issuer,
                Audience = audience,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = GetHashedKey()
            };
        }

        SigningCredentials GetHashedKey()
        {
            return new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature);
        }

        void FillSecretsAndCheck()
        {

             issuer = configuration["JWT:Issuer"];
             audience = configuration["JWT:Audience"];
             key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            if (issuer is null || audience is null || key is null)
            {
                throw new Exception();
            }
        }
    }
}
