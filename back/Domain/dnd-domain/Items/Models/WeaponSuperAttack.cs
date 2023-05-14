using dnd_domain.Dice.Models;
using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class WeaponSuperAttack
{
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public WeaponSuperAttackType Type { get; set; }

    public List<DieAssociation>? Dice { get; set; }
    public bool? LosesWeaponAfterSuperAttack { get; set; }
    public bool? LosesWeaponIfStarDieReturnsStar { get; set; }
}
