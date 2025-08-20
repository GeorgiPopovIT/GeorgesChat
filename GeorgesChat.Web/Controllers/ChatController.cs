using GeorgesChat.Core.Chats;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GeorgesChat.Web.Controllers;

public class ChatController(IChatService chatService) : Controller
{
	private readonly IChatService _chatService = chatService;

	[HttpGet]
	public IActionResult Index(string? id)
	{
		var senderId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

		var chat = this._chatService.GetChatByReceiverAndSenderId(senderId, id);
		return View(chat);
	}
}