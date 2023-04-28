using GeorgesChat.Core.Models;
namespace GeorgesChat.Core.Chats;

public interface IChatService
{
	ChatViewModel GetChatByReceiverAndSenderId(string senderId, string receiverId);

	Task CreateChat(string userId, string senderMessage, string receiverId);
}
