using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;

namespace SignalRApp.Web.Hubs
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public async Task Send(string groupName, string message)
        {
            await Groups.Add(Context.ConnectionId, groupName);
            var groupMessage = $"{groupName}: {message}";

            Clients.OthersInGroup(groupName).showMessage(groupMessage);
            Clients.Caller.showMessage($"Message [{groupMessage}] was sent");
        }
    }
}