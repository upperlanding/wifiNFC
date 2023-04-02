using System.Security.Claims;

namespace WifiNFC.Api.TokenCreator
{
    public interface ITokenCreator
    {
        string GetToken(params Claim[] claims);
    }
}
