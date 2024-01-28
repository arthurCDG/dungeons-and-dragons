using dnd_domain.Campaigns.Adventures.Rooms.Squares;
using dnd_domain.GameFlow.Models;
using dnd_domain.Items.Models;
using System.Collections.Generic;

namespace dnd_domain.Players.Models;

public class Player
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public bool IsAvailable { get; set; } = false;
    public bool IsDead { get; set; } = false;
    public Square? Square { get; set; }
    public int? CampaignId { get; set; }

    public PlayerProfile? Profile { get; set; }
    public PlayerMaxAttributes? MaxAttributes { get; set; }
    public PlayerAttributes? Attributes { get; set; }
    public TurnOrder? TurnOrder { get; set; }

    public List<StoredItem> StoredItems { get; set; } = new();
}
