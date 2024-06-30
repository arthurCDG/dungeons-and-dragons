using dnd_domain.Items.Models;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Items.DALs;

internal sealed class PotionDal : ItemDal
{
    public Potion ToDomain()
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
