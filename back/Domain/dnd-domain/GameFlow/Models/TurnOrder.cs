namespace dnd_domain.GameFlow.Models;

public class TurnOrder
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int AdventureId { get; set; }
    public int Order { get; set; }
}
