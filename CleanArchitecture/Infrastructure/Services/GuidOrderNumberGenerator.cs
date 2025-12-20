using Domain.Interfaces;
namespace Infrastructure.Services
{
    internal class GuidOrderNumberGenerator : IOrderNumberGenerator
    {
        public string Generate()
        {
            return new Guid().ToString();
        }
    }
}
