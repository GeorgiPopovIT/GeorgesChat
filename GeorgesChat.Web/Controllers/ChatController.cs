using Microsoft.AspNetCore.Mvc;

namespace GeorgesChat.Web.Controllers;

public class ChatController : Controller
{
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult GetChat(string userId)
	{
		return View();
	}
}
