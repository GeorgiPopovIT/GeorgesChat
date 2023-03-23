using GeorgesChat.Core.Models;
using GeorgesChat.Infrastructure;

namespace GeorgesChat.Core;

public class UserService : IUserService
{
	private readonly GeorgesChatDbContext _dbContext;

	public UserService(GeorgesChatDbContext dbContext)
	{
		this._dbContext = dbContext;
	}

	public ListingConenctedUsers GetUsers()
	 => new ListingConenctedUsers
	 {
		 Users = this._dbContext.Users.Select(u => new UserViewModel
		 {
			 Id = u.Id,
			 FullName = u.FullName,
			 Email = u.Email
		 }).ToList()
	 };

}
