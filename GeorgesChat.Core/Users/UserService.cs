using GeorgesChat.Core.Models;
using GeorgesChat.Infrastructure;
using GeorgesChat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GeorgesChat.Core.Users;

public class UserService : IUserService
{
	private readonly GeorgesChatDbContext _dbContext;

	public UserService(GeorgesChatDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public void ConnectUserById(string userId)
	{
		var user = this.GetUserById(userId);
		user.IsOnline = true;

		this._dbContext.SaveChanges();
	}

	public void DisconnectUserById(string userId)
	{
		var user = this.GetUserById(userId);
		user.IsOnline = false;

		this._dbContext.SaveChanges();
	}

	public IEnumerable<string> GetAllConnectedUsers()
		=> this._dbContext.Users
		.Where(u => u.IsOnline == true)
		.Select(u => u.Id).ToList();

	public User GetUserById(string userId)
		=>  this._dbContext.Users.FirstOrDefault(u => u.Id == userId);

	public async Task<ListingConenctedUsers> GetUsersAsync(string currUserId)
	{
		return new ListingConenctedUsers
		{
			Users = await _dbContext.Users.Where(u => u.Id != currUserId).Select(u => new UserViewModel
			{
				Id = u.Id,
				FullName = u.FullName,
				Email = u.Email,
				IsOnline = u.IsOnline,
				ChatId = u.Chats.FirstOrDefault(u => u.Users.Any(u => u.Id == currUserId)).Id,
			}).ToListAsync()
		};
	}
}
