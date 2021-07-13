using HandlerExchange.Shared.Enums;

namespace HandlerExchange.Core.Entities
{
    public class Investment:BaseEntity
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public InvestmentType Type { get; set;}
        public decimal Ammount { get; set; }
    }

}