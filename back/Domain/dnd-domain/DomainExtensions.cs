using dnd_domain.Players.Services;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_infra;

public static class DomainExtensions
{
    public static void AddDomainExtensions(this IServiceCollection services)
    {
        services.AddScoped<ISquareMovementService, SquareMovementService>();
        services.AddScoped<IPlayersService, PlayersService>();
    }
}
