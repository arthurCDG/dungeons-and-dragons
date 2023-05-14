using dnd_domain.Campaigns;
using dnd_services.Campaigns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Controllers;

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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task PostAsync(int sessionId, [FromBody] CampaignPayload campaignPayload)
        => _campaignsService.CreateAsync(sessionId, campaignPayload);
}
