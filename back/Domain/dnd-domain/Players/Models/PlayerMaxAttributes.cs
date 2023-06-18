namespace dnd_domain.Players.Models;

public class PlayerMaxAttributes
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int MaxLifePoints { get; set; }
    public int MaxManaPoints { get; set; }
    public int MaxFootSteps { get; set; }
    public int MaxShield { get; set; }
    public int MaxAttackCount { get; set; }
    public int MaxHealCount { get; set; }
    public int MaxChestSearchCount { get; set; }
    public int MaxTrapSearchCount { get; set; }
}
