using Domain.Interfaces;
using Infrastructure.Messaging;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;

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

            services.AddScoped<OrderService>();
            services.AddScoped<UserService>();


            services.AddScoped<IOrderShippedEventPublisher, OrderShippedEventPublisher>();
            services.AddScoped<IOrderNumberGenerator, GuidOrderNumberGenerator>();

            return services;
        }
    }
}
