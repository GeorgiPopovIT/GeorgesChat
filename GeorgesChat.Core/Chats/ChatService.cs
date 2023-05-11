using GeorgesChat.Core.Messages;
using GeorgesChat.Core.Models;
using GeorgesChat.Core.Users;
using GeorgesChat.Infrastructure;
using GeorgesChat.Infrastructure.Data;

namespace GeorgesChat.Core.Chats;

public class ChatService : IChatService
{
	private readonly GeorgesChatDbContext _dbContext;

	private readonly IUserService _userService;
	private readonly IMessageService _messageService;

	public ChatService(GeorgesChatDbContext dbContext,
		IUserService userService, IMessageService messageService)
	{
		_dbContext = dbContext;
		_userService = userService;
		_messageService = messageService;
	}

	public async Task CreateChat(string senderId, string senderMessage, string receiverId)
	{
		var sender =  this._userService.GetUserById(senderId);
		var receiver =  this._userService.GetUserById(receiverId);

		var messageToAdd = this._messageService.CreateMessage(senderId, senderMessage);

		var chat = this.GetCurrentChat(sender, receiver);

		if (chat is null)
		{
			chat = new Chat();
		}
		chat.Users.Add(sender);
		chat.Users.Add(receiver);
		chat.Messages.Add(messageToAdd);

		this._dbContext.Chats.Add(chat);

		this._dbContext.SaveChanges();
	}
	public ChatViewModel GetChatByReceiverAndSenderId(string senderId, string receiverId) => new ChatViewModel
	{
		SenderId = senderId,
		ReceiverId = receiverId,
		Messages = this._dbContext.Messages.Where(m => m.SenderId == senderId || m.SenderId == receiverId)
		.Select(m => new MessageViewModel
		{
			MessageBody = m.MessageBody,
			CreatedOn = m.CreatedOn,
			SenderId = m.SenderId,
		}).ToList()
	};

	private Chat GetCurrentChat(User sender, User receiver)
		=> this._dbContext.Chats
			.FirstOrDefault(u => u.Users.Contains(sender)
			&& u.Users.Contains(receiver));


	private string GetReceiverEmail(int chatId)
		=> this._dbContext.Users.FirstOrDefault(c => c.Chats.Any(c => c.Id == chatId)).Email;

}


