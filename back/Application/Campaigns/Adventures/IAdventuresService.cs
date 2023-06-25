﻿using dnd_domain.Campaigns.Models;
using System.Threading.Tasks;

namespace dnd_application.Campaigns.Adventures;

public interface IAdventuresService
{
    Task<Adventure> StartAsync(int campaignId, int id);
}