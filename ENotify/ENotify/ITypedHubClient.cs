using System.Threading.Tasks;

namespace ENotify
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}
