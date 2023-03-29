using GeorgesChat.Core.Models;
using GeorgesChat.Infrastructure;

namespace GeorgesChat.Core.Chats;

public class ChatService : IChatService
{
	private readonly GeorgesChatDbContext _dbContext;

	public ChatService(GeorgesChatDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public ChatViewModel GetChat(int chatId)
	{
		return new ChatViewModel
		{
			Messages = this._dbContext.Messages
			.Where(x => x.ChatId == chatId)
			.Select(m => new MessageViewModel
			{
				MessageBody = m.MessageBody
			}).ToList()
		};
	}
	public IEnumerable<ChatViewModel> GetChat(string userId)
	{
		var result = this._dbContext.Chats
			.Where(x => x.Users.Any(c => c.Id == userId))
			.Select(x => new ChatViewModel
			{
				Messages = x.Messages.Select(c => new MessageViewModel
				{
					MessageBody = c.MessageBody
				})
			}).ToList();

		return result;
	}

}
