namespace dnd_infra.GameFlow.DALs;

internal sealed class ActionsDal
{
    public int Id { get; set; }
    public int RemainingFootSteps { get; set; }
    public int RemainingAttacks { get; set; }
    public int RemainingHeals { get; set; }
    public int RemainingChestSearch { get; set; }
    public int RemainingTrapSearch { get; set; }

    public int? HeroId { get; set; }
    public int? MonsterId { get; set; }
}
