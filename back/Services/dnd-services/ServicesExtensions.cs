using dnd_services.Campaigns;
using dnd_services.Sessions;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_infra;

public static class ServicesExtensions
{
    public static void AddServicesExtensions(this IServiceCollection services)
    {
        services.AddScoped<ISessionsService, SessionsService>();
        services.AddScoped<ICampaignsService, CampaignsService>();
    }
}
