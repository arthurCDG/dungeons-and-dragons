using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using dnd_infra.Campaigns.Adventures;
using dnd_infra.Players.DALs;
using System;
using System.Collections.Generic;

namespace dnd_infra.Campaigns;

internal sealed class CampaignDal
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required string Name { get; set; }
    public required DateTimeOffset StartsAt { get; set; }
    public required CampaignType Type { get; set; }
    public int? DungeonMasterId { get; set; }
    public DateTimeOffset? EndsAt { get; set; }

    public List<AdventureDal> Adventures { get; set; } = new();
    public List<PlayerDal> Players { get; set; } = new();

    public Campaign ToDomain()
        => new()
        {
            Id = Id,
            DungeonMasterId = DungeonMasterId,
            Name = Name,
            Description = Description,
            Type = Type,
            StartsAt = StartsAt,
            EndsAt = EndsAt,
            Adventures = Adventures.ConvertAll(a => a.ToDomain()),
            Players = Players.ConvertAll(p => p.ToDomain())
        };
}
