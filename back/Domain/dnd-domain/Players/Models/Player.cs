namespace dnd_domain.Players.Models;

public class Player
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int LifePoints { get; set; }
    public int ManaPoints { get; set; }
    public int FootSteps { get; set; }
    public int Shield { get; set; }
    public bool IsDead { get; set; } = false;
}
