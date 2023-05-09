using dnd_domain.Items.Enums;
using dnd_infra.Dice;
using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal class SpellDal : ItemDal
{
    public int ManaCost { get; set; }
    public SpellType Type { get; set; }
    public List<DieAssociationDal> Dice { get; set; } = new();
    public List<SpellEffectDal> Effects { get; set; } = new();

    public StarDieEffectType? StarDieEffect { get; set; }
    public bool IsMeleeSpell { get; set; } = false;
    public bool IsDistantSpell { get; set; } = false;
}
