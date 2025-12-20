using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces.UseCases
{
    public interface IRegisterUserUseCase
    {
        Task<User> ExecuteAsync(UserDto Data);
    }
}
