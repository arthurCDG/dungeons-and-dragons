﻿using dnd_domain.Fields.Models;
using dnd_domain.Players.Repositories;

namespace dnd_domain.Players.Services;

internal sealed class SquareMovementService : ISquareMovementService
{
    private readonly ISquareMovementRepository _playerMovementRepository;

    public SquareMovementService(ISquareMovementRepository playerMovementRepository)
    {
        _playerMovementRepository = playerMovementRepository ?? throw new ArgumentNullException(nameof(playerMovementRepository));
    }

    public Task MoveToSquareAsync(int heroId, MovementRequestPayload movementRequest)
        => _playerMovementRepository.MoveToSquareAsync(heroId, movementRequest);
}