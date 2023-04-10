using dnd_domain.Items.Enums;
using dnd_infra.Dice;
using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal class SpellDal : BaseItemDal
{
    public int ManaCost { get; set; }
    public SpellType Type { get; set; }
    public List<DieDal> Dice { get; set; } = new();
    public List<SpellEffectDal> Effects { get; set; } = new();

    public StarDieEffect? StarDieEffect { get; set; }
    public bool? IsMeleeSpell { get; set; }
}
