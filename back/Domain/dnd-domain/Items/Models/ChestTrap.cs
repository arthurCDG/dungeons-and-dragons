namespace dnd_domain.Items.Models;

public class ChestTrap : Item
{
    public List<ChestTrapEffect> Effects { get; set; } = new();

}
