using dnd_infra.Campaigns;
using dnd_infra.Campaigns.Adventures;
using dnd_infra.Campaigns.Adventures.Rooms;
using dnd_infra.Campaigns.Adventures.Rooms.Squares.DALs;
using dnd_infra.GameFlow.DALs;
using dnd_infra.Items;
using dnd_infra.Players.DALs;
using dnd_infra.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace dnd_infra;

internal sealed class GlobalDbContext : DbContext
{
    public GlobalDbContext(DbContextOptions<GlobalDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        builder.UseNpgsql("User ID =appuser;Password=#JTK664qNtCsjsLp;Server=localhost;Port=5432;Database=dungeonsdragons;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<StoredItemDal> StoredItems { get; set; }

    public DbSet<UserDal> Users { get; set; }
    public DbSet<PlayerDal> Players { get; set; }

    public DbSet<TurnOrderDal> TurnOrders { get; set; }
    public DbSet<CurrentPlayerDal> CurrentPlayers { get; set; }

    public DbSet<CampaignDal> Campaigns { get; set; }
    public DbSet<AdventureDal> Adventures { get; set; }
    public DbSet<RoomDal> Rooms { get; set; }
    public DbSet<SquareDal> Squares { get; set; }
}
