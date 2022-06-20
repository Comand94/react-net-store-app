using Microsoft.AspNetCore.Mvc;
using react_net_store_core.Services;
using react_net_store_core.Exceptions;
using react_net_store_database.Classes;
using static Google.Apis.Auth.GoogleJsonWebSignature;
using Microsoft.AspNetCore.Authorization;
using react_net_store_core.DTO;

namespace react_net_store_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersServices _userService;

        public UsersController(IUsersServices userService)
        {
            _userService = userService;
        }

        [HttpGet("IsAdmin")]
        public IActionResult GetAdminRights(UserDTO user)
        {
            return Ok(_userService.HasAdminRights(user));
        }

        [HttpPost("Sign-up")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {
            try
            {
                var result = await _userService.SignUp(user);
                return Created("", result);
            }
            catch (UsernameTakenException e)
            {
                return StatusCode(409, e.Message);
            }
        }

        [HttpPost("Sign-in")]
        public async Task<IActionResult> SignIn([FromBody] User user)
        {
            try
            {
                var result = await _userService.SignIn(user);
                return Created("", result);
            }
            catch (InvalidLoginCredentialsException e)
            {
                return StatusCode(401, e.Message);
            }
        }

        [HttpPost("Google")]
        public async Task<ActionResult> Auth([FromQuery] string token)
        {
            var payload = await ValidateAsync(token, new ValidationSettings
            {
                Audience = new[]
               {
                    Environment.GetEnvironmentVariable("CLIENT_ID")
                }
            });

            var result = await _userService.ExternalSignIn(new User
            {
                Email = payload.Email,
                ExternalId = payload.Subject,
                ExternalType = "Google"
            });

            return Created("", result);
        }
    }

}
