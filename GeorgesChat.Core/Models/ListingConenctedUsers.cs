namespace GeorgesChat.Core.Models;

public class ListingConenctedUsers
{
    public IEnumerable<UserViewModel> Users { get; init; }

    public ChatViewModel Chat { get; init; }
}
