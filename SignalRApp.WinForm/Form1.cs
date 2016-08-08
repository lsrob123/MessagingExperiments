using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.AspNet.SignalR.Client;

namespace SignalRApp.WinForm
{
    public partial class Form1 : Form
    {
        private const string GroupName = "TestGroup";
        private readonly IHubProxy _chatHub;
        private readonly HubConnection _hubConnection;
        private readonly SynchronizationContext _synchronizationContext;

        public Form1()
        {
            InitializeComponent();

            _hubConnection = new HubConnection("http://localhost:20865");

            _chatHub = _hubConnection.CreateHubProxy("ChatHub");
            _chatHub.On<string>("showMessage",
                message => { _synchronizationContext.Post(o => { lblMessage.Text = (string) o; }, message); });

            _synchronizationContext = SynchronizationContext.Current;

            _hubConnection.Start().Wait();

            _chatHub.Invoke("Join", GroupName);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hubConnection.Stop();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            _chatHub.Invoke("Send", GroupName, txtMessage.Text);
        }
    }
}