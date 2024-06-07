namespace dnd_domain.Items.Models;

public class StoredItem
{
    public int Id { get; set; }
    public bool IsEquiped { get; set; } = false;
    public bool IsDiscarded { get; set; } = false;
    public int PlayerId { get; set; } 

    public int? ArtifactId { get; set; }
    public Artifact? Artifact { get; set; }
    public int? PotionId { get; set; }
    public Potion? Potion { get; set; }
    public int? SpellId { get; set; }
    public Spell? Spell { get; set; }
    public int? WeaponId { get; set; }
    public Weapon? Weapon { get; set; }
}
