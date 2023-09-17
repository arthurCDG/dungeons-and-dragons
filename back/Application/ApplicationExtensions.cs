using dnd_application.Campaigns;
using dnd_application.Campaigns.Adventures;
using dnd_application.Campaigns.Adventures.Rooms.Squares;
using dnd_application.GameFlow;
using dnd_application.Players;
using dnd_application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_application;

public static class ApplicationExtensions
{
    public static void AddApplicationExtensions(this IServiceCollection services)
    {
        services.AddScoped<ICampaignsService, CampaignsService>();
        services.AddScoped<ISquaresService, SquaresService>();
        services.AddScoped<IAttacksService, AttacksService>();
        services.AddScoped<ITurnFlowService, TurnFlowService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IPlayersService, PlayersService>();
        services.AddScoped<IAdventuresService, AdventuresService>();
        services.AddScoped<ICreatablePlayersService, CreatablePlayersService>();
        services.AddScoped<ICreatableCampaignsService, CreatableCampaignsService>();
        services.AddScoped<ICreatableAdventuresService, CreatableAdventuresService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}
