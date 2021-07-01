using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Bilbayt.Homework.Api.Persistence.Documents
{
    public interface IBaseDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; set; }
    }

    public abstract class BaseDocument : IBaseDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}