namespace dnd_domain.Items.Models;

public class StoredItem
{
    public int Id { get; set; }
    public bool IsEquiped { get; set; } = false;
    public required string ItemId { get; set; }
    public required int PlayerId { get; set; }

}
