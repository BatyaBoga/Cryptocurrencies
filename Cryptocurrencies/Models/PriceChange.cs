using System;

namespace Cryptocurrencies.Models
{
    class PriceChange
    {
        public decimal priceUsd { get; set; }

        public long time { get; set; }

        public DateTimeOffset TimeDay
        {
           get
           {
              return DateTimeOffset.FromUnixTimeMilliseconds(time);
           }

        }
        
    }
}
