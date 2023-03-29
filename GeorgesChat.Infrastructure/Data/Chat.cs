namespace GeorgesChat.Infrastructure.Data;

public class Chat : BaseModel<int>
{

	public ICollection<User> Users { get; init; } = new HashSet<User>();

	public ICollection<Message> Messages { get; init; } = new HashSet<Message>();
}