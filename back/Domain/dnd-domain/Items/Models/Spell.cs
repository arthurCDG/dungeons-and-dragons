using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class Spell : Item
{
    public bool IsMeleeSpellOnly { get; set; } = false;
    public int ManaCost { get; set; }
    public SpellType Type { get; set; }
}
