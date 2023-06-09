﻿using dungeons_and_dragons.Campaigns.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace dungeons_and_dragons;

public static class WebExtensions
{
    public static void AddWebExtensions(this IServiceCollection services)
    {
        services.AddScoped<CampaignDtoMapper>();
        services.AddScoped<AdventureDtoMapper>();
    }
}