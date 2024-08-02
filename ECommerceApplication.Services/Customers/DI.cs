using Microsoft.Extensions.DependencyInjection;

namespace Application.Services;

public static class CustomerDependencyInjection
{
    public static IServiceCollection AddCustomerServices(this IServiceCollection services)
    {
        services.AddTransient<ICustomerService, CustomerService>();
        return services;
    }
}