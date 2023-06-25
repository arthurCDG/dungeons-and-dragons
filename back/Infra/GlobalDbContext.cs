using dnd_infra.Campaigns;
using dnd_infra.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using dnd_infra.Dice;
using dnd_infra.GameFlow.Configurations;
using dnd_infra.GameFlow.DALs;
using dnd_infra.Items.Configurations;
using dnd_infra.Items.DALs;
using dnd_infra.Players.Configurations;
using dnd_infra.Players.DALs;
using dnd_infra.Users;
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
        modelBuilder.ApplyPlayerConfigurations();
        modelBuilder.ApplyConfiguration(new UserDalConfiguration());

        modelBuilder.ApplyConfiguration(new DieAssociationDalConfiguration());

        modelBuilder.ApplyCampaignsConfigurations();
        modelBuilder.ApplyGameFlowConfigurations();
    }

    public DbSet<StoredItemDal> StoredItems { get; set; }
    public DbSet<ArtefactDal> Artefacts { get; set; }
    public DbSet<ChestTrapDal> ChestTraps { get; set; }
    public DbSet<PotionDal> Potions { get; set; }
    public DbSet<WeaponDal> Weapons { get; set; }
    public DbSet<SpellDal> Spells { get; set; }

    public DbSet<UserDal> Users { get; set; }
    public DbSet<PlayerDal> Players { get; set; }

    public DbSet<DieAssociationDal> DieAssociations { get; set; }

    public DbSet<TurnOrderDal> TurnOrders { get; set; }
    public DbSet<CurrentPlayerDal> CurrentPlayers { get; set; }

    public DbSet<CampaignDal> Campaigns { get; set; }
    public DbSet<AdventureDal> Adventures { get; set; }
    public DbSet<RoomDal> Rooms { get; set; }
    public DbSet<SquareDal> Squares { get; set; }
}
