using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;
using Domain.Entities;

namespace Application.UseCases.Users.RegisterUser
{
    // This handler orchestrates the application logic
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            // Depends on the interface (abstraction) defined in this same layer
            _userRepository = userRepository;
        }

        public async Task<UserDto> ExecuteAsync(RegisterUserCommand command)
        {
            var existingUser = await _userRepository.GetByEmailAsync(command.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException($"User with email {command.Email} already exists.");
            }

            // The domain entity enforces its own rules
            var newUser = new User(command.Email, command.FirstName, command.LastName);

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            return new UserDto(newUser.Id, newUser.Email);
        }
    }
}
