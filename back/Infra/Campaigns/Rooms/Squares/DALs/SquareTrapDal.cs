﻿using dnd_domain.Boards.Enums;
using dnd_domain.Campaigns.Models;

namespace dnd_infra.Campaigns.Rooms.Squares.DALs;

internal sealed class SquareTrapDal
{
    public int Id { get; set; }
    public int SquareId { get; set; }
    public SquareTrapType Type { get; set; }

    public SquareTrap ToDomain()
        => new()
        {
            Id = Id,
            SquareId = SquareId,
            Type = Type
        };
}