using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace GeorgesChat.Infrastructure.Data;

public class User : IdentityUser
{
	[Required]
	public string FullName { get; set; }

    public bool IsOnline { get; set; }


    public ICollection<Message> Messages { get; init; } = new HashSet<Message>();

	public ICollection<Chat> Chats { get; init; } = new HashSet<Chat>();
}