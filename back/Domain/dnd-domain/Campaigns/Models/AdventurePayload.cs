using dnd_domain.Campaigns.Enums;
using System.Collections.Generic;

namespace dnd_domain.Campaigns.Models;

public class AdventurePayload
{
    public AdventureType Adventure { get; set; }
    public HashSet<int> PlayerIds { get; set; } = new();
}
