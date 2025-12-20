using Domain.Entities;
using Services.DTOs;
namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(UserDto Data);
    }

}