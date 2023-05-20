using System.Threading.Tasks;

namespace dnd_domain.Sessions.Services;

public interface ISessionsRepository
{
    Task CreateAsync();
}