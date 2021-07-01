using System;

namespace Bilbayt.Homework.Api.Domain
{
    public interface IBaseEntity
    {
        string Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}