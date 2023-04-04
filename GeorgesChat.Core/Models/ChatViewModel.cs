namespace GeorgesChat.Core.Models;

public class ChatViewModel
{
    public string SenderId { get; set; }
    public int ChatId { get; init; }

    public IEnumerable<MessageViewModel>? Messages { get; init; }
}
