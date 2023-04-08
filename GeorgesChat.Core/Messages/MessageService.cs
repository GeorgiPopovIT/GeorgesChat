using GeorgesChat.Infrastructure;
using GeorgesChat.Infrastructure.Data;

namespace GeorgesChat.Core.Messages;

public class MessageService : IMessageService
{
	private readonly GeorgesChatDbContext _dbContext;

	public MessageService(GeorgesChatDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<int> CreateMessage(string senderId, string message)
	{
		var newMessage = new Message
		{
			MessageBody = message,
			SenderId = senderId,
		};

		await this._dbContext.Messages.AddAsync(newMessage);
		await this._dbContext.SaveChangesAsync();

		return newMessage.Id;
	}

	public Message GetMessageById(int id)
		=> this._dbContext.Messages.FirstOrDefault(m => m.Id == id);

}
