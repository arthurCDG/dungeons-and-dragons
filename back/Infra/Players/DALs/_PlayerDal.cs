namespace dnd_infra.Players.DALs;

internal abstract class PlayerDal
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

    public int MaxAttackCount { get; set; }
    public int MaxHealCount { get; set; }
    public int MaxFootStepsCount { get; set; }
    public int MaxChestSearchCount { get; set; }
    public int MaxTrapSearchCount { get; set; }
}
