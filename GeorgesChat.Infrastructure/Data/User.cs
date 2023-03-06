using Microsoft.AspNetCore.Identity;

namespace GeorgesChat.Infrastructure.Data;

public class User : IdentityUser
{
    public string FullName { get; set; } = string.Empty;


    public ICollection<Message> Messages { get; init; } = new HashSet<Message>();
}
