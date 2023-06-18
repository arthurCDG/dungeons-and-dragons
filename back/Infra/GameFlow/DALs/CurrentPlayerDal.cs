using dnd_domain.GameFlow.Models;
using dnd_infra.Players.DALs;

namespace dnd_infra.GameFlow.DALs;

internal sealed class CurrentPlayerDal
{
    public int Id { get; set; }
    public int CampaignId { get; set; }

    public int? HeroId { get; set; }
    public HeroDal? Hero { get; set; }
    public int? MonsterId { get; set; }
    public MonsterDal? Monster { get; set; }

    public CurrentPlayer ToDomain()
        => new()
        {
            CampaignId = CampaignId,
            Hero = Hero?.ToDomain(),
            Monster = Monster?.ToDomain(),
        };
}
