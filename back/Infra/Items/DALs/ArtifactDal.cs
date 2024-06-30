using dnd_domain.Items.Models;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal sealed class ArtifactDal : ItemDal
{
    public Artifact ToDomain()
        => new()
        {
            Id = Id,
            Description = Description,
            Explanation = Explanation,
            ImageUrl = ImageUrl,
            Level = Level,
            Name = Name,
            Effects = Effects.Select(e => e.ToDomain()).ToList()
        };
}