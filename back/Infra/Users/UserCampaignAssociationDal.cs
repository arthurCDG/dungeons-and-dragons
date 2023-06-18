using dnd_domain.Users;

namespace dnd_infra.Users;

internal sealed class UserCampaignAssociationDal
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CampaignId { get; set; }

    public UserCampaignAssociation ToDomain()
        => new()
        {
            Id = Id,
            UserId = UserId,
            CampaignId = CampaignId
        };
}
