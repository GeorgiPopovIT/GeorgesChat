using GeorgesChat.Core.Chats;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace GeorgesChat.Web.Hubs;

public class ChatHub : Hub
{
	private IChatService _chatService;
	public ChatHub(IChatService chatService)
	{
		_chatService = chatService;
	}
	public async Task SendMessageToReceiver(string senderId, string message, string receiverId)
	{
		//await this._chatService.CreateChat(senderId,message, receiverId);

		await Clients.User(receiverId).SendAsync("ReceiveMessage", message);

		await Clients.User(senderId).SendAsync("ReceiveMessageSender", message);

	}

	public string GetConnectionId() => Context.ConnectionId;
}
