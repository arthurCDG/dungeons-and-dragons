namespace dnd_infra.Items.DALs;

internal sealed class PotionEffectDal
{
    public int Id { get; set; }
    public int PotionId { get; set; }
    public bool AffectsAllHeroes { get; set; } = false;
    public bool AffectsAllMonsters { get; set; } = false;

    public int? IncreaseLifePoints { get; set; }
    public int? IncreaseManaPoints { get; set; }
    public int? DecreaseMonsterLifePoints { get; set; }
    public int? DecreaseMonsterShieldUntilNextDMTurn { get; set; }
    public int? IncreaseFootSteps { get; set; }
    public bool? ReviveHeroWith4LPAnd4MP {  get; set; }
    public bool? RequiresHeroToBeNearBy {  get; set; }
    public bool? MoveMonsterToChosenSquare {  get; set; }
    public bool? CanAttackImmediatly { get; set; }
    public bool? CanDismissTrapEffect { get; set; }
    public bool? DoublesWeaponStrength { get; set; }
    public bool? DismissesNextTurnOfMonster { get; set; }
    public bool? RerollLastCastDie { get; set; }
}
