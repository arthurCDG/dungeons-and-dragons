using dnd_domain.Items.Models;
using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public class Monster : Player
{
    public int SquareId { get; set; }
    public MonsterType Type { get; set; } = new();
    public List<StoredItem> StoredItems { get; set; } = new();
}
