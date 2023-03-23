using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace GeorgesChat.Infrastructure.Data;

public class User : IdentityUser
{
    [Required]
    public string FullName { get; set; } 


    public ICollection<Message> Messages { get; init; } = new HashSet<Message>();
}
