using GeorgesChat.Core.Chats;
using GeorgesChat.Core.Users;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace GeorgesChat.Web.Hubs;

public class ChatHub : Hub
{
	private readonly IChatService _chatService;
	private readonly IUserService _userService;
	public ChatHub(IChatService chatService, IUserService userService)
	{
		_chatService = chatService;
		_userService = userService;
	}

	public override Task OnConnectedAsync()
	{
		var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

		if (!string.IsNullOrWhiteSpace(userId))
		{
			this._userService.ConnectUserById(userId);

			Clients.Users(this._userService.GetAllConnectedUsers()).SendAsync("OnlineUsers");

		}

		return base.OnConnectedAsync();
	}

	public override Task OnDisconnectedAsync(Exception? exception)
	{
		var userId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

		if (!string.IsNullOrWhiteSpace(userId))
		{
			this._userService.DisconnectUserById(userId);

			Clients.Users(this._userService.GetAllConnectedUsers()).SendAsync("OnlineUsers");

		}
		return base.OnDisconnectedAsync(exception);
	}
	public async Task SendMessageToReceiver(string senderId, string message, string receiverId)
	{
		await this._chatService.CreateChat(senderId, message, receiverId);
		await Clients.User(receiverId).SendAsync("ReceiveMessage", message);

		await Clients.User(senderId).SendAsync("ReceiveMessageSender", message);

	}

	public string GetConnectionId() => Context.ConnectionId;
}
