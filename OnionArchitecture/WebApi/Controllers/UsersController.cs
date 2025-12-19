using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTOs;
using WebApi.Requests;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        // DI resolves the handler, which in turn resolves the IUserRepository implementation
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest command)
        {
            await _userService.RegisterUserAsync(command.ToCommand());
            return Ok("User registered successfully.");
        }
    }
}
