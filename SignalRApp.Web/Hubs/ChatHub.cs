using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRApp.Web.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string groupName, string message)
        {
            await Join(groupName);
            var groupMessage = $"{groupName}: {message}";

            Clients.OthersInGroup(groupName).showMessage(groupMessage);
            Clients.Caller.showMessage($"Message [{groupMessage}] was sent");
        }

        public async Task Join(string groupName)
        {
            await Groups.Add(Context.ConnectionId, groupName);
        }
    }
}