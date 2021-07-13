using System;

namespace HandlerExchange.Core.Entities
{
    public class Account:BaseEntity
    {
        public Guid UserId;
        public decimal Amount;
    }
}