using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;
using dnd_infra.Dice;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal sealed class WeaponSuperAttackDal
{
    public int Id { get; set; }
    public int WeaponId { get; set; }
    public WeaponSuperAttackType Type { get; set; }

    public List<DieAssociationDal>? Dice { get; set; }
    public bool? LosesWeaponAfterSuperAttack { get; set; }
    public bool? LosesWeaponIfStarDieReturnsStar { get; set; }

    public WeaponSuperAttack ToDomain()
        => new()
        {
            Id = Id,
            WeaponId = WeaponId,
            Type = Type,
            LosesWeaponAfterSuperAttack = LosesWeaponAfterSuperAttack,
            LosesWeaponIfStarDieReturnsStar = LosesWeaponIfStarDieReturnsStar,
            Dice = Dice?.Select(d => d.ToDomain())?.ToList()
        };
}
