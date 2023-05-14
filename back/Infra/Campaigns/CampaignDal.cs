using dnd_domain.Campaigns;
using dnd_infra.Campaigns.Rooms;
using dnd_infra.Players.DALs;
using System;
using System.Collections.Generic;

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
}
