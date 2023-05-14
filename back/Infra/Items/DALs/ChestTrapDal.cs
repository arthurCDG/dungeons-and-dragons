using dnd_domain.Items.Models;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal sealed class ChestTrapDal : ItemDal
{
    public List<ChestTrapEffectDal> Effects { get; set; } = new();

    public ChestTrap ToDomain()
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Description = Description,
            Explanation = Explanation,
            ImageUrl = ImageUrl,
            Level = Level,
            Name = Name,
            Effects = Effects.Select(e => e.ToDomain()).ToList()
        };
}