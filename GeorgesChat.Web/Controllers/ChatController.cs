using GeorgesChat.Core.Chats;
using GeorgesChat.Core.Models;
using GeorgesChat.Web.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace GeorgesChat.Web.Controllers;

public class ChatController : Controller
{
	private IChatService _chatService;

	public ChatController(IChatService chatService)
	{
		_chatService = chatService;
	}

	public IActionResult Index(int chatId = 0)
	{
		var chats = this._chatService.GetChat(chatId);
		chats.SenderId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

		return View(chats);
	}
}
