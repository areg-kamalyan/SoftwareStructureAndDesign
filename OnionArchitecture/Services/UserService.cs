using Domain.Entities;
using Services.DTOs;
using Services.Interfaces;

namespace Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            // Depends on the interface (abstraction) defined in this same layer
            _userRepository = userRepository;
        }

        public async Task<User> RegisterUserAsync(UserDto Data)
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
