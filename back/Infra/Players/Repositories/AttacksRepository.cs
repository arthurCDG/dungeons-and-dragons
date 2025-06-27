using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnd_domain.Items.Models;
using dnd_domain.Items.Store;
using dnd_domain.Players.Enums;
using dnd_domain.Players.Models;
using dnd_domain.Players.Payloads;
using dnd_domain.Players.Repositories;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Players.Repositories;

internal sealed class AttacksRepository(GlobalDbContext context) : IAttacksRepository
{
    public async Task<Player> AttackAsync(AttackPayload attackPayload)
    {
        PlayerDal attacker = await context.Players.Include(p => p.Attributes)
                                                   .Include(p => p.StoredItems)    
                                                   .FirstAsync(p => p.Id == attackPayload.AttackerId);

        PlayerDal receiver = await context.Players.Include(p => p.Attributes)
                                                   .Include(p => p.StoredItems)
                                                   .FirstAsync(p => p.Id == attackPayload.ReceiverId);

        int damage = await GetDamageFromAttackerAsync(attacker, attackPayload.Type);
        attacker.Attributes!.AttackCount--;

        int lostLifePoints = ComputeLostLifePoints(damage, receiver.Attributes!.Shield, attackPayload.Type);
        receiver.Attributes.LifePoints -= lostLifePoints;
        if (receiver.Attributes.LifePoints <= 0)
        {
            receiver.Attributes.LifePoints = 0;
            receiver.IsDead = true;
        }
        
        await context.SaveChangesAsync();

        return receiver.ToDomain();
    }

    /**
     * TODO - refacto
     * This method here shows that I should have my items in db and do something like:
     * var equipedWeapon = await _context.StoredItems.Where(si => si.PlayerId == attacker.Id && si.IsEquiped).Include(si => si.Item).Select(si => si.Item).FirstOrDefaultAsync(i => i.Type == ItemType.Weapon);
     */
    private async Task<int> GetDamageFromAttackerAsync(PlayerDal attacker, AttackType attackType)
    {
        HashSet<string> storedItemsIds = await context.StoredItems.Where(si => si.PlayerId == attacker.Id && si.IsEquiped)
                                                                   .Select(si => si.ItemId)
                                                                   .ToHashSetAsync();

        if (attackType == AttackType.Melee || attackType == AttackType.Ranged)
        {
            Weapon? attackWeapon = WeaponsStore.Items.FirstOrDefault(i => storedItemsIds.Contains(i.Id));
            if (attackWeapon is null)
            {
                throw new Exception($"Player does not have an equipped weapon for attack type: {attackType}");
            }
            
            int rawDamage = ComputeDamage(attackWeapon.Attributes.MinimumDamage, attackWeapon.Attributes.MaximumDamage);
            
            if (attackWeapon.Effects.Count > 0)
            {
                // Create (and call) service to handle weapon effects (increased damage, ignored shield, destroyed weapon after use, etc.)
            }
            
            return rawDamage;
        }
        else if (attackType == AttackType.Spell)
        {
            Spell? attackSpell = SpellsStore.Items.FirstOrDefault(i => storedItemsIds.Contains(i.Id));
            if (attackSpell is null)
            {
                throw new Exception($"Player does not have an equipped spell for attack type: {attackType}");
            }
            
            int rawDamage = ComputeDamage(attackSpell.Attributes.MinimumDamage, attackSpell.Attributes.MaximumDamage);
            
            if (attackSpell.Effects.Count > 0)
            {
                // Same, handle effects
            }
            
            return rawDamage;
        }
        

        throw new NotImplementedException();
    }
    
    private static int ComputeDamage(int min, int max)
    {
        return new Random().Next(min, max + 1);
    }

    private static int ComputeLostLifePoints(int damage, int shield, AttackType type)
        => type == AttackType.Spell ? damage : Math.Abs(shield - damage);
}
