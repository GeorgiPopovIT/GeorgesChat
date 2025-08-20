using GeorgesChat.Infrastructure;
using GeorgesChat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GeorgesChat.Core.Messages;

public class MessageService : IMessageService
{
	private readonly GeorgesChatDbContext _dbContext;

	public MessageService(GeorgesChatDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<Message> CreateMessage(string senderId, string message)
	{
		var newMessage = new Message
		{
			MessageBody = message,
			SenderId = senderId,
		};

		await this._dbContext.Messages.AddAsync(newMessage);
		await this._dbContext.SaveChangesAsync();

		return newMessage;
	}

	public async Task<Message> GetMessageById(int id)
		=> await this._dbContext.Messages.FirstOrDefaultAsync(m => m.Id == id);

}
