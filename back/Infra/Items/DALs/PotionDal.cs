using System.Collections.Generic;

namespace dnd_infra.Items.DALs;

internal sealed class PotionDal : BaseItemDal
{
    public List<PotionEffectDal> Effects { get; set; } = new();
}
