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

	public Message CreateMessage(string senderId, string message)
	{
		var newMessage = new Message
		{
			MessageBody = message,
			SenderId = senderId,
		};

		 //this._dbContext.Messages.Add(newMessage);
		 //this._dbContext.SaveChanges();

		return newMessage;
	}

	public Message GetMessageById(int id)
		=> this._dbContext.Messages.FirstOrDefault(m => m.Id == id);

}
