using dnd_domain.Campaigns.Models;
using dnd_domain.GameFlow.Models;
using dnd_domain.Items.Models;
using System.Collections.Generic;

namespace dnd_domain.Players.Models;

public class Player
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public bool IsDead { get; set; } = false;
    public int? SquareId { get; set; }

    public PlayerProfile? Profile { get; set; } = null!;
    public PlayerMaxAttributes? MaxAttributes { get; set; } = null!;
    public PlayerAttributes? Attributes { get; set; }
    public TurnOrder? TurnOrder { get; set; }

    public List<Campaign> Campaigns { get; set; } = new();
    public List<StoredItem> StoredItems { get; set; } = new();
}
