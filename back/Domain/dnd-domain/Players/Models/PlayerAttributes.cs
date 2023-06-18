namespace dnd_domain.Players.Models;

public class PlayerAttributes
{
    public int Id { get; set; }
    public int PlayerId { get; set; }
    public int LifePoints { get; set; }
    public int ManaPoints { get; set; }
    public int FootSteps { get; set; }
    public int Shield { get; set; }
    public int AttackCount { get; set; }
    public int HealCount { get; set; }
    public int ChestSearchCount { get; set; }
    public int TrapSearchCount { get; set; }
}
