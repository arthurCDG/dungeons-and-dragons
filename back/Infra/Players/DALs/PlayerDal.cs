using dnd_domain.Players.Models;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using dnd_infra.GameFlow.DALs;
using dnd_infra.Items;
using System.Collections.Generic;

namespace dnd_infra.Players.DALs;

internal sealed class PlayerDal
{
    public int Id { get; set; }
    public int? CampaignId { get; set; }
    public bool IsAvailable { get; set; } = false;
    public bool IsDead { get; set; } = false;
    public int? SquareId { get; set; }
    public SquareDal? Square { get; set; }
    public int? UserId { get; set; }

    public required PlayerProfileDal Profile { get; set; }
    public required PlayerMaxAttributesDal MaxAttributes { get; set; }
    public PlayerAttributesDal? Attributes { get; set; }
    public TurnOrderDal? TurnOrder { get; set; }

    public List<StoredItemDal> StoredItems { get; set; } = [];

    public Player ToDomain()
        =>  new()
        {
            Id = Id,
            UserId = UserId,
            Square = Square?.ToDomain(),
            CampaignId = CampaignId,
            IsAvailable = IsAvailable,
            IsDead = IsDead,
            Profile = Profile?.ToDomain(),
            Attributes = Attributes?.ToDomain(),
            MaxAttributes = MaxAttributes?.ToDomain(),
            TurnOrder = TurnOrder?.ToDomain(),
            StoredItems = StoredItems.ConvertAll(si => si.ToDomain())
        };
}
