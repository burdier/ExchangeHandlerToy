using System;
using HandlerExchange.Core.Entities;
using HandlerExchange.Shared.Enums;

namespace HandlerExchange.Core.DTO.Investment
{
    public class RequestInvestmentDto
    {
        public Guid Id { get; set; } = new Guid();
        public string Symbol { get; set; }
        public InvestmentType InvestmentType;
    }
}