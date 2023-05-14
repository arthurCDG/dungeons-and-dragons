namespace dnd_domain.Items.Models;

public abstract class Item
{
    public int Id { get; set; }
    public int CampaignId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Level { get; set; }
}
