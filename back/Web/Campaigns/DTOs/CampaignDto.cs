using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
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

    public List<SquareDto> Squares { get; set; } = new();

    public static CampaignDto FromDomain(Campaign campaign, List<SquareDto> squares)
        => new()
        {
            Id = campaign.Id,
            SessionId = campaign.SessionId,
            StartsAt = campaign.StartsAt,
            EndsAt = campaign.EndsAt,
            Adventure = campaign.Adventure,
            Squares = squares
        };
}
