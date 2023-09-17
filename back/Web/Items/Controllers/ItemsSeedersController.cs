using dnd_domain.Items.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Items.Controllers;

[Authorize]
[SwaggerTag("Seed")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class ItemsSeedersController : ControllerBase
{
    public const string Route = "services/seed/items";
    private readonly IItemsSeederService _itemsSeederService;

    public ItemsSeedersController(IItemsSeederService itemsSeederService)
    {
        _itemsSeederService = itemsSeederService ?? throw new System.ArgumentNullException(nameof(itemsSeederService));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task SeedAsync()
        => _itemsSeederService.SeedAsync();
}
