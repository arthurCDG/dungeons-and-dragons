using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class CampaignDto
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    public Adventure Adventure { get; set; }

    public List<Square> Squares { get; set; } = new();

    public static CampaignDto FromDomain(Campaign campaign)
        => new()
        {
            Id = campaign.Id,
            SessionId = campaign.SessionId,
            StartsAt = campaign.StartsAt,
            EndsAt = campaign.EndsAt,
            Adventure = campaign.Adventure,
            Squares = campaign.Rooms.SelectMany(r => r.Squares).OrderBy(r => r.Id).ToList()
        };
}
