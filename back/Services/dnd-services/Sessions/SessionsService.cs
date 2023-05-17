﻿using dnd_domain.Sessions.Services;

namespace dnd_services.Sessions;

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