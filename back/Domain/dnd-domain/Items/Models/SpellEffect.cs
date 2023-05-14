using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class SpellEffect
{
    public int Id { get; set; }
    public int SpellId { get; set; }
    public SpellEffectType Effect { get; set; }
}
