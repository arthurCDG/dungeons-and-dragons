using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Enums;
using dnd_domain.Players.Models;
using System;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class Campaign
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public required string Name { get; set; }
    public required DateTimeOffset StartsAt { get; set; }
    public required CampaignType Type { get; set; }
    public int? DungeonMasterId { get; set; }
    public DateTimeOffset? EndsAt { get; set; }

    public List<Adventure> Adventures { get; set; } = new();
    public List<Player> Players { get; set; } = new();
}
