using dnd_domain.GameFlow.Models;
using dnd_domain.Items.Models;
using System.Collections.Generic;

namespace dnd_domain.Players.Models;

public class Player
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AdventureId { get; set; }
    public int SquareId { get; set; }
    public bool IsDead { get; set; } = false;

    public PlayerProfile Profile { get; set; } = null!;
    public PlayerAttributes Attributes { get; set; } = null!;
    public PlayerMaxAttributes MaxAttributes { get; set; } = null!;
    public TurnOrder TurnOrder { get; set; } = null!;

    public List<StoredItem> StoredItems { get; set; } = new();
}
