using dnd_domain.Items.Models;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal sealed class ArtifactDal : ItemDal
{
    public List<ArtifactEffectDal> Effects { get; set; } = new();

    public Artifact ToDomain()
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