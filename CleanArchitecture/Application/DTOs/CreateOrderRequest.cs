using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record CreateOrderRequest(Guid UsersId, string Title, string Details, Money Price);
}
