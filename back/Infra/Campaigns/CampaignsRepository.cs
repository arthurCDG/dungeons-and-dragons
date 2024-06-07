using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_infra.Campaigns;

internal sealed class CampaignsRepository : ICampaignsRepository
{
    private readonly GlobalDbContext _context;

    public CampaignsRepository(GlobalDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<Campaign>> GetAsync(int playerId)
    {
        List<CampaignDal> campaigns = await _context.Campaigns
            .Include(c => c.Players)
                .ThenInclude(p => p.Profile)
            .Include(c => c.Players)
                .ThenInclude(p => p.MaxAttributes)
            .Where(c => c.Players.Any(p => p.Id == playerId))
            .ToListAsync();

        return campaigns.ConvertAll(c => c.ToDomain());
    }

    public async Task<Campaign> GetByIdAsync(int campaignId)
    {
        CampaignDal dal = await _context.Campaigns
            .Include(c => c.Players)
                .ThenInclude(p => p.StoredItems)
            .Include(c => c.Players)
                .ThenInclude(p => p.Profile)
            .Include(c => c.Players)
                .ThenInclude(p => p.MaxAttributes)
            .Include(c => c.Adventures)
                .ThenInclude(a => a.Rooms)
                    .ThenInclude(r => r.Squares)
                        .ThenInclude(s => s.Position)
            .SingleAsync(c => c.Id == campaignId);

        return dal.ToDomain();
    }

    public Task<Campaign> GetFromAdventureAsync(int adventureId)
        => _context.Campaigns
            .Include(c => c.Players)
                .ThenInclude(p => p.Profile)
            .Include(c => c.Players)
                .ThenInclude(p => p.MaxAttributes)
            .Where(c => c.Adventures.Any(a => a.Id == adventureId))
            .Select(c => c.ToDomain())
            .SingleAsync();


    public async Task<Campaign> CreateAsync(CampaignPayload campaignPayload)
    {
        try
        {
            CampaignDal campaign = new()
            {
                Name = GetCampaignName(campaignPayload.Type),
                Description = GetCampaignDescription(campaignPayload.Type),
                Type = campaignPayload.Type,
                StartsAt = DateTime.UtcNow,
            };

            _context.Campaigns.Add(campaign);
            await _context.SaveChangesAsync();

            if (campaignPayload.DungeonMasterId.HasValue)
            {
                campaign.DungeonMasterId = campaignPayload.DungeonMasterId.Value;
            }

            List<PlayerDal> players = await _context.Players.Where(p => campaignPayload.PlayerIds.Contains(p.Id)).ToListAsync();

            campaign.Players.AddRange(players);
            await _context.SaveChangesAsync();

            return campaign.ToDomain();
        }
        catch (Exception e)
        {
            throw new InvalidProgramException($"Campaign could not be created because of this exception: {e}");
        }
    }

    public async Task UpdatePlayersAsync(int id, CampaignPayload campaignPayload)
    {
        CampaignDal campaign = await _context.Campaigns.SingleAsync(c => c.Id == id);
        List<PlayerDal> players = await _context.Players.Where(p => campaignPayload.PlayerIds.Contains(p.Id)).ToListAsync();
        
        campaign.Players.AddRange(players);
        await _context.SaveChangesAsync();
    }

    private static string GetCampaignName(CampaignType type)
        => type switch
        {
            CampaignType.HollbrooksLiberation => "La libération de Hollbrooks", // TODO lokalise name
            CampaignType.InpursuitOfTheDarkArmy => "A la poursuite de l'armée sombre", // TODO lokalise name
            CampaignType.WrathOfTheLich => "La colère de la liche", // TODO lokalise name
            _ => throw new ArgumentException($"Unknown campaign type: {type}.")
        };

    private static string GetCampaignDescription(CampaignType type)
        => type switch
        {
            CampaignType.HollbrooksLiberation => "Heroes will try to save the village of Hollbrooks from an unknown evil.",
            CampaignType.InpursuitOfTheDarkArmy => "Heroes managed to push back evil but still need to investigate what it was and find its source.",
            CampaignType.WrathOfTheLich => "Heroes understood the source of evil is the Lich King. They will hunt it.",
            _ => throw new ArgumentException($"Unknown campaign type: {type}.")
        };
}
