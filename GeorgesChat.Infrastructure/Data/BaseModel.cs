﻿using System.ComponentModel.DataAnnotations;

namespace GeorgesChat.Infrastructure.Data
{
    public class BaseModel<TKey>
    {
        [Key]
        public TKey? Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
