using Domain.Entities;
using Domain.Interfaces;
using Services.Requests;

namespace Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            // Depends on the interface (abstraction) defined in this same layer
            _userRepository = userRepository;
        }

        public async Task RegisterUserAsync(RegisterUserRequest command)
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
