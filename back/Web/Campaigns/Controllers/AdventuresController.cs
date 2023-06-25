using dnd_application.Campaigns.Adventures;
using dnd_domain.Campaigns.Models;
using dungeons_and_dragons.Campaigns.DTOs;
using dungeons_and_dragons.Campaigns.Mappers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[SwaggerTag("Adventures")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class AdventuresController : ControllerBase
{
    public const string Route = "api/campaigns/{campaignId}/adventures";
    private readonly IAdventuresService _adventuresService;
    private readonly AdventureDtoMapper _adventureDtoMapper;

    public AdventuresController(IAdventuresService adventuresService, AdventureDtoMapper adventureDtoMapper)
    {
        _adventuresService = adventuresService ?? throw new System.ArgumentNullException(nameof(adventuresService));
        _adventureDtoMapper = adventureDtoMapper ?? throw new System.ArgumentNullException(nameof(adventureDtoMapper));
    }


    [HttpPost("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<AdventureDto> StartAsync(int campaignId, int id)
    {
        Adventure adventure = await _adventuresService.StartAsync(campaignId, id);
        return await _adventureDtoMapper.ToDtoAsync(adventure);
    }
}
