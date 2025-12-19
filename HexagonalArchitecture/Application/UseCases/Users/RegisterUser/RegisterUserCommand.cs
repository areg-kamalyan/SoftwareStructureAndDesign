using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Users.RegisterUser
{
    public record RegisterUserCommand(string Email, string FirstName, string LastName);
}
