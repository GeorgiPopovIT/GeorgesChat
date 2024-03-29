﻿namespace GeorgesChat.Core.Models;

public class UserViewModel
{
	public string? Id { get; init; }
	public string? FullName { get; init; }

	public string? Email { get; init; }

    public  bool IsOnline { get; init; }

    public int? ChatId { get; init; }

}
