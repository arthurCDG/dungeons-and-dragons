using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using dnd_domain.Players.Repositories;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace dnd_infra.Players.Repositories;

internal sealed class AttacksRepository(GlobalDbContext context) : IAttacksRepository
{
    private readonly GlobalDbContext _context = context;

    public async Task<Player> AttackAsync(AttackPayload attackPayload)
    {
        PlayerDal attacker = await _context.Players.Include(p => p.Attributes)
                                                   .Include(p => p.StoredItems)    
                                                   .FirstAsync(p => p.Id == attackPayload.AttackerId);

        PlayerDal receiver = await _context.Players.Include(p => p.Attributes)
                                                   .Include(p => p.StoredItems)
                                                   .FirstAsync(p => p.Id == attackPayload.ReceiverId);

        int damage = GetDamageFromAttacker(attacker, attackPayload.Type);
        attacker.Attributes!.AttackCount--;

        int lostLifePoints = ComputeLostLifePoints(damage, receiver.Attributes!.Shield, attackPayload.Type);
        receiver.Attributes.LifePoints -= lostLifePoints;
        if (receiver.Attributes.LifePoints <= 0)
        {
            receiver.Attributes.LifePoints = 0;
            receiver.IsDead = true;
        }

        // If weapon has a special effect or a chance to be destroyed, call it now

        await _context.SaveChangesAsync();

        return receiver.ToDomain();
    }

    private int GetDamageFromAttacker(PlayerDal attacker, AttackType attackType)
    {
        // Get equiped Weapon related to attackType

        // Call random service to return a number between min and max of weapon (or spell)

        // Handle special effects for damage

        throw new NotImplementedException();
    }

    private static int ComputeLostLifePoints(int damage, int shield, AttackType type)
        => type == AttackType.Spell ? damage : Math.Abs(shield - damage);
}
