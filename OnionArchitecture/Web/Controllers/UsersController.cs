using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Requests;

namespace Presentation.Controllers
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
            try
            {
                await _userService.RegisterUserAsync(command);
                return Ok("User registered successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // Handles business rule violations
            }
        }
    }
}
