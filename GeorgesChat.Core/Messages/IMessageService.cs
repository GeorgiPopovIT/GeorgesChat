using GeorgesChat.Infrastructure.Data;

namespace GeorgesChat.Core.Messages;

public interface IMessageService
{
	Task<Message> GetMessageById(int id);
	Task<Message> CreateMessage(string senderId, string message);
}
