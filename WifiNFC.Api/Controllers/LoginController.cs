using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Wifi.Infrastructure.Exceptions;
using Wifi.Infrastructure.Repository;
using WifiNFC.Api.TokenCreator;

namespace WifiNFC.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepos;
        private readonly ITokenCreator token;

        public LoginController(IEmployeeRepository employeeRepos,
            ITokenCreator token)
        {
            this.employeeRepos = employeeRepos;
            this.token = token;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Login([FromHeader]string email, [FromHeader] string pwd)
        {
            var result = await employeeRepos
                .CheckCredentialsAndGetUser(email, pwd);

            if (result is null)
                throw new InvalidCredentialsException();

            var jwt = token.GetToken(new Claim(ClaimTypes.Name, result.Id.ToString()));

            return Ok(jwt);
        }
    }
}