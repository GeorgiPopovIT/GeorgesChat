using GeorgesChat.Core.Models;
using GeorgesChat.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace GeorgesChat.Core.Users;

public class UserService : IUserService
{
    private readonly GeorgesChatDbContext _dbContext;

    public UserService(GeorgesChatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ListingConenctedUsers> GetUsersAsync(string currUserId)
    {
        return new ListingConenctedUsers
        {
            Users = await _dbContext.Users.Where(u => u.Id != currUserId).Select(u => new UserViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                ChatId = u.Chats.FirstOrDefault(u => u.Users.Any(u => u.Id == currUserId)).Id,
            }).ToListAsync()
        };
    }
}
