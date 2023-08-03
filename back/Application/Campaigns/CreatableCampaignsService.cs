using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_application.Campaigns;

internal sealed class CreatableCampaignsService : ICreatableCampaignsService
{
    private readonly ICampaignsRepository _campaignsRepository;

    public CreatableCampaignsService(ICampaignsRepository campaignsRepository)
    {
        _campaignsRepository = campaignsRepository ?? throw new System.ArgumentNullException(nameof(campaignsRepository));
    }

    public async Task<List<CreatableCampaign>> GetAsync(int playerId)
    {
        List<CreatableCampaign> creatableCampaigns = new()
        {
            new CreatableCampaign
            {
                Name = "La libération d'Hollbrooks",
                Type = CampaignType.HollbrooksLiberation,
                Description = "Dans cette campagne, les aventuriers vont aider le shérif de la petite ville de Hollbrooks."
            },
            new CreatableCampaign
            {
                Name = "A la poursuite de l'armée des ombres",
                Type = CampaignType.InpursuitOfTheDarkArmy,
                Description = "Dans cette campagne, les aventuriers vont poursuivre leur enquête en se renseignant sur l'armée des ombres qui grandit chaque jour."
            },
            new CreatableCampaign
            {
                Name = "La colère de la liche",
                Type = CampaignType.WrathOfTheLich,
                Description = "Dans cette campagne, les aventuriers vont affronter Nécratim, le roi Liche."
            }
        };

        List<Campaign> existingCampaigns = await _campaignsRepository.GetAsync(playerId);

        creatableCampaigns.RemoveAll(cc => existingCampaigns.Any(ec => ec.Type == cc.Type));

        return creatableCampaigns;
    }
}
