using dnd_domain.Campaigns.Models;
using dnd_domain.Fields.Models;
using dnd_domain.Players.Repositories;
using System;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services;

internal sealed class SquareMovementService : ISquareMovementService
{
    private readonly ISquareMovementRepository _playerMovementRepository;

    public SquareMovementService(ISquareMovementRepository playerMovementRepository)
    {
        _playerMovementRepository = playerMovementRepository ?? throw new ArgumentNullException(nameof(playerMovementRepository));
    }

    public Task<Movement> MoveToSquareAsync(MovementRequestPayload movementRequest)
        => _playerMovementRepository.MoveToSquareAsync(movementRequest);
}