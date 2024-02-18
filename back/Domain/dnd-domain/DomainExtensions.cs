using dnd_domain.Players.Services;
using dnd_domain.Players.Services.ValidationServices;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_infra;

public static class DomainExtensions
{
    public static void AddDomainExtensions(this IServiceCollection services)
    {
        services.AddScoped<ISquareMovementService, SquareMovementService>()
                .AddScoped<IPlayersValidationService, PlayersValidationService>()
                .AddScoped<IPlayersService, PlayersService>();
    }
}
