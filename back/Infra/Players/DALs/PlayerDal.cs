using dnd_domain.Players.Models;
using dnd_infra.Campaigns;
using dnd_infra.GameFlow.DALs;
using dnd_infra.Items.DALs;
using System.Collections.Generic;

namespace dnd_infra.Players.DALs;

internal sealed class PlayerDal
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public bool IsDead { get; set; } = false;
    public int SquareId { get; set; }

    public PlayerProfileDal Profile { get; set; } = null!;
    public PlayerAttributesDal Attributes { get; set; } = null!;
    public PlayerMaxAttributesDal MaxAttributes { get; set; } = null!;
    public TurnOrderDal TurnOrder { get; set; } = null!;

    public List<CampaignDal> Campaigns { get; set; } = new();
    public List<StoredItemDal> StoredItems { get; set; } = new();

    public Player ToDomain()
        => new()
        {
            Id = Id,
            UserId = UserId,
            SquareId = SquareId,
            IsDead = IsDead,
            Profile = Profile.ToDomain(),
            Attributes = Attributes.ToDomain(),
            MaxAttributes = MaxAttributes.ToDomain(),
            TurnOrder = TurnOrder.ToDomain(),
            Campaigns = Campaigns.ConvertAll(c => c.ToDomain()),
            StoredItems = StoredItems.ConvertAll(si => si.ToDomain())
        };
}
