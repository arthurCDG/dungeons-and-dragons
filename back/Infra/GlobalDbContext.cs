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
        modelBuilder.ApplyConfiguration(new ArtefactDalConfiguration());
        modelBuilder.ApplyConfiguration(new ArtefactEffectDalConfiguration());

        modelBuilder.SeedArtefacts();
    }

    public DbSet<ArtefactDal> Artefacts { get; set; }
    public DbSet<ArtefactEffectDal> ArtefactEffects { get; set; }
}
