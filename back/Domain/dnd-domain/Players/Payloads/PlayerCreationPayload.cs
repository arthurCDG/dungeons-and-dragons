﻿using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Payloads;

public class PlayerCreationPayload
{
    public required Class Class { get; set; }
    public required PlayerGender Gender { get; set; }
    public required string Name { get; set; }
    public required Species Species { get; set; }
}
