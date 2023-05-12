﻿namespace dnd_infra.Players.DALs;

internal abstract class PlayerDal
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int LifePoints { get; set; }
    public int ManaPoints { get; set; }
    public int FootSteps { get; set; }
    public int Shield { get; set; }
    public bool IsDead { get; set; } = false;
}