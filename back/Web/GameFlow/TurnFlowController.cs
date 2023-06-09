﻿using dnd_application.GameFlow;
using dnd_domain.GameFlow.Models;
using dungeons_and_dragons.GameFlow;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace dungeons_and_dragons.Campaigns.Controllers;

[SwaggerTag("GameFlow")]
[ApiExplorerSettings(IgnoreApi = false)]
[ApiController, Route(Route)]
[EnableCors]
public class TurnFlowController : ControllerBase
{
    public const string Route = "api/campaigns/{campaignId}";
    private readonly ITurnFlowService _turnFlowService;

    public TurnFlowController(ITurnFlowService turnFlowService)
    {
        _turnFlowService = turnFlowService ?? throw new System.ArgumentNullException(nameof(turnFlowService));
    }

    [HttpGet("current-player")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<CurrentPlayerDto> GetCurrentPlayer(int campaignId)
    {
        CurrentPlayer currentPlayer = await _turnFlowService.GetCurrentPlayerAsync(campaignId);
        return CurrentPlayerDto.FromDomain(currentPlayer);
    }

    [HttpGet("next-player")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<CurrentPlayerDto> GetNextPlayer(int campaignId)
    {
        CurrentPlayer currentPlayer = await _turnFlowService.GetNextCurrentPlayerAsync(campaignId);
        return CurrentPlayerDto.FromDomain(currentPlayer);
    }

    [HttpPost("enable-current-player")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public Task EnableCurrentPlayer(int campaignId)
        => _turnFlowService.EnableCurrentPlayerAsync(campaignId);
}
