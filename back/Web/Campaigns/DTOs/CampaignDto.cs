using dnd_domain.Campaigns.Enums;
using System;
using System.Collections.Generic;

namespace dungeons_and_dragons.Campaigns.DTOs;

public class CampaignDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required CampaignType Type { get; set; }
    public required DateTimeOffset StartsAt { get; set; }
    public DateTimeOffset? EndsAt { get; set; }

    public List<AdventureDto> Adventures { get; set; } = new();
}
