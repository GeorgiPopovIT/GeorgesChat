using System.ComponentModel.DataAnnotations;

namespace GeorgesChat.Infrastructure.Data;

public abstract class BaseModel<TKey>
{
    [Key]
    public TKey? Id { get; set; }

    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

    public DateTime? ModifiedOn { get; set; }

    public DateTime? DeletedOn { get; set; }

    public bool IsDeleted { get; set; }
}
