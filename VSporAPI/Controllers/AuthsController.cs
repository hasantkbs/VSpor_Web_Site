using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VSpor.Auths;
using VSpor.Auths.Extensions;
using VSpor.Auths.Security.Jwt;
using VSpor.Auths.User;
using VSpor.IoC;
using VSporCore.DataAccess.Dapper;
using VSporCore.Extensions;
using VSporCore.Toolkit.Results;
using System.Data;
using System.DirectoryServices;
using System.Security.Claims;
using IResult = VSporCore.Toolkit.Results.IResult;

namespace VSpor.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AuthsController : ControllerBase
    {
        private readonly IDbConnection _dbConnection;
        private IConfiguration _configuration;
        
        public AuthsController(IDbConnection dbConnection, IConfiguration configuration)
        {
            _dbConnection = dbConnection;
            _configuration= configuration;
        }

        [Consumes("application/x-www-form-urlencoded")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<Account>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResult))]
        [HttpGet("/auths/account")]
        public async Task<IActionResult> Account()
        {
            var httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            var claimpPrincipal = httpContextAccessor?.HttpContext?.User;
            var roleClaims = httpContextAccessor?.HttpContext?.User.ClaimRoles();
            int.TryParse(claimpPrincipal?.ClaimValue(ClaimTypes.NameIdentifier), out var id);
            if (id < 1)
            {
                return NotFound(UserMessages.AuthorizationDenied);
            }
            return Ok();
        }

        [Consumes("application/x-www-form-urlencoded")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IDataResult<Token>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(IResult))]
        [HttpPost("/auths/token")]
        public async Task<IActionResult> Token([FromForm] LoginRequest loginRequest)
        {
            //kullanıcı kontrolü sonrası OK

            //var accessToken = new JwtHelper(_configuration).CreateToken(getUser);
            //return Ok(accessToken);

            return Ok();
           
        }
        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
