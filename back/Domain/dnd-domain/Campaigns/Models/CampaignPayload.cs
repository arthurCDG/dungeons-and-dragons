using dnd_domain.Campaigns.Enums;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class CampaignPayload
{
    public int? DungeonMasterId { get; set; }
    public required HashSet<int> PlayerIds { get; set; }
    public required CampaignType Type { get; set; }
}
