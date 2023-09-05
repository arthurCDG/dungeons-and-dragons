using dnd_domain.GameFlow.Models;
using dnd_domain.GameFlow.Repositories;
using System;
using System.Threading.Tasks;

namespace dnd_application.GameFlow;

internal sealed class TurnFlowService : ITurnFlowService
{
    private readonly ITurnFlowRepository _turnFlowRepository;

    public TurnFlowService(ITurnFlowRepository turnFlowRepository)
    {
        _turnFlowRepository = turnFlowRepository ?? throw new ArgumentNullException(nameof(turnFlowRepository));
    }

    public async Task<bool> IsCurrentPlayerAsync(int campaignId, int playerId)
    {
        CurrentPlayer currentPlayer = await _turnFlowRepository.GetCurrentPlayerAsync(campaignId);
        return currentPlayer.Player.Id == playerId;
    }

    public Task<CurrentPlayer> GetCurrentPlayerAsync(int campaignId)
        => _turnFlowRepository.GetCurrentPlayerAsync(campaignId);

    public Task<CurrentPlayer> GetNextCurrentPlayerAsync(int campaignId)
        => _turnFlowRepository.SetNextCurrentPlayerAsync(campaignId);

    public Task EnableCurrentPlayerAsync(int campaignId)
        => _turnFlowRepository.EnableCurrentPlayerAsync(campaignId);
}
