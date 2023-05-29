using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;
using dnd_infra.GameFlow.DALs;
using dnd_infra.Items.DALs;
using System.Collections.Generic;
using System.Linq;

namespace dnd_infra.Players.DALs;

internal sealed class HeroDal : PlayerDal
{
    public int SquareId { get; set; }
    public HeroClass Class { get; set; }
    public HeroRace Race { get; set; }
    public TurnOrderDal TurnOrder { get; set; } = null!;
    public ActionsDal Actions { get; set; } = null!;
    public List<StoredItemDal> StoredItems { get; set; } = new();

    public Hero ToDomain()
        => new()
        {
            Id = Id,
            CampaignId = CampaignId,
            Class = Class,
            Race = Race,
            FootSteps = FootSteps,
            ImageUrl = ImageUrl,
            IsDead = IsDead,
            LifePoints = LifePoints,
            ManaPoints = ManaPoints,
            Name = Name,
            Shield = Shield,
            SquareId = SquareId,
            StoredItems = StoredItems.Select(si => si.ToDomain()).ToList(),
        };
}