using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly RegisterUserHandler _registerUserHandler;

        // DI resolves the handler, which in turn resolves the IUserRepository implementation
        public UsersController(RegisterUserHandler registerUserHandler)
        {
            _registerUserHandler = registerUserHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest command)
        {
            try
            {
                await _registerUserHandler.Handle(command);
                return Ok("User registered successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // Handles business rule violations
            }
        }
    }
}
