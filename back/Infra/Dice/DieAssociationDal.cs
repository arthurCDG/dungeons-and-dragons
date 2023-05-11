using dnd_domain.Dice;

namespace dnd_infra.Dice;

internal sealed class DieAssociationDal
{
    public int Id { get; set; }
    public DieType DieType { get; set; }

    public int? ArtefactId { get; set; }
    public int? ChestTrapId { get; set; }
    public int? PotionId { get; set; }
    public int? SpellId { get; set; }
    public int? WeaponId { get; set; }
    public int? WeaponSuperAttackId { get; set; }
}
