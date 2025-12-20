using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;
using Domain.Entities;

namespace Application.UseCases.Users
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

        public async Task<User> ExecuteAsync(UserDto Data)
        {
            var existingUser = await _userRepository.GetByEmailAsync(Data.Email);

            if (existingUser != null)
            {
                throw new InvalidOperationException($"User with email {Data.Email} already exists.");
            }

            // The domain entity enforces its own rules
            var newUser = new User(Data.Email, Data.FirstName, Data.LastName);

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            return newUser;
        }
    }
}
