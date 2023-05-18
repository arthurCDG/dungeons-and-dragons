using dnd_domain.Campaigns.Models;
using dnd_services.Campaigns;
using dungeons_and_dragons.Campaigns.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[SwaggerTag("Campaigns")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class CampaignsController : ControllerBase
{
    public const string Route = "api/sessions/{sessionId}/campaigns";

    private readonly ICampaignsService _campaignsService;

    public CampaignsController(ICampaignsService campaignsService)
    {
        _campaignsService = campaignsService ?? throw new System.ArgumentNullException(nameof(campaignsService));
    }

    [HttpGet("{campaignId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<CampaignDto> GetAsync(int sessionId, int campaignId)
    {
        Campaign campaign = await _campaignsService.GetAsync(sessionId, campaignId);
        return CampaignDto.FromDomain(campaign);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task PostAsync(int sessionId, [FromBody] CampaignPayload campaignPayload)
        => _campaignsService.CreateAsync(sessionId, campaignPayload);
}
