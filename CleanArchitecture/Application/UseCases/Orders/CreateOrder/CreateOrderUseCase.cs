using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;
using Domain.Entities;

namespace Application.UseCases.Orders.CreateOrder
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public CreateOrderUseCase(IOrderRepository repo, IUserRepository userRepository)
        {
            _orderRepository = repo;
            _userRepository = userRepository;
        }

        public async Task<OrderDto> ExecuteAsync(CreateOrderCommand command, CancellationToken ct = default)
        {
            var existingUser = await _userRepository.GetByIdAsync(command.UserId);

            if (existingUser is null)
            {
                throw new InvalidOperationException($"User with ID {command.UserId} do not exists.");
            }
            var order = new Order(command.UserId, command.Title, command.Details, command.Price);
            await _orderRepository.AddAsync(order, ct);
            return new OrderDto(order.Id, order.Status.ToString());
        }
    }
}
