namespace dnd_domain.Items.Models;

public class Weapon : Item
{
    public required WeaponAttributes Attributes { get; set; }
    public WeaponSuperAttack? SuperAttack { get; set; }
}
