using GeorgesChat.Infrastructure.Data;

namespace GeorgesChat.Core.Messages;

public interface IMessageService
{
	Message GetMessageById(int id);
	Task<int> CreateMessage(string senderId, string message);
}
