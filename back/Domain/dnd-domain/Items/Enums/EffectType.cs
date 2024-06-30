namespace dnd_domain.Items.Enums;

public enum EffectType
{
    None = 0,

    // Artifact effects
    IncreaseLifePoints,
    DecreaseLifePoints,
    IncreaseManaPoints,
    DecreaseManaPoints,
    IncreaseShield,
    DecreaseShield,
    IncreaseDamage,
    DecreaseDamage,
    IncreaseStorage,
    DecreaseStorage,
    IncreaseFootSteps,
    DecreaseFootSteps,

    AttackReflectsBackToAttacker,
    AttackReflectsBackToAnotherHero,
    AttackReflectsBackToRandomTarget,

    CanDiscardChestItemToPickAnotherOne,
    PicksTwoOutOfFourChestItems,
    NotAffectedByTrapsWhilePickingChestItems,

    RevealRoomTraps,
    NotAffectedByTraps,
    CanInvokeHeroNearBy,
    CanCastTrapFinderDie,
    DismissAllAttacks,
    IsUndetectableInNextRound,

    // Chest trap effects

    DecreaseAllPlayersLifePoints,
    IncreaseAllMonstersLifePoints,
    DecreaseHeroLifePoints,
    DecreaseRandomMonsterLifePoints,
    DecreaseHeroManaPoints,
    DecreaseHeroNearByLifePoints,
    Lose5LifePointsOrRandomHeroLoses3LifePoints,
    ReviveLastDeadMonster,
    SkipNextTurn,
    AttackRandomHeroNearBy,
    MoveToRandomHero,
    DoesNotAffectLivingCreatures,
    DoesNotAffectUndeads,
    DoesNotAffectHeroes,
    DoesNotAffectMonsters,

    // Potion effects

    DecreaseMonsterShieldUntilNextDMTurn,
    DecreaseAllMonstersShieldsUntilNextDMTurn,
    DismissesNextTurnOfMonster,
    DismissesNextTurnOfAllMonsters,
    MoveMonsterToChosenSquare,
    IncreaseAllHeroesFootSteps,
    HeroCanAttackImmediatly,
    HeroCanDismissTrapEffect,
    ReviveHeroWith4LPAnd4MP,
    RequiresHeroToBeNearBy,
    DoubleWeaponStrengthForNextAttack,

    // Star die effects 

    IncreaseAllHeroesLifePoints,
    AttackedMonsterPassesHisNextTurn,
    IgnoreMonsterShield,
    NoDamageCaused,
    DoubleHeroAttack,
    DoubleAllHeroesAttacks,
    MoveUndeadToAnySquareInTheRoom,

    // Spell effect

    ReviveAnHeroWith4LifePointsAnd4ManaPoints,
    IncreaseHeroLifePoints,
    MoveMonsterInChosenDirectionByHisNumberOfSteps,
    AllHeroesCanMakeOneStepFreely,
    ProtectsAllHeroesAgainstSpellsAndRangedWeaponsUntilNextDMTurn,

    // Weapon effects
    ProtectsHeroAgainstParalysisWhenUsed,
    IgnoresMonsterShield,
    Costs2ActionPoints,
    IncreasesHeroLifePointsBy1AgainstGnolls
}
