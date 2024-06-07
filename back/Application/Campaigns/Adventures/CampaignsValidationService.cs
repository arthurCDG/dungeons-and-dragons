using dnd_domain.Campaigns;
using dnd_domain.Campaigns.Enums;
using dnd_domain.Campaigns.Models;
using dnd_domain.Players.Repositories;
using dnd_domain.Users;
using FluentResults;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures;

internal sealed class CampaignsValidationService
(
    ICampaignsRepository campaignsRepository,
    IPlayersRepository playersRepository,
    IUsersRepository usersRepository
)
{
    private readonly ICampaignsRepository _campaignsRepository = campaignsRepository;
    private readonly IPlayersRepository _playersRepository = playersRepository;
    private readonly IUsersRepository _usersRepository = usersRepository;

    public async Task<Result> ValidateCampaignCreationPayloadAsync(CampaignPayload campaignPayload)
    {
        if (!Enum.IsDefined(typeof(CampaignType), campaignPayload.Type))
            return new Result().WithError($"Invalid campaign type : {campaignPayload.Type}.");

        if (campaignPayload.DungeonMasterId is not null && !await _usersRepository.ExistsAsync(campaignPayload.DungeonMasterId.Value))
            return new Result().WithError($"Dungeon master Id is not a valid userId: {campaignPayload.DungeonMasterId}.");

        if (campaignPayload.PlayerIds.Count == 0)
            return new Result().WithError("No player ids provided.");

        if (campaignPayload.PlayerIds.Any(playerId => !_playersRepository.ExistsAsync(playerId).Result))
            return new Result().WithError("One or more player ids are invalid.");

        if (!await _playersRepository.AreAvailableAsync(campaignPayload.PlayerIds))
            return new Result().WithError("One or more players are already in a campaign or are not available for a new campaign.");

        return new Result();
    }
}
