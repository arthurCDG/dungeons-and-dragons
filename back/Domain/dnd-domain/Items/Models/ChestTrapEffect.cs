using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class ChestTrapEffect
{
    public int Id { get; set; }
    public int ChestTrapId { get; set; }
    public ChestTrapEffectType Effect { get; set; }
}
