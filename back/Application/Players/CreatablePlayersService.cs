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

    private readonly int _maxCreatablePlayers = 4;
    private static readonly HashSet<Species> _wizardExcludedSpecies = [Species.Dwarf, Species.Human];
    private static readonly HashSet<Species> _clericExcludedSpecies = [Species.Dwarf, Species.Halfling];

    /* Source for players: https://en.wikipedia.org/wiki/Dungeons_%26_Dragons_iconic_characters */

    public CreatablePlayersService(IPlayersRepository playersRepository)
    {
        _playersRepository = playersRepository;
    }

    public async Task<List<CreatablePlayer>> GetAsync(int userId)
    {
        List<Player> alreadyCreatedPlayers = await _playersRepository.GetAsync(userId);
        if (alreadyCreatedPlayers.Count >= _maxCreatablePlayers)
        {
            return [];
        }

       return GetCreatablePlayers();
    }

    private static List<CreatablePlayer> GetCreatablePlayers()
    {
        List<CreatableSpecies> creatableSpecies = GetCreatableSpecies();

        return
        [
            new CreatablePlayer
            {
                AssociatedSpecies = creatableSpecies,
                Class = new()
                {
                    Type = Class.Warrior,
                    LokalisedClassName = "Guerrier"
                },
                Description = "Un guerrier est un combattant qui est fort et résistant. Il est capable de porter une armure lourde et de manier des armes puissantes. Les guerriers sont souvent les premiers à entrer dans la bataille et les derniers à en sortir. Ils sont courageux et déterminés, et ils sont prêts à risquer leur vie pour protéger leurs amis et leur famille.",
                MaxAttributes = PlayersAttributesHelper.WarriorLevel1MaxAttributes
            },

            new CreatablePlayer
            {
                AssociatedSpecies = creatableSpecies,
                Class = new()
                {
                    Type = Class.Rogue,
                    LokalisedClassName = "Voleur"
                },
                Description = "Un voleur est un personnage rusé et agile qui se déplace furtivement et utilise des compétences spéciales pour voler, espionner et saboter. Les voleurs sont souvent des marginaux et des hors-la-loi, mais ils peuvent aussi être des héros et des aventuriers. Ils sont habiles dans le combat au corps à corps et à distance, et ils sont capables de se faufiler dans les endroits les plus sécurisés.",
                MaxAttributes = PlayersAttributesHelper.RogueLevel1MaxAttributes
            },

            new CreatablePlayer
            {
                AssociatedSpecies = creatableSpecies.Where(cs => _clericExcludedSpecies.Contains(cs.Type)).ToList(),
                Class = new()
                {
                    Type = Class.Cleric,
                    LokalisedClassName = "Clerc"
                },
                Description = "Un clerc est un personnage qui sert une divinité et qui est capable de lancer des sorts divins. Les clercs sont des guérisseurs et des protecteurs, et ils sont souvent les leaders spirituels de leur communauté. Ils portent des symboles religieux et des armures légères, et ils sont capables de canaliser l'énergie divine pour guérir les blessures et repousser les morts-vivants.",
                MaxAttributes = PlayersAttributesHelper.ClericLevel1MaxAttributes
            },

            new CreatablePlayer
            {
                AssociatedSpecies= creatableSpecies.Where(cs => _wizardExcludedSpecies.Contains(cs.Type)).ToList(),
                Class = new()
                {
                    Type = Class.Wizard,
                    LokalisedClassName = "Magicien"
                },
                Description = "Un magicien est un personnage qui pratique la magie et qui est capable de lancer des sorts puissants. Les magiciens étudient les arts mystiques et les sciences occultes, et ils sont capables de manipuler les forces de la nature pour accomplir des exploits incroyables. Ils portent des vêtements légers, et ils sont souvent accompagnés de familiers magiques.",
                MaxAttributes = PlayersAttributesHelper.WizardLevel1MaxAttributes
            }
        ];
    }

    private static List<CreatableSpecies> GetCreatableSpecies()
        => new()
        {
            new CreatableSpecies
            {
                Type = Species.Dwarf,
                LokalisedSpeciesName = "Nain"
            },
            new CreatableSpecies
            {
                Type = Species.Elf,
                LokalisedSpeciesName = "Elfe"
            },
            new CreatableSpecies
            {
                Type = Species.Halfling,
                LokalisedSpeciesName = "Halfelin"
            },
            new CreatableSpecies
            {
                Type = Species.Human,
                LokalisedSpeciesName = "Humain"
            }
        };
}
