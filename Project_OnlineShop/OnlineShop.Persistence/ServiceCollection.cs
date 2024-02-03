using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Domain.IRepositories;
using OnlineShop.Persistence.Repositories;

namespace OnlineShop.Persistence;

public static class RepositoryService
{
    public static IServiceCollection AddRepositoryService(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}