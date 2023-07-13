using dnd_domain.Players.Enums;
using dnd_domain.Players.Helpers;
using dnd_domain.Players.Models;
using dnd_domain.Players.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_application.Players;

internal sealed class CreatablePlayersService : ICreatablePlayersService
{
    private readonly IPlayersRepository _playersRepository;

    /* Source for players: https://en.wikipedia.org/wiki/Dungeons_%26_Dragons_iconic_characters */

    public CreatablePlayersService(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository ?? throw new System.ArgumentNullException(nameof(playersRepository));
    }

    public async Task<List<CreatablePlayer>> GetAsync(int userId)
    {
        List<CreatablePlayer> creatablePlayers = GetCreatablePlayers();
        
        List<Player> alreadyCreatedPlayers = await _playersRepository.GetAsync(userId);
        creatablePlayers.RemoveAll(cp => alreadyCreatedPlayers.Any(acp => acp.Profile.FirstName == cp.FirstName));

        // TODO Remove players that are not unlocked by the user (based on adventures and campaigns done for now - later on some more precise achievements and logic)
        
        return creatablePlayers;
    }

    private static List<CreatablePlayer> GetCreatablePlayers()
        => new()
        {
            // Regdar
            new CreatablePlayer
            {
                FirstName = "Regdar",
                LastName = string.Empty,
                Description = "Regdar est un guerrier humain qui a passé sa vie à se battre pour ce qu'il croit être juste. Il est grand et musclé, avec des cheveux noirs et des yeux bruns. Il porte une armure de plaques et une épée longue, et il est toujours prêt à se battre pour ce qu'il croit être juste.",
                Type = PlayerType.Regdar,
                MaxAttributes = PlayersAttributesHelper.RegdarLevel1MaxAttributes
            },
            // Lidda
            new CreatablePlayer
            {
                FirstName = "Lidda",
                LastName = string.Empty,
                Description = "Lidda est une voleuse gnome extrêmement rusée. Sa phrase préférée : 'Les petites choses peuvent être féroces'.",
                Type = PlayerType.Lidda,
                MaxAttributes = PlayersAttributesHelper.LiddaLevel1MaxAttributes
            },
            // Jozan
            new CreatablePlayer
            {
                FirstName = "Jozan",
                LastName = string.Empty,
                Description = "Jozan est un prêtre humain qui a passé sa vie à servir les dieux. Il est grand et mince, avec des cheveux noirs et des yeux bruns. Il porte une armure de plaques et une masse de guerre, et il est toujours prêt à servir les dieux.",
                Type = PlayerType.Jozan,
                MaxAttributes = PlayersAttributesHelper.JozanLevel1MaxAttributes
            },
            // Mialye
            new CreatablePlayer
            {
                FirstName = "Mialye",
                LastName = string.Empty,
                Description = "Mialye est une magicienne elfe qui a passé sa vie à étudier la magie. Elle est grande et mince, avec des cheveux noirs et des yeux bruns. Elle porte une robe de mage et un bâton de mage, et elle est toujours prête à lancer des sorts.",
                Type = PlayerType.Mialye,
                MaxAttributes = PlayersAttributesHelper.MialyeLevel1MaxAttributes
            }
        };
}
