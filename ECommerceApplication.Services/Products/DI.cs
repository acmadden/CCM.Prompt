using Appliction.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services;

public static class ProductDependencyInjection
{
    public static IServiceCollection AddProductServices(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        services.AddHttpClient<IProductService, ProductService>(config =>
        {
            config.BaseAddress = new Uri("https://fakestoreapi.com");
        });
        return services;
    }
}
