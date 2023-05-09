using dnd_domain.Items.Enums;
using dnd_infra.Dice;
using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal sealed class WeaponSuperAttackDal
{
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public WeaponSuperAttackType Type { get; set; }

    public List<DieAssociationDal>? Dice { get; set; }
    public bool? LosesWeaponAfterSuperAttack { get; set; }
    public bool? LosesWeaponIfStarDieReturnsStar { get; set; }
}
