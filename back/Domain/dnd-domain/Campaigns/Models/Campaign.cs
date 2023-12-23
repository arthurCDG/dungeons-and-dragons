using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Enums;
using dnd_domain.Players.Models;
using System;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class Campaign
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public CampaignType Type { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }

    public List<Adventure> Adventures { get; set; } = new();
    public List<Player> Players { get; set; } = new();
}
