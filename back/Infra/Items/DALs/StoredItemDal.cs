using dnd_domain.Items.Models;

namespace dnd_infra.Items.DALs;

internal sealed class StoredItemDal
{
    public int Id { get; set; }
    public bool IsEquiped { get; set; } = false;
    public bool IsDiscarded { get; set; } = false;
    public int PlayerId { get; set; }


    public int? ArtefactId { get; set; }
    public ArtefactDal? Artefact { get; set; }
    public int? PotionId { get; set; }
    public PotionDal? Potion { get; set; }
    public int? SpellId { get; set; }
    public SpellDal? Spell { get; set; }
    public int? WeaponId { get; set; }
    public WeaponDal? Weapon { get; set; }

    public StoredItem ToDomain()
        => new()
        {
            Id = Id,
            IsEquiped = IsEquiped,
            IsDiscarded = IsDiscarded,
            PlayerId = PlayerId,
            ArtefactId = ArtefactId,
            Artefact = Artefact?.ToDomain(),
            PotionId = PotionId,
            Potion = Potion?.ToDomain(),
            SpellId = SpellId,
            Spell = Spell?.ToDomain(),
            WeaponId = WeaponId,
            Weapon = Weapon?.ToDomain(),
        };
}
