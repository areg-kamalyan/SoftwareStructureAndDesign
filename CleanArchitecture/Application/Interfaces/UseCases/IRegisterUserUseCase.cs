using Application.DTOs;
using Application.UseCases.Users.RegisterUser;

namespace Application.Interfaces.UseCases
{
    public interface IRegisterUserUseCase
    {
        Task<UserDto> ExecuteAsync(RegisterUserCommand command);
    }
}
