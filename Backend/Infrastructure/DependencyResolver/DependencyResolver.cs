using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver;

public class DependencyResolver
{
    public static void RegisterInfrastructureLayer(IServiceCollection service)
    {
        service.AddScoped<IItemRepository, ItemRepository>();
        service.AddScoped<IDatabaseRepository, DatabaseRepository>();
    }
}