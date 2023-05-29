using System.Threading.Tasks;

namespace dnd_application.Sessions;

public interface ISessionsService
{
    Task CreateAsync();
}