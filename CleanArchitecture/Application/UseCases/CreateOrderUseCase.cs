using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class CreateOrderUseCase
    {
        private readonly IOrderRepository _repo;
        private readonly IUserRepository _userRepository;

        public CreateOrderUseCase(IOrderRepository repo, IUserRepository userRepository) 
        {
            _repo = repo;
            _userRepository = userRepository;
        } 

        public async Task<Guid> ExecuteAsync(CreateOrderRequest request, CancellationToken ct = default)
        {
            var existingUser = await _userRepository.GetByIdAsync(request.UsersId);

            if (existingUser is null)
            {
                throw new InvalidOperationException($"User with ID {request.UsersId} do not exists.");
            }
            var order = new Order(request.UsersId, request.Title, request.Details, request.Price);
            await _repo.AddAsync(order, ct);
            return order.Id;
        }
    }
}
