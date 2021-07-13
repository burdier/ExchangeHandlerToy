using System;
using System.Collections.Generic;

namespace HandlerExchange.Infra.POCOs
{
    public class CoinMarketCapResponse
    {
        public List<Data> Data { get; set; } 
    }
     public class Status
    {
      
    }

    public class USD
    {
        public double Price { get; set; }
       
    }

    public class Quote
    {
        public USD USD { get; set; }
    }

    public class Data
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
    }
}