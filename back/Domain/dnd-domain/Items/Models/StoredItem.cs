namespace dnd_domain.Items.Models;

public class StoredItem
{
    public int Id { get; set; }
    public bool IsEquiped { get; set; } = false;
    public bool IsDiscarded { get; set; } = false;

    public int? HeroId { get; set; }
    public int? MonsterId { get; set; }

    public int? ArtefactId { get; set; }
    public Artefact? Artefact { get; set; }
    public int? PotionId { get; set; }
    public Potion? Potion { get; set; }
    public int? SpellId { get; set; }
    public Spell? Spell { get; set; }
    public int? WeaponId { get; set; }
    public Weapon? Weapon { get; set; }
}
