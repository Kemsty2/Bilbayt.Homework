using System;

namespace Bilbayt.Homework.Api.Domain
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}