using dnd_domain.Seeder;
using dnd_infra.Sessions;
using System;
using System.Threading.Tasks;

namespace dnd_infra.Seeder;

internal sealed class SessionSeeder : ISessionSeeder
{
    private readonly GlobalDbContext _context;
    private readonly ItemsSeeder _itemsSeeder;
    private readonly PlayersSeeder _playersSeeder;

    public SessionSeeder(GlobalDbContext context, ItemsSeeder itemsSeeder, PlayersSeeder heroesSeeder)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _itemsSeeder = itemsSeeder ?? throw new ArgumentNullException(nameof(itemsSeeder));
        _playersSeeder = heroesSeeder ?? throw new ArgumentException(nameof(heroesSeeder));
    }

    public async Task SeedSessionAssync()
    {
        SessionDal session = new() { StartsAt = DateTime.UtcNow };
        _context.Sessions.Add(session);
        await _context.SaveChangesAsync();

        await _itemsSeeder.SeedItemsAsync(session.Id);
        await _playersSeeder.SeedPlayersAsync(session.Id);
    }
}
