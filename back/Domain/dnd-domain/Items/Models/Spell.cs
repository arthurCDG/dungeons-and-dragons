using dnd_domain.Dice.Models;
using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class Spell : Item
{
    public int ManaCost { get; set; }
    public SpellType Type { get; set; }
    public List<DieAssociation> Dice { get; set; } = new();
    public List<SpellEffect> Effects { get; set; } = new();

    public StarDieEffectType? StarDieEffect { get; set; }
    public bool IsMeleeSpell { get; set; } = false;
    public bool IsDistantSpell { get; set; } = false;
}
