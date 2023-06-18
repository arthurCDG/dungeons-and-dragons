using dnd_domain.Items.Models;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal sealed class ArtefactDal : ItemDal
{
    public List<ArtefactEffectDal> Effects { get; set; } = new();

    public Artefact ToDomain()
        => new()
        {
            Id = Id,
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