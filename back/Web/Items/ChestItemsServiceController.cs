using dnd_domain.Items.Models;
using dnd_domain.Items.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Items;

[Authorize]
[SwaggerTag("Chest items")]
[ApiController, Route(Route)]
[EnableCors]
public class ChestItemsServiceController(IChestItemsService chestItemsService) : ControllerBase
{
    public const string Route = "services/chest-items";

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task<StoredItem> GetAsync([FromQuery] int playerId) => chestItemsService.GetAsync(playerId);
}
