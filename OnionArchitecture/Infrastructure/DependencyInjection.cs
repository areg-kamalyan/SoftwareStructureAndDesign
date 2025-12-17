using Domain.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace Infrastructure
{
    public static class DependencyInjection
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

            return services;
        }
    }
}
