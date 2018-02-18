using Microsoft.AspNetCore.SignalR;

namespace ENotify
{
    public class NotifyHub: Hub<ITypedHubClient>
    {
        public void FromClient(string type, string payload)
        {
            Clients.All.BroadcastMessage(type, payload);
        }
    }
}
