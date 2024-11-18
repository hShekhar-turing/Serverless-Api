using Microsoft.AspNetCore.Mvc;

namespace UserAuthApi
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var token = _userService.AuthenticateUser(model.Username, model.Password);

            if (token != null)
            {
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class AuthenticateModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
