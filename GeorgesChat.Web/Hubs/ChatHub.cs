using Microsoft.AspNetCore.SignalR;

namespace GeorgesChat.Web.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage",user,message);
    }

    public async Task SendMessageToGroup(string sender, string receiver, string message)
    {
        await Clients.Group(receiver).SendAsync("Receive Message",sender, message);
    }
}
