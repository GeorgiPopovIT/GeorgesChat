using GeorgesChat.Core.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Security.Claims;

namespace GeorgesChat.Web.ViewComponents;

[ViewComponent(Name = "ListUsers")]
public class ListConnectedUsersViewComponent : ViewComponent
{
	private readonly IUserService _userService;

	public ListConnectedUsersViewComponent(IUserService userService)
	{
		_userService = userService;
	}


	public async Task<IViewComponentResult> InvokeAsync()
	{
		var result = await this._userService.GetUsersAsync(this.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

		return View(result);
	}
}
