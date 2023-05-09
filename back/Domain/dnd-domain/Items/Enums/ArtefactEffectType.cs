namespace dnd_domain.Items.Enums;

public enum ArtefactEffectType
{
    IncreaseHeroLifePointsBy1,
    IncreaseHeroLifePointsBy2,
    IncreaseHeroLifePointsBy3,
    IncreaseHeroLifePointsBy4,
    IncreaseHeroLifePointsBy5,

    DecreaseHeroLifePointsBy1,
    DecreaseHeroLifePointsBy2,
    DecreaseHeroLifePointsBy3,
    DecreaseHeroLifePointsBy4,
    DecreaseHeroLifePointsBy5,

    IncreaseHeroManaPointsBy1,
    IncreaseHeroManaPointsBy2,
    IncreaseHeroManaPointsBy3,
    IncreaseHeroManaPointsBy4,
    IncreaseHeroManaPointsBy5,

    DecreaseHeroManaPointsBy1,
    DecreaseHeroManaPointsBy2,
    DecreaseHeroManaPointsBy3,
    DecreaseHeroManaPointsBy4,
    DecreaseHeroManaPointsBy5,

    IncreaseHeroShieldBy1,
    IncreaseHeroShieldBy2,
    IncreaseHeroShieldBy3,

    DecreaseHeroShieldBy1,
    DecreaseHeroShieldBy2,
    DecreaseHeroShieldBy3,

    IncreaseHeroStorageBy1,
    IncreaseHeroStorageBy2,
    IncreaseHeroStorageBy3,

    DecreaseHeroStorageBy1,
    DecreaseHeroStorageBy2,
    DecreaseHeroStorageBy3,

    IncreaseHeroFootStepsBy1,
    IncreaseHeroFootStepsBy2,
    IncreaseHeroFootStepsBy3,

    DecreaseHeroFootStepsBy1,
    DecreaseHeroFootStepsBy2,
    DecreaseHeroFootStepsBy3,
    
    AttackReflectsBackToAttacker,
    AttackReflectsBackToAnotherHero,
    AttackReflectsBackToRandomTarget,

    CanDiscardChestItemToPickAnotherOneOneTime,
    CanDiscardChestItemToPickAnotherOneTwoTimes,
    CanDiscardChestItemToPickAnotherOneThreeTimes,
    PicksTwoOutOfFourChestItems,
    NotAffectedByTrapsWhilePickingChestItems,

    RerollDice,
    RevealRoomTraps,
    NotAffectedByTraps,
    CanInvokeHeroNearBy,
    CanCastTrapFinderDie,
    DismissAllAttacks,
    IsUndetectableInNextRound,

}
