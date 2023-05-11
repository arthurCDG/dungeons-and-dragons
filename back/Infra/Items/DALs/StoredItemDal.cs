namespace dnd_infra.Items.DALs;

internal sealed class StoredItemDal
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public bool IsEquiped { get; set; } = false;
    public bool IsDiscarded { get; set; } = false;

    public int? HeroId { get; set; }
    public int? MonsterId { get; set; }

    public int? ArtefactId { get; set; }
    public ArtefactDal? Artefact { get; set; }
    public int? PotionId { get; set; }
    public PotionDal? Potion { get; set; }
    public int? SpellId { get; set; }
    public SpellDal? Spell { get; set; }
    public int? WeaponId { get; set; }
    public WeaponDal? Weapon { get; set; }
}
