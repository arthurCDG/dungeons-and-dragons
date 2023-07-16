using dnd_application.Campaigns;
using dnd_domain.Campaigns.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[SwaggerTag("Campaigns")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class CretableCampaignsServiceController : ControllerBase
{
    public const string Route = "services/players/{playerId}/creatable-campaigns";
    private readonly ICreatableCampaignsService _creatableCampaignsService;

    public CretableCampaignsServiceController(ICreatableCampaignsService creatableCampaignsService)
    {
        _creatableCampaignsService = creatableCampaignsService ?? throw new System.ArgumentNullException(nameof(creatableCampaignsService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<List<CreatableCampaign>> GetAsync(int playerId)
        => _creatableCampaignsService.GetAsync(playerId);
}
