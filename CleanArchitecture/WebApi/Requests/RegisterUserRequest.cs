using Application.DTOs;

namespace WebApi.Requests
{
    public class RegisterUserRequest
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public UserDto ToCommand()
            => new UserDto(Email, FirstName, LastName);
    }
}
