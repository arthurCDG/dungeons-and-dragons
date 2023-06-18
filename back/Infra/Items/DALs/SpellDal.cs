using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;
using dnd_infra.Dice;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal class SpellDal : ItemDal
{
    public int ManaCost { get; set; }
    public SpellType Type { get; set; }
    public bool IsMeleeSpell { get; set; } = false;
    public bool IsDistantSpell { get; set; } = false;

    public List<DieAssociationDal> Dice { get; set; } = new();
    public List<SpellEffectDal> Effects { get; set; } = new();

     public StarDieEffectType? StarDieEffect { get; set; }

    public Spell ToDomain()
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Description = Description,
            Explanation = Explanation,
            ImageUrl = ImageUrl,
            Level = Level,
            Name = Name,
            IsDistantSpell = IsDistantSpell,
            IsMeleeSpell = IsMeleeSpell,
            ManaCost = ManaCost,
            Type = Type,
            StarDieEffect = StarDieEffect,
            Dice = Dice.Select(d => d.ToDomain()).ToList(),
            Effects = Effects.Select(e => e.ToDomain()).ToList()
        };
}
