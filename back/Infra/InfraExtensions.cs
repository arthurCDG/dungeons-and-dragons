using Microsoft.Extensions.DependencyInjection;

namespace dnd_infra;

public static class InfraExtensions
{
    public static void AddGlobalDbContext(this IServiceCollection services)
    {
        services.AddDbContext<GlobalDbContext>();
    }
}
