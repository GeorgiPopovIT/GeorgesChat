using GeorgesChat.Core.Messages;
using GeorgesChat.Core.Models;
using GeorgesChat.Core.Users;
using GeorgesChat.Infrastructure;
using GeorgesChat.Infrastructure.Data;

namespace GeorgesChat.Core.Chats;

public class ChatService : IChatService
{
	private readonly GeorgesChatDbContext _dbContext;

	private IUserService _userService;
	private IMessageService _messageService;

	public ChatService(GeorgesChatDbContext dbContext,
		IUserService userService, IMessageService messageService)
	{
		_dbContext = dbContext;
		_userService = userService;
		_messageService = messageService;
	}

	public async Task CreateChat(string senderId, string senderMessage, string receiverId)
	{
		var sender = await this._userService.GetUserById(senderId);
		var receiver = await this._userService.GetUserById(receiverId);

		var messageId = await this._messageService.CreateMessage(senderId, senderMessage);

		var messageToAdd = this._messageService.GetMessageById(messageId);

		var currentChat = GetChat(sender, receiver);
		//await Task.WhenAll(sender, receiver);

		if (currentChat is not null)
		{
			currentChat.Messages.Add(messageToAdd);
		}
		else
		{
			currentChat = new Chat
			{
				Users = new List<User>()
				{
					sender, receiver
				},
				Messages = new List<Message>()
				{
					messageToAdd
				}
			};


		}
		await this._dbContext.Chats.AddAsync(currentChat);

		await this._dbContext.SaveChangesAsync();
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
				SenderId = m.SenderId,
			}).ToList()
	};

	private Chat GetChat(User sender, User receiver)
		=> this._dbContext.Chats
			.FirstOrDefault(u => u.Users.Contains(sender)
			&& u.Users.Contains(receiver));


	private string GetReceiverEmail(int chatId)
		=> this._dbContext.Users.FirstOrDefault(c => c.Chats.Any(c => c.Id == chatId)).Email;

}


