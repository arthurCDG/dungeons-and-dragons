using dnd_application.Campaigns.Adventures;
using dnd_domain.Campaigns.Adventures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[Authorize]
[SwaggerTag("Adventures")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class CreatableAdventuresServiceController : ControllerBase
{
    public const string Route = "services/campaigns/{campaignId}/creatable-adventures";
    private readonly ICreatableAdventuresService _creatableAdventuresService;

    public CreatableAdventuresServiceController(ICreatableAdventuresService creatableAdventuresService)
    {
        _creatableAdventuresService = creatableAdventuresService ?? throw new ArgumentNullException(nameof(creatableAdventuresService));
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<List<CreatableAdventure>> GetAsync(int campaignId)
        => _creatableAdventuresService.GetAsync(campaignId);
}
