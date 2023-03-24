using Microsoft.AspNetCore.SignalR;

namespace GeorgesChat.Web.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessageToReceiver(string sender, string message, string receiver)
    {
        string userId;

        //await Clients.User(userId).SendAsync(sender, message, receiver);
    }
}
