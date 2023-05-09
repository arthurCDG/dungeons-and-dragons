using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal sealed class PotionDal : ItemDal
{
    public bool DiscardAfterUsage { get; set; }
    public List<PotionEffectDal> Effects { get; set; } = new();
}
