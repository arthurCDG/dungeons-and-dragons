using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;

namespace dnd_infra.Items.DALs;

internal sealed class PotionEffectDal
{
    public int Id { get; set; }
    public int PotionId { get; set; }
    public PotionEffectType Effect { get; set; }

    public PotionEffect ToDomain()
        => new()
        {
            Id = Id,
            PotionId = PotionId,
            Effect = Effect
        };
}
