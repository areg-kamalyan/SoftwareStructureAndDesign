using Application.UseCases.Users.RegisterUser;

namespace WebApi.Requests
{
    public class RegisterUserRequest
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public RegisterUserCommand ToCommand()
            => new RegisterUserCommand(Email, FirstName, LastName);
    }
}
