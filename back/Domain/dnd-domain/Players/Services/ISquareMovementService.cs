﻿using dnd_domain.Campaigns.Models;
using dnd_domain.Fields.Models;
using System.Threading.Tasks;

namespace dnd_domain.Players.Services;

public interface ISquareMovementService
{
    Task<Movement> MoveToSquareAsync(MovementRequestPayload movementRequest);
}