using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Rooms.Squares.Repositories;
using dnd_domain.Players.Repositories;
using dnd_domain.Sessions.Services;
using dnd_infra.Campaigns;
using dnd_infra.Campaigns.Rooms.Squares.Repositories;
using dnd_infra.Players.Repositories;
using dnd_infra.Seeder;
using dnd_infra.Sessions;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_infra;

public static class InfraExtensions
{
    public static void AddInfraExtensiosn(this IServiceCollection services)
    {
        services.AddDbContext<GlobalDbContext>();

        services.AddScoped<ISessionsRepository, SessionsRepository>();
        services.AddScoped<ICampaignsRepository, CampaignsRepository>();
        services.AddScoped<ISquareMovementRepository, SquareMovementRepository>();
        services.AddScoped<ISquaresRepository, SquaresRepository>();
        services.AddScoped<IHeroesRepository, HeroesRepository>();
        services.AddScoped<IMonstersRepository, MonstersRepository>();

        services.AddScoped<ItemsSeeder>();
        services.AddScoped<PlayersSeeder>();
    }
}
