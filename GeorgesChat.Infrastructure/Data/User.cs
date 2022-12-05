using Microsoft.AspNetCore.Identity;

namespace GeorgesChat.Infrastructure.Data;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public ICollection<Message> Messages { get; init; } = new HashSet<Message>();
}
