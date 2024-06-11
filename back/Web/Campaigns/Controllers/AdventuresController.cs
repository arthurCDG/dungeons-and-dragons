using dnd_application.Campaigns.Adventures;
using dnd_domain.Campaigns.Adventures;
using dungeons_and_dragons.Campaigns.DTOs;
using dungeons_and_dragons.Campaigns.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[Authorize]
[SwaggerTag("Adventures")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class AdventuresController(IAdventuresService adventuresService, AdventureDtoMapper adventureDtoMapper) : ControllerBase
{
    public const string Route = "api/campaigns/{campaignId}/adventures";

    private readonly IAdventuresService _adventuresService = adventuresService;
    private readonly AdventureDtoMapper _adventureDtoMapper = adventureDtoMapper;

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<AdventureDto> GetByIdAsync(int id)
    {
        Adventure adventure = await _adventuresService.GetByIdAsync(id);
        return await _adventureDtoMapper.ToDtoAsync(adventure);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<AdventureDto> StartAsync(int campaignId, [FromBody] AdventureType adventureType)
    {
        Adventure adventure = await _adventuresService.StartAsync(campaignId, adventureType);
        return await _adventureDtoMapper.ToDtoAsync(adventure);
    }
}
