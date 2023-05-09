using dnd_domain.Players.Enums;
using dnd_infra.Items.DALs;
using dnd_infra.Players.DALs;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra.Seeder;

internal static class HeroesSeeder
{
    public static void SeedHeroes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HeroDal>().HasData(
            new HeroDal
            {
                Id = 1,
                Name = "Regdar",
                ImageUrl = "",
                Race = HeroRace.Human,
                Class = HeroClass.Warrior,
                LifePoints = 8,
                ManaPoints = 0,
                Shield = 2,
                FootSteps = 4,
                StoredItems = new()
                {
                    new StoredItemDal { Id = 1, WeaponId = 3, HeroId = 1, IsEquiped = true }
                }
            },
            new HeroDal
            {
                Id = 2,
                Name = "Lidda",
                ImageUrl = "",
                Race = HeroRace.Halfling,
                Class = HeroClass.Rogue,
                LifePoints = 5,
                ManaPoints = 0,
                Shield = 2,
                FootSteps = 6,
                StoredItems = new()
                {
                    new StoredItemDal { Id = 2, WeaponId = 5, HeroId = 2, IsEquiped = true },
                    new StoredItemDal { Id = 3, ArtefactId = 1, HeroId = 2, IsEquiped = true }
                }
            },
            new HeroDal
            {
                Id = 3,
                Name = "Jozan",
                ImageUrl = "",
                Race = HeroRace.Human,
                Class = HeroClass.Cleric,
                LifePoints = 5,
                ManaPoints = 5,
                Shield = 2,
                FootSteps = 5,
                StoredItems = new()
                {
                    new StoredItemDal { Id = 4, WeaponId = 4, HeroId = 3, IsEquiped = true },
                    new StoredItemDal { Id = 5, SpellId = 1, HeroId = 3, IsEquiped = true }
                }
            },
            new HeroDal
            {
                Id = 4,
                Name = "Mialye",
                ImageUrl = "",
                Race = HeroRace.Elf,
                Class = HeroClass.Wizard,
                LifePoints = 5,
                ManaPoints = 5,
                Shield = 2,
                FootSteps = 5,
                StoredItems = new()
                {
                    new StoredItemDal { Id = 6, WeaponId = 2, HeroId = 4, IsEquiped = true },
                    new StoredItemDal { Id = 7, SpellId = 3, HeroId = 4, IsEquiped = true }
                }
            }
        );
    }
}
