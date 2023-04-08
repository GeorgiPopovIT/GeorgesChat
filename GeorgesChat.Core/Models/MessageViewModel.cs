namespace GeorgesChat.Core.Models;

public class MessageViewModel
{
    public string MessageBody { get; init; }

    public DateTime CreatedOn { get; init; }

    public string SenderId { get; init; }
}
