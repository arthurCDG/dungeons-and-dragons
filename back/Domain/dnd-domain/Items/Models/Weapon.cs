using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class Weapon : Item
{
    public WeaponSuperAttack? SuperAttack { get; set; }
    public WeaponType Type { get; set; } = new();
}
