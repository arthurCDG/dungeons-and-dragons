namespace dnd_infra.Items.DALs;

internal sealed class ChestTrapEffectDal
{
    public int Id { get; set; }
    public int ChestTrapId { get; set; }

    public int? DecreaseAllCreaturesLifePoints { get; set; }
    public int? IncreaseAllMonstersLifePoints { get; set; }
    public int? DecreaseHeroLifePoints { get; set; }
    public int? DecreaseRandomMonsterLifePoints { get; set; }
    public int? DecreaseHeroManaPoints { get; set; }
    public int? DecreaseHeroNearByLifePoints { get; set; }

    public bool? Lose5LifePointsOrRandomHeroLoses3LifePoints { get; set; }
    public bool? ReviveLastDeadMonster { get; set; }
    public bool? SkipNextTurn { get; set; }
    public bool? AttackRandomHeroNearBy { get; set; }
    public bool? MoveToRandomHero { get; set; }
    public bool? DoesNotAffectLivingCreatures { get; set; }
    public bool? DoesNotAffectUndeads { get; set; }
    public bool? DoesNotAffectHeroes { get; set; }
    public bool? DoesNotAffectMonsters { get; set; }
}
