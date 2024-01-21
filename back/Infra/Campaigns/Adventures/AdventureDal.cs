using dnd_domain.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms;
using System;
using System.Collections.Generic;

namespace dnd_infra.Campaigns.Adventures;

internal class AdventureDal
{
    public int Id { get; set; }
    public required int CampaignId { get; set; }
    public required string Name { get; set; }
    public required AdventureType Type { get; set; }
    public required DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset? EndsAt { get; set; }

    public List<RoomDal> Rooms { get; set; } = new();

    public Adventure ToDomain()
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Name = Name,
            Type = Type,
            StartsAt = StartsAt,
            EndsAt = EndsAt,
            Rooms = Rooms.ConvertAll(p => p.ToDomain())
        };
}
