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

	public ChatViewModel GetChat(int chatId) => new ChatViewModel
	{
		ChatId = chatId,
		Messages = this._dbContext.Messages
			.Where(x => x.ChatId == chatId)
			.Select(m => new MessageViewModel
			{
				MessageBody = m.MessageBody,
				CreatedOn = m.CreatedOn,
				UserId = m.SenderId
			}).ToList()
	};

}


