using Application.Ports.Input;
using Application.UseCases.Users.RegisterUser;
using Microsoft.AspNetCore.Mvc;
using WebApi.Requests;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;

        // DI resolves the handler, which in turn resolves the IUserRepository implementation
        public UsersController(IRegisterUserUseCase registerUserUseCase)
        {
            _registerUserUseCase = registerUserUseCase;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest command)
        {
            await _registerUserUseCase.ExecuteAsync(command.ToCommand());
            return Ok("User registered successfully.");
        }
    }
}
