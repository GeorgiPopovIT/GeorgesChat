using System.ComponentModel.DataAnnotations;

namespace GeorgesChat.Infrastructure.Data
{
    public class Message : BaseModel<int>
    {
        [Required]
        public string? MessageBody { get; set; }

        public string SenderId { get; set; }
        public User User { get; set; }

        public int ChatId { get; set; }

        public Chat Chat { get; set; }

        public string ChannelId { get; set; }

    }
}
