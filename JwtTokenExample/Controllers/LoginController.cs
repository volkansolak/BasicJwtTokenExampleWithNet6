using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtTokenExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LoginController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] UserLogins user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var token = _tokenService.GetToken(user);
            await Task.CompletedTask;
            return Ok(new
            {
                access_token = token,
                token_type = "Bearer"
            });
        }

        [HttpGet]
        [Route("UserList")]
        public async Task<ActionResult> GetUserList()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            List<string> userList = new List<string>();
            userList.Add("Volkan Solak");
            userList.Add("Hasan Taş");
            userList.Add("Hakan Solak");

            await Task.CompletedTask;
            return Ok(userList);
        }
    }
}
