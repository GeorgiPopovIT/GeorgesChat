using GeorgesChat.Core.Models;
using GeorgesChat.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GeorgesChat.Core.Users;

public class UserService : IUserService
{
    private readonly GeorgesChatDbContext _dbContext;

    public UserService(GeorgesChatDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ListingConenctedUsers> GetUsersAsync(string userId)
    {
        return new ListingConenctedUsers
        {
            Users = await _dbContext.Users.Where(u => u.Id != userId).Select(u => new UserViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email
            }).ToListAsync()
        };
    }
}
