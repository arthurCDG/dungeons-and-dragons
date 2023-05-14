using System;

namespace dnd_infra.Sessions;

internal sealed class SessionDal
{
    public int Id { get; set; }
    public DateTime StartsAt { get; set; }
    public DateTime? EndsAt { get; set; }
    // This class will hold users
}
