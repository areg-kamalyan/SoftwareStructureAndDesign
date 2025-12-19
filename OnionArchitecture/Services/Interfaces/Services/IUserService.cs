using Services.Commands;
using Services.DTOs;

namespace Services.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(RegisterUserCommand command);
    }

}