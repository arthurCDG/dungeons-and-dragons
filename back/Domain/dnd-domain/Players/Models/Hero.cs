using dnd_domain.Items.Models;
using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Models;

public class Hero : Player
{
    public int SquareId { get; set; }
    public HeroClass Class { get; set; }
    public HeroRace Race { get; set; }
    public List<StoredItem> StoredItems { get; set; } = new();
}
