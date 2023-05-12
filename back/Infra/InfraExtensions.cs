using dnd_domain.Seeder;
using dnd_infra.Seeder;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_infra;

public static class InfraExtensions
{
    public static void AddGlobalDbContext(this IServiceCollection services)
    {
        services.AddDbContext<GlobalDbContext>();
        services.AddScoped<ISessionSeeder, SessionSeeder>();
        services.AddScoped<ItemsSeeder>();
        services.AddScoped<PlayersSeeder>();
    }
}
