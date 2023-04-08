namespace GeorgesChat.Core.Models;

public class ChatViewModel
{
    public string SenderId { get; set; }
    public int ChatId { get; init; }
    public string ReceiverId { get; set; }

    public IEnumerable<MessageViewModel>? Messages { get; init; }
}
