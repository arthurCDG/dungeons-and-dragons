using dnd_infra.Dice;
using dnd_infra.Items.Configurations;
using dnd_infra.Items.DALs;
using dnd_infra.Seeder;
using Microsoft.EntityFrameworkCore;

namespace dnd_infra;

internal sealed class GlobalDbContext : DbContext
{
    public GlobalDbContext(DbContextOptions<GlobalDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DungeonsDragons;Trusted_Connection=True;MultipleActiveResultSets=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyItemConfigurations();
        modelBuilder.ApplyConfiguration(new DieDalConfiguration());

        modelBuilder.SeedArtefacts();
        modelBuilder.SeedChestTraps();
        modelBuilder.SeedPotions();
    }

    public DbSet<ArtefactDal> Artefacts { get; set; }
    public DbSet<ChestTrapDal> ChestTraps { get; set; }
    public DbSet<PotionDal> Potions { get; set; }
}
