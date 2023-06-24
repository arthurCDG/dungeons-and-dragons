using dnd_application.Campaigns;
using dnd_application.Campaigns.Rooms.Squares;
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
    }
}
