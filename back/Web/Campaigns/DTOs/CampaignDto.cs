using System;
using System.Collections.Generic;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class CampaignDto
{
    public int Id { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }

    public List<AdventureDto> Adventures { get; set; } = new();
}
