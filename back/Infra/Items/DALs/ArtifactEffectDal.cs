using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;

namespace dnd_infra.Items.DALs;

internal sealed class ArtifactEffectDal
{
    public int Id { get; set; }
    public int ArtifactId { get; set; }
    public ArtifactEffectType Effect { get; set; }

    public ArtifactEffect ToDomain()
        => new()
        {
            Id = Id,
            ArtifactId = ArtifactId,
            Effect = Effect
        };
}
