using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TechECommerce.DataAccess.Persistance.Context.EfCore;
using TechECommerce.DataAccess.Repositories.Implementations;
using TechECommerce.DataAccess.Repositories.Interface;

namespace TechECommerce.DataAccess.ConfigurationService;

public static class DataAccessConfigurationService
{
    public static IServiceCollection AddRepositoriesService(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }

    public static IServiceCollection AddDatabaseSevice(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });
        return services;
    }
}
