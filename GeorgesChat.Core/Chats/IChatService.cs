using GeorgesChat.Core.Models;
namespace GeorgesChat.Core.Chats;

public interface IChatService
{
	ChatViewModel GetChatById(int chatId);

	Task CreateChat(string userId, string senderMessage, string receiverId);
}
