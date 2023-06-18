namespace dnd_domain.Users;

public class UserCampaignAssociation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int CampaignId { get; set; }
}
