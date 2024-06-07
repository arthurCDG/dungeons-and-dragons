using dnd_domain.Items.Enums;

namespace dnd_domain.Items.Models;

public class ArtifactEffect
{
    public int Id { get; set; }
    public int ArtifactId { get; set; }
    public ArtifactEffectType Effect { get; set; } = new();
}
