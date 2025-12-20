using Application.DTOs;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;
using Domain.Entities;
using Domain.Interfaces;
using System.Reflection.Emit;

namespace Application.UseCases.Orders
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderNumberGenerator _generator;

        public CreateOrderUseCase(IOrderRepository repo, IUserRepository userRepository, IOrderNumberGenerator generator)
        {
            _orderRepository = repo;
            _userRepository = userRepository;
            _generator = generator;
        }

        public async Task<Order> ExecuteAsync(OrderDto data, CancellationToken ct = default)
        {
            var existingUser = await _userRepository.GetByIdAsync(data.UserId);

            if (existingUser is null)
            {
                throw new InvalidOperationException($"User with ID {data.UserId} do not exists.");
            }
            var order = new Order(_generator.Generate(), data.UserId, data.Title, data.Details, data.Price);
            await _orderRepository.AddAsync(order, ct);
            return order;
        }
    }
}
