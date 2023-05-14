using dnd_domain.Campaigns.Enums;
using dungeons_and_dragons.Players.DTOs;
using System;
using System.Collections.Generic;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class CampaignDto
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public Adventure Adventure { get; set; }

    public List<RoomDto> Rooms { get; set; } = new();
    public List<HeroDto> Heroes { get; set; } = new();
    public List<MonsterDto> Monsters { get; set; } = new();
}
