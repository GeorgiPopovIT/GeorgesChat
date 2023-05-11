﻿using GeorgesChat.Core.Chats;
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

	[HttpGet]
	public IActionResult Index(string? receiverId)
	{
		var senderId = this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

		var chat = this._chatService.GetChatByReceiverAndSenderId(senderId, receiverId);
		return View(chat);
	}
}
