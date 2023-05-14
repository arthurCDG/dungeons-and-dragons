using dnd_domain.Items.Models;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal sealed class PotionDal : ItemDal
{
    public bool DiscardAfterUsage { get; set; }
    public List<PotionEffectDal> Effects { get; set; } = new();

    public Potion ToDomain()
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Description = Description,
            Explanation = Explanation,
            ImageUrl = ImageUrl,
            Level = Level,
            Name = Name,
            DiscardAfterUsage = DiscardAfterUsage,
            Effects = Effects.Select(e => e.ToDomain()).ToList()
        };
}
