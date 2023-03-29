using GeorgesChat.Core;
using GeorgesChat.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace GeorgesChat.Web.Controllers;

public class HomeController : Controller
{
    private readonly IUserService _userService;

	public HomeController(IUserService userService)
	{
		_userService = userService;
	}

	public async Task<IActionResult> Index()
    {
        return View();
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