namespace dnd_domain.Campaigns.Adventures;

public class CreatableAdventure
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public AdventureType Type { get; set; }
    public bool CanBeStarted { get; set; } = false;
}
