using dnd_domain.Items.Services;
using dnd_domain.Players.Services;
using dnd_domain.Players.Services.ValidationServices;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_domain;

public static class DomainExtensions
{
    public static void AddDomainExtensions(this IServiceCollection services)
    {
        services.AddScoped<IChestItemsService, ChestItemsService>()
                .AddScoped<IPlayersService, PlayersService>()
                .AddScoped<IPlayersValidationService, PlayersValidationService>()
                .AddScoped<ISquareMovementService, SquareMovementService>();
    }
}
