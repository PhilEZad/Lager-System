using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver;

public class DependencyResolver
{
    public static void RegisterInfrastructureLayer(IServiceCollection service)
    {
        service.AddScoped<IItemRepository, ItemRepository>();
        service.AddScoped<ICategoryRepository, CategoryRepository>();
        
        service.AddScoped<IDatabaseRepository, DatabaseRepository>();
        
    }
}