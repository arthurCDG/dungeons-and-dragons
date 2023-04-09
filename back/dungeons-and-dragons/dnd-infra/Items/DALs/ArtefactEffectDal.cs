namespace dnd_infra.Items.DALs;

internal sealed class ArtefactEffectDal
{
    public int Id { get; set; }
    public int ArtefactId { get; set; }

    public int? LifeIncrease { get; set; }
    public int? LifeDecrease { get; set; }
    public int? ManaIncrease { get; set; }
    public int? ManaDecrease { get; set; }
    public int? ShieldIncrease { get; set; }
    public int? ShieldDecrease { get; set; }
    public int? StorageIncrease { get; set; }
    public int? StorageDecrease { get; set; }
    public int? FootStepsIncrease { get; set; }
    public int? FootStepsDecrease { get; set; }
    public bool? RerollDice { get; set; }
    public bool? RevealRoomTraps { get; set; }
    public bool? NotAffectedByTraps { get; set; }
    public bool? ReflectsBackToAttacker { get; set; }
    public bool? ReflectsBackToAnotherHero { get; set; }
    public bool? ReflectsBackToRandomTarget { get; set; }
    public bool? CanInvokeHeroNearBy { get; set; }
    public bool? CanCastTrapFinderDie { get; set; }
    public bool? DismissAllAttacks { get; set; }
    public bool? IsUndetectableInNextRound { get; set; }
    public bool? PicksTwoOutOfFourChestItems { get; set; }
    public bool? CanDiscardChestItemToPickAnotherOneOneTime { get; set; }
    public bool? CanDiscardChestItemToPickAnotherOneTwoTimes { get; set; }
    public bool? CanDiscardChestItemToPickAnotherOneThreeTimes { get; set; }
    public bool? NotAffectedByTrapsWhilePickingChestItems { get; set; }
}
