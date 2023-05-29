using dnd_domain.GameFlow.Models;

namespace dnd_infra.GameFlow.DALs;

internal sealed class CurrentPlayerDal
{
    public int Id { get; set; }
    public int CampaignId { get; set; }

    public int? HeroId { get; set; }
    public int? MonsterId { get; set; }

    public CurrentPlayer ToDomain()
        => new()
        {
            CampaignId = CampaignId,
            HeroId = HeroId,
            MonsterId = MonsterId
        };
}
