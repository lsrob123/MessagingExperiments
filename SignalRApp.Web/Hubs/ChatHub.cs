using Microsoft.AspNet.SignalR;

namespace SignalRApp.Web.Hubs
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string groupName, string message)
        {
            Clients.OthersInGroup(groupName).showMessage(message);
        }
    }
}