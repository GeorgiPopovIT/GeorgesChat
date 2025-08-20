using GeorgesChat.Core.Models;
using GeorgesChat.Infrastructure.Data;

namespace GeorgesChat.Core.Users;

public interface IUserService
{
    Task<ListingConenctedUsers> GetUsersAsync(string userId);

	Task<User> GetUserById(string userId);

    Task ConnectUserById(string userId);

	Task<IEnumerable<string>> GetAllConnectedUsers();

	Task DisconnectUserById(string userId);
}
