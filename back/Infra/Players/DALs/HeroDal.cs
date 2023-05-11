using dnd_domain.Players.Enums;
using dnd_infra.Items.DALs;
using System.Collections.Generic;

namespace dnd_infra.Players.DALs;

internal sealed class HeroDal : PlayerDal
{
    public HeroClass Class { get; set; }
    public HeroRace Race { get; set; }
    public List<StoredItemDal> StoredItems { get; set; } = new();
}