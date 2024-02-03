using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Services.Implementations;
using OnlineShop.Application.Services.Interfaces;

namespace OnlineShop.Application;

public static class ApplicationService
{
    public static IServiceCollection AddUtilityService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}