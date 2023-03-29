using GeorgesChat.Core.Models;
using GeorgesChat.Infrastructure;

namespace GeorgesChat.Core.Chats;

public interface IChatService
{
	ChatViewModel GetChat(int chatId);
}
