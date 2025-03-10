using dnd_domain.Items.Enums;
using dnd_domain.Items.Models;
using System.Collections.Generic;

namespace dnd_domain.Items.Store;

public static class ArtifactsStore
{
    public static IReadOnlyCollection<Item> Items =>
    [
        AmuletOfOlidammara,
        AmuletOfYondalla,
        BarkSkinCape,
        BoccobCape,
        ChaosShield,
        ElvenMirrorShield,
        FortuneOfYondalla,
        OrbOfLucidVision,
        RingOfShadows,
        SummonersHorn
    ];

    public static readonly Artifact AmuletOfOlidammara = new()
    {
        Name = "Amulette d'Olidammara",
        Description = "Elle renferme la sagesse de nombreux anciens.",
        Explanation = "Permet au porteur de chercher des pièges dans la salle.",
        Level = 1,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.CanCastTrapFinderDie }
        ],
        IsUnique = true
    };

    public static readonly Artifact AmuletOfYondalla = new()
    {
        Name = "Amulette de Yondalla",
        Description = "Couverte de symboles magiques.",
        Explanation = "Quand vous ouvrez un coffre, vous pouvez garder l'objet trouvé, ou vous en défausser et en choisir un autre.",
        Level = 1,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.CanDiscardChestItemToPickAnotherOne, Amount = 1 },
        ],
        IsUnique = true
    };

    public static readonly Artifact BarkSkinCape = new()
    {
        Name = "Cape en peau d'écorce",
        Description = "Composée de l'écorce des arbres magiques de Arnholm, cette cape légère vous protège.",
        Explanation = "Portez cette cape pour ne pas subir de dégâts lors d'une attaque ou d'un événement. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
        Level = 1,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.DiscardAfterUsage, Probability = 40 },
            new Effect { Type = EffectType.DismissAllAttacks },
        ],
        IsUnique = true
    };

    public static readonly Artifact BoccobCape = new()
    {
        Name = "Cape de Boccob",
        Description = "Les enchantements tissés dans cette cape permettent d'absorber les attaques physiques.",
        Explanation = "Augmente la classe d'armure de 1 pour ce tour. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
        Level = 1,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.DiscardAfterUsage, Probability = 40 },
            new Effect { Type = EffectType.IncreaseShield, Amount = 1 },
        ],
        IsUnique = true
    };

    public static readonly Artifact ChaosShield = new()
    {
        Name = "Bouclier du chaos",
        Description = "Forgé dans un moment de rage par les nains, ce bouclier agit de manière imprévisible.",
        Explanation = "Redirigez les dégâts que vous devez subir sur les points de vie d'un autre héros. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
        Level = 2,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.DiscardAfterUsage, Probability = 40 },
            new Effect { Type = EffectType.AttackReflectsBackToAttacker },
        ],
        IsUnique = true
    };

    public static readonly Artifact ElvenMirrorShield = new()
    {
        Name = "Bouclier miroir elfe",
        Description = "Découvert au fond d'une fontaine elfe, il réfléchit l'image de tout ce qu'il voit.",
        Explanation = "L'attaquant subit les dégâts du jet de dé à votre place. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
        Level = 3,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.DiscardAfterUsage, Probability = 40 },
            new Effect { Type = EffectType.AttackReflectsBackToAttacker },
        ],
        IsUnique = true
    };

    public static readonly Artifact FortuneOfYondalla = new()
    {
        Name = "Fortune de Yondalla",
        Description = "Des runes de protection sont serties dans sa pierre.",
        Explanation = "Quand vous ouvrez un coffre, vous avez le choix entre 4 objets. Choisissez en deux que vous gardez. Par ailleurs, les pièges ne vous infligent pas de dégât. Après avoir fait votre choix, lancez le dé de hasard pour savoir si vous gardez ou non l'artefact.",
        Level = 3,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.DiscardAfterUsage, Probability = 40 },
            new Effect { Type = EffectType.PicksTwoOutOfFourChestItems },
            new Effect { Type = EffectType.NotAffectedByTrapsWhilePickingChestItems }
        ],
        IsUnique = true
    };

    public static readonly Artifact OrbOfLucidVision = new()
    {
        Name = "Orbe de vision lucide",
        Description = "Il appartenait autrefois à de sages seigneurs à qui il offrait ses dons de vision.",
        Explanation = "Révelez tous les pièges dans la pièce. L'artefact disparaît après son utilisation.",
        Level = 1,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.DiscardAfterUsage },
            new Effect { Type = EffectType.RevealRoomTraps }
        ],
        IsUnique = true
    };

    public static readonly Artifact RingOfShadows = new()
    {
        Name = "Anneau des ombres",
        Description = "Passez cet anneau à votre doigt pour disparaître dans les ténèbres du donjon.",
        Explanation = "Déplacez vous où vous le désirez dans la pièce sans être détecté. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
        Level = 1,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.DiscardAfterUsage, Probability = 40 },
            new Effect { Type = EffectType.IsUndetectableInNextRound },
        ],
        IsUnique = true
    };

    public static readonly Artifact SummonersHorn = new()
    {
        Name = "Cor de l'invocateur",
        Description = "Soufflez fort pour appeler de l'aide.",
        Explanation = "Déplacez n'importe quel héros sur une case près de vous. Lancez ensuite le dé de hasard pour savoir si vous gardez ou non l'artefact.",
        Level = 1,
        Type = ItemType.Artifact,
        Effects =
        [
            new Effect { Type = EffectType.DiscardAfterUsage, Probability = 40 },
            new Effect { Type = EffectType.CanInvokeHeroNearBy, Amount = 1 },
        ],
        IsUnique = true
    };
}
