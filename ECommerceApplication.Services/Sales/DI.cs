using Appliction.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Services;

public static class SalesDependencyInjection
{
    public static IServiceCollection AddSaleServices(this IServiceCollection services)
    {
        services.AddTransient<ISaleService, SaleService>();
        return services;
    }
}
