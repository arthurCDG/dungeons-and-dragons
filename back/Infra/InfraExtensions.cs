using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Adventures.Rooms.Squares;
using dnd_domain.GameFlow.Repositories;
using dnd_domain.Players.Repositories;
using dnd_domain.Users;
using dnd_infra.Campaigns;
using dnd_infra.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.Repositories;
using dnd_infra.GameFlow.Repositories;
using dnd_infra.Players.Repositories;
using dnd_infra.Users;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_infra;

public static class InfraExtensions
{
    public static void AddInfraExtensions(this IServiceCollection services)
    {
        services.AddDbContext<GlobalDbContext>();

        services.AddScoped<ICampaignsRepository, CampaignsRepository>()
                .AddScoped<IAdventuresRepository, AdventuresRepository>()
                .AddScoped<ISquareMovementRepository, SquareMovementRepository>()
                .AddScoped<ISquaresRepository, SquaresRepository>();

        services.AddScoped<IPlayersRepository, PlayersRepository>()
                .AddScoped<IUsersRepository, UsersRepository>()
                .AddScoped<IAttacksRepository, AttacksRepository>()
                .AddScoped<IAvailablePlayersRepository, AvailablePlayersRepository>()
                .AddScoped<IAvailableUsersRepository, AvailableUsersRepository>()
                .AddScoped<PlayersFactory>();

        services.AddScoped<ITurnFlowRepository, TurnFlowRepository>();
    }
}
