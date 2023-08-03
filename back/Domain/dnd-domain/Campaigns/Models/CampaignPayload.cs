using dnd_domain.Campaigns.Adventures;
using dnd_domain.Campaigns.Enums;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class CampaignPayload
{
    public CampaignType Type { get; set; }
    public HashSet<int> PlayerIds { get; set; } = new();
    public AdventurePayload AdventurePayload { get; set; } = new();
}
