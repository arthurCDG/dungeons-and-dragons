using dnd_domain.Sessions.Services;
using System;
using System.Threading.Tasks;

namespace dnd_application.Sessions;

internal sealed class SessionsService : ISessionsService
{
    private readonly ISessionsRepository _sessionsRepository;

    public SessionsService(ISessionsRepository sessionsRepository)
    {
        _sessionsRepository = sessionsRepository ?? throw new ArgumentNullException(nameof(sessionsRepository));
    }

    public Task CreateAsync()
        => _sessionsRepository.CreateAsync();
}
