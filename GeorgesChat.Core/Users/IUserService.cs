using GeorgesChat.Core.Models;
using GeorgesChat.Infrastructure.Data;

namespace GeorgesChat.Core.Users;

public interface IUserService
{
    Task<ListingConenctedUsers> GetUsersAsync(string userId);

	User GetUserById(string userId);

    void ConnectUserById(string userId);

	IEnumerable<string> GetAllConnectedUsers();

	void DisconnectUserById(string userId);
}
