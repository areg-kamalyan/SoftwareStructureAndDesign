using Application.DTOs;
using Application.UseCases.Users.RegisterUser;

namespace Application.Ports.Input
{
    public interface IRegisterUserUseCase
    {
        Task<UserDto> ExecuteAsync(RegisterUserCommand command);
    }
}
