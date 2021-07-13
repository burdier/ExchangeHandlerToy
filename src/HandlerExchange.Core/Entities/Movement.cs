using System;

namespace HandlerExchange.Core.Entities
{
    public class Movement:BaseEntity
    {
        public Guid IdAccount { get; set; }
        public Guid IdInvestment { get; set; }
        public decimal Banalance { get; set; }
        public decimal Credit { get; set; }
        public decimal Debit { get; set; }
    }
}