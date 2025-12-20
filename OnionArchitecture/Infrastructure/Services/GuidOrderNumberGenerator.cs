using Domain.Interfaces;
namespace Infrastructure.Services
{
    internal class GuidOrderNumberGenerator : IOrderNumberGenerator
    {
        public string Generate()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
