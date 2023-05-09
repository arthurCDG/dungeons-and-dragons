namespace dnd_domain.Items.Models;

public class StoredItem
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int Level { get; set; }
    public int HeroId { get; set; }
    public bool IsEquiped { get; set; } = false;
}
