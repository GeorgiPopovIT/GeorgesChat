using GeorgesChat.Core;
using GeorgesChat.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GeorgesChat.Web.Controllers;

public class HomeController : Controller
{
    private readonly IUserService _userService;

	public HomeController(IUserService userService)
	{
		_userService = userService;
	}

	public IActionResult Index()
    {
        var connectedUsers = this._userService.GetUsers();

        return View(connectedUsers);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}