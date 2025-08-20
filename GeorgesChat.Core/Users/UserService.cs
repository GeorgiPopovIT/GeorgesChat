using GeorgesChat.Core.Models;
using GeorgesChat.Infrastructure;
using GeorgesChat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GeorgesChat.Core.Users;

public class UserService(GeorgesChatDbContext dbContext) : IUserService
{
	private readonly GeorgesChatDbContext _dbContext = dbContext;

	public async Task ConnectUserById(string userId)
	{
		var user = await this.GetUserById(userId);
		user.IsOnline = true;

		this._dbContext.SaveChanges();
	}

	public async Task DisconnectUserById(string userId)
	{
		var user = await this.GetUserById(userId);
		user.IsOnline = false;

		this._dbContext.SaveChanges();
	}

	public async Task<IEnumerable<string>> GetAllConnectedUsers()
		=> await this._dbContext.Users
		.Where(u => u.IsOnline == true)
		.Select(u => u.Id)
		.ToListAsync();

	public async Task<User> GetUserById(string userId)
		=> await this._dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

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
