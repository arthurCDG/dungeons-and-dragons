using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class CampaignPayload
{
    public string Name { get; set; } = null!;
    public int Level { get; set; }
    public HashSet<int> UserIds { get; set; } = new();
    public AdventurePayload AdventurePayload { get; set; } = new();
}
