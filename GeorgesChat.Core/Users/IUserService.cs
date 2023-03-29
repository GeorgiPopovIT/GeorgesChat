using GeorgesChat.Core.Models;
using System.Security.Claims;

namespace GeorgesChat.Core.Users;

public interface IUserService
{
    Task<ListingConenctedUsers> GetUsersAsync(string userId);
}
