using System;

namespace Bilbayt.Homework.Api.Domain.Entities
{
    [BsonCollection("users")]
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public User()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}