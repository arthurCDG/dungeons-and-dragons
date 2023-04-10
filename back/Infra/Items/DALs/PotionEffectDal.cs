using dnd_domain.Items.Enums;

namespace dnd_infra.Items.DALs;

internal sealed class PotionEffectDal
{
    public int Id { get; set; }
    public int PotionId { get; set; }
    public PotionEffect Effect { get; set; }
}
