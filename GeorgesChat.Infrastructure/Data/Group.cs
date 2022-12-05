
namespace GeorgesChat.Infrastructure.Data
{
    public class Group : BaseModel<int>
    {
        public string Name { get; set; }

        public ICollection<User> Participants { get; init; } = new HashSet<User>();

        public ICollection<Message> Messages { get; init; } = new HashSet<Message>();
    }
}
