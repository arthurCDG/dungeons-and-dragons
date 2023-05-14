using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using dnd_infra.Campaigns.Rooms;
using dnd_infra.Players.DALs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Campaigns;

internal sealed class CampaignDal
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public Adventure Adventure { get; set; }

    public List<RoomDal> Rooms { get; set; } = new();
    public List<HeroDal> Heroes { get; set; } = new();
    public List<MonsterDal> Monsters { get; set; } = new();

    public Campaign ToDomain()
        => new()
        {
            Id = Id,
            SessionId = SessionId,
            StartsAt = StartsAt,
            EndsAt = EndsAt,
            Adventure = Adventure,
            Rooms = Rooms.Select(r => r.ToDomain()).ToList(),
            Heroes = Heroes.Select(r => r.ToDomain()).ToList(),
            Monsters = Monsters.Select(r => r.ToDomain()).ToList()
        };
}
