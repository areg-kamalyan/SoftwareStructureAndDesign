using Application.Interfaces.Messaging;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCases;
using Application.UseCases.Orders.CreateOrder;
using Application.UseCases.Orders.GetOrder;
using Application.UseCases.Orders.ShipOrder;
using Application.UseCases.Users.RegisterUser;
using Infrastructure.Messaging;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        static string ConnectionString = @"Server=(localdb)\ProjectModels;Database=ForArchitecturesDB;Trusted_Connection=True;Integrated Security=True";

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<AppDbContext, AppDbContext>();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(ConnectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IShipOrderUseCase, ShipOrderUseCase>();
            services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
            services.AddScoped<IGetOrderUseCase, GetOrderUseCase>();

            services.AddScoped<IOrderShippedEventPublisher, OrderShippedEventPublisher>();
            return services;
        }
    }
}
