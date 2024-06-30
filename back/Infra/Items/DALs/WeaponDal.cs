using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;

namespace dnd_infra.Items.DALs;

internal sealed class WeaponDal : ItemDal
{
    public required int MaximumDamage { get; set; }
    public required int MinimumDamage { get; set; }
    public WeaponSuperAttackDal? SuperAttack { get; set; }
    public WeaponType Type { get; set; } = new();

    public Weapon ToDomain()
        => new()
        {
            Id = Id,
            Description = Description,
            Explanation = Explanation,
            ImageUrl = ImageUrl,
            Level = Level,
            Name = Name,
            Type = Type,
            SuperAttack = SuperAttack?.ToDomain(),
            Effects = Effects.ConvertAll(e => e.ToDomain())
        };
}
