using System;
using MongoDB.Bson.Serialization.Attributes;

namespace HandlerExchange.Core.Entities
{
    public abstract class BaseEntity
    {
        [BsonId]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}