using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class SpellAttributes
{
    public int Id { get; set; }
    public bool IsMeleeSpellOnly { get; set; } = false;
    public required int ManaCost { get; set; }
    public int MaximumDamage { get; set; }
    public int MinimumDamage { get; set; }
    public int SpellId { get; set; }
    public required SpellType Type { get; set; }
}
