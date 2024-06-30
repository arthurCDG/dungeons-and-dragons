using dnd_domain.Players.Enums;

namespace dnd_domain.Players.Payloads;

public class AttackPayload
{
    public int AttackerId { get; set; }
    public int ReceiverId { get; set; }
    public AttackType Type { get; set; }
}
