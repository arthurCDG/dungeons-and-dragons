using dnd_domain.Campaigns.Models;
using dnd_services.Campaigns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[SwaggerTag("Campaigns")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
public class CampaignsController : ControllerBase
{
    public const string Route = "api/sessions/{sessionId}/campaigns";

    private readonly ICampaignsService _campaignsService;

    public CampaignsController(ICampaignsService campaignsService)
    {
        _campaignsService = campaignsService ?? throw new System.ArgumentNullException(nameof(campaignsService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<Campaign> GetAsync(int sessionId)
        => _campaignsService.GetAsync(sessionId);

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task PostAsync(int sessionId, [FromBody] CampaignPayload campaignPayload)
        => _campaignsService.CreateAsync(sessionId, campaignPayload);
}
