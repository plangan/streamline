using Authentication.API.Infrastructure.Filters;
using Authentication.API.Models;
using Authentication.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Authentication.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(Models.SecurityToken), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Authenticate([FromBody] Login loginParam)
        {
            var securityToken = await _userService.Authenticate(loginParam.Username, loginParam.Password);

            if (securityToken == null)
            {
                var json = new JsonErrorResponse
                {
                    Messages = new string[] { "Username or password is incorrect" }
                };
                return new BadRequestObjectResult(json);
            }

            return Ok(securityToken);
        }

        [AllowAnonymous]
        [HttpPost("authenticatepatient")]
        [ProducesResponseType(typeof(Models.SecurityToken), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AuthenticatePatient([FromBody] Login loginParam)
        {
            var securityToken = await _userService.AuthenticatePatient(loginParam.Username, loginParam.Password);

            if (securityToken == null)
            {
                var json = new JsonErrorResponse
                {
                    Messages = new string[] { "Username or password is incorrect" }
                };
                return new BadRequestObjectResult(json);
            }

            return Ok(securityToken);
        }
    }
}