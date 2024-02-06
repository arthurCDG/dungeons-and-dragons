using dnd_application.Campaigns;
using dnd_application.Campaigns.Adventures;
using dnd_application.Campaigns.Adventures.Rooms.Squares;
using dnd_application.GameFlow;
using dnd_application.Players;
using dnd_application.Users;
using dnd_application.Users.ValidationServices;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_application;

public static class ApplicationExtensions
{
    public static void AddApplicationExtensions(this IServiceCollection services)
    {
        services.AddScoped<ICampaignsService, CampaignsService>()
                .AddScoped<ISquaresService, SquaresService>()
                .AddScoped<IAttacksService, AttacksService>()
                .AddScoped<ITurnFlowService, TurnFlowService>()
                .AddScoped<IUsersService, UsersService>()
                .AddScoped<IPlayersService, PlayersService>()
                .AddScoped<IAdventuresService, AdventuresService>()
                .AddScoped<ICreatablePlayersService, CreatablePlayersService>()
                .AddScoped<ICreatableCampaignsService, CreatableCampaignsService>()
                .AddScoped<ICreatableAdventuresService, CreatableAdventuresService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<IAvailableUsersService, AvailableUsersService>()
                .AddScoped<IAvailablePlayersService, AvailablePlayersService>()
                .AddScoped<UserValidationService>();
        
    }
}
