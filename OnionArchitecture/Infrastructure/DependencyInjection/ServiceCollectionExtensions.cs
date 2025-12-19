using Services.Interfaces.Messaging;
using Services.Interfaces.Repositories;
using Infrastructure.Messaging;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

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

            return services;
        }
    }
}
