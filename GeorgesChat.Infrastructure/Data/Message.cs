using System;


namespace GeorgesChat.Infrastructure.Data
{
    public class Message : BaseModel<int>
    {
        public string? MessageBody { get; set; }

        public int SenderId { get; set; }

        public bool IsSeen { get; set; }

        public int ConversationId { get; set; }
    }
}
