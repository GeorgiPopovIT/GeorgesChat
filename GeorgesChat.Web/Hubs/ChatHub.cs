using Microsoft.AspNetCore.SignalR;

namespace GeorgesChat.Web.Hubs;

public class ChatHub : Hub
{ 
    public async Task SendMessageToUser(string user, string message)
    {
        await Clients.User(user).SendAsync("ReceiveMessage", user, message);
    }
}
