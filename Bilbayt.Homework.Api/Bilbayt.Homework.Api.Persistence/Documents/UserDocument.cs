using Bilbayt.Homework.Api.Domain.Entities;
using System;
using Bilbayt.Homework.Api.Domain.Common;
using Bilbayt.Homework.Api.Persistence.Attributes;

namespace Bilbayt.Homework.Api.Persistence.Documents
{
    [BsonCollection(Constants.UserCollectionName)]
    public class UserDocument : IUser
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}