using dnd_domain.Dice.Models;
using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class Weapon : Item
{
    public WeaponType WeaponType { get; set; } = new();
    public List<DieAssociation> Dice { get; set; } = new();
    public List<WeaponEffect> Effects { get; set; } = new();

    public WeaponSuperAttack? SuperAttack { get; set; }
    public bool? CanRerollOneDie { get; set; }
    public StarDieEffectType? StarDieEffect { get; set; }
}
