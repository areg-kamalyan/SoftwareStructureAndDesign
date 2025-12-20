using Application.DTOs;
using Domain.Entities;

namespace Application.Ports.Input
{
    public interface IRegisterUserUseCase
    {
        Task<User> ExecuteAsync(UserDto Data);
    }
}
