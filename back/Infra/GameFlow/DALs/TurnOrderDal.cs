namespace dnd_infra.GameFlow.DALs;

internal sealed class TurnOrderDal
{
    public int Id { get; set; }
    public int Order { get; set; }

    public int? HeroId { get; set; }
    public int? MonsterId { get; set; }
}
