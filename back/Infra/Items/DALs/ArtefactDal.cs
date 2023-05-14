using dnd_domain.Items.Models;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal sealed class ArtefactDal : ItemDal
{
    public bool DiscardAfterUsage { get; set; }
    public bool? CastDieToDiscardAfterUsage { get; set; }

    public List<ArtefactEffectDal> Effects { get; set; } = new();

    public Artefact ToDomain()
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
            CastDieToDiscardAfterUsage = CastDieToDiscardAfterUsage,
            Effects = Effects.Select(e => e.ToDomain()).ToList()
        };
}