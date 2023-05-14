using dnd_domain.Players.Enums;
using dnd_infra.Items.DALs;
using System.Collections.Generic;

namespace dnd_infra.Players.DALs;

internal sealed class MonsterDal : PlayerDal
{
    public int SquareId { get; set; }
    public MonsterType Type { get; set; } = new();
    public List<StoredItemDal> StoredItems { get; set; } = new();
}
