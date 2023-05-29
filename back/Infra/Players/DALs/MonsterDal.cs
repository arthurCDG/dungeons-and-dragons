using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;
using dnd_infra.GameFlow.DALs;
using dnd_infra.Items.DALs;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Players.DALs;

internal sealed class MonsterDal : PlayerDal
{
    public int SquareId { get; set; }
    public MonsterType Type { get; set; } = new();
    public TurnOrderDal TurnOrder { get; set; } = null!;
    public ActionsDal Actions { get; set; } = null!;
    public List<StoredItemDal> StoredItems { get; set; } = new();

    public Monster ToDomain()
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            FootSteps = FootSteps,
            ImageUrl = ImageUrl,
            IsDead = IsDead,
            LifePoints = LifePoints,
            ManaPoints = ManaPoints,
            Name = Name,
            Shield = Shield,
            SquareId = SquareId,
            Type = Type,
            StoredItems = StoredItems.Select(si => si.ToDomain()).ToList(),
        };
}
