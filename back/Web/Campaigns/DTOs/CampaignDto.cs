using dnd_domain.Campaigns.Enums;
using System;
using System.Collections.Generic;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class CampaignDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CampaignType Type { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }

    public List<AdventureDto> Adventures { get; set; } = new();
}
