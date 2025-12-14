using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    // This handler orchestrates the application logic
    public class RegisterUserHandler
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserHandler(IUserRepository userRepository)
        {
            // Depends on the interface (abstraction) defined in this same layer
            _userRepository = userRepository;
        }

        public async Task Handle(RegisterUserRequest command)
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
        }
    }
}
