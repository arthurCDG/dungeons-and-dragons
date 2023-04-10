using dnd_domain.Items.Enums;
using dnd_infra.Dice;
using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal sealed class WeaponDal : BaseItemDal
{
    public WeaponType WeaponType { get; set; } = new();
    public List<DieDal> Dice { get; set; } = new();
    public List<WeaponEffectDal> Effects { get; set; } = new();

    public WeaponSuperAttackDal? SuperAttack { get; set; }
    public bool? CanRerollOneDie { get; set; }
    public StarDieEffect? StarDieEffect { get; set; }
}
