﻿using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Rooms.Squares.Repositories;
using dnd_domain.GameFlow.Repositories;
using dnd_domain.Items.Services;
using dnd_domain.Players.Repositories;
using dnd_domain.Users;
using dnd_infra.Campaigns;
using dnd_infra.Campaigns.Rooms.Squares.Repositories;
using dnd_infra.GameFlow.Repositories;
using dnd_infra.Players.Repositories;
using dnd_infra.Seeder;
using dnd_infra.Users;
using Microsoft.Extensions.DependencyInjection;

namespace dnd_infra;

public static class InfraExtensions
{
    public static void AddInfraExtensions(this IServiceCollection services)
    {
        services.AddDbContext<GlobalDbContext>();

        services.AddScoped<ICampaignsRepository, CampaignsRepository>();
        services.AddScoped<ISquareMovementRepository, SquareMovementRepository>();
        services.AddScoped<ISquaresRepository, SquaresRepository>();
        services.AddScoped<IPlayersRepository, PlayersRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();

        services.AddScoped<IItemsSeederService,ItemsSeederService>();
        services.AddScoped<PlayersFactory>();

        services.AddScoped<ITurnFlowRepository, TurnFlowRepository>();
    }
}
