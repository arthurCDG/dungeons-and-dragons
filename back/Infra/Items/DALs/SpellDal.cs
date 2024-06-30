using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal class SpellDal : ItemDal
{
    public int ManaCost { get; set; }
    public int MaximumDamage { get; set; }
    public int MinimumDamage { get; set; }
    public SpellType Type { get; set; }
    public bool IsMeleeSpellOnly { get; set; } = false;

    public Spell ToDomain()
        => new()
        {
            Id = Id,
            Description = Description,
            Explanation = Explanation,
            ImageUrl = ImageUrl,
            Level = Level,
            Name = Name,
            IsMeleeSpellOnly = IsMeleeSpellOnly,
            ManaCost = ManaCost,
            Type = Type,
            Effects = Effects.Select(e => e.ToDomain()).ToList()
        };
}
