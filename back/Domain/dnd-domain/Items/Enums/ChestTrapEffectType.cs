namespace dnd_domain.Items.Enums;

public enum ChestTrapEffectType
{
    DecreaseAllCreaturesLifePointsBy1,
    DecreaseAllCreaturesLifePointsBy2,
    DecreaseAllCreaturesLifePointsBy3,

    IncreaseAllMonstersLifePointsBy1,
    IncreaseAllMonstersLifePointsBy2,
    IncreaseAllMonstersLifePointsBy3,

    DecreaseHeroLifePointsBy1,
    DecreaseHeroLifePointsBy2,
    DecreaseHeroLifePointsBy3,
    DecreaseHeroLifePointsBy4,
    DecreaseHeroLifePointsBy5,

    DecreaseRandomMonsterLifePointsBy1,
    DecreaseRandomMonsterLifePointsBy2,
    DecreaseRandomMonsterLifePointsBy3,

    DecreaseHeroManaPointsBy1,
    DecreaseHeroManaPointsBy2,
    DecreaseHeroManaPointsBy3,
    DecreaseHeroManaPointsBy4,
    DecreaseHeroManaPointsBy5,

    DecreaseHeroNearByLifePointsBy1,
    DecreaseHeroNearByLifePointsBy2,
    DecreaseHeroNearByLifePointsBy3,

    Lose5LifePointsOrRandomHeroLoses3LifePoints,
    ReviveLastDeadMonster,
    SkipNextTurn,
    AttackRandomHeroNearBy,
    MoveToRandomHero,
    DoesNotAffectLivingCreatures,
    DoesNotAffectUndeads,
    DoesNotAffectHeroes,
    DoesNotAffectMonsters
}