namespace Cryptocurrencies.Models
{
    class Markets
    {
        public string exchangeId { get; set; }
        public string quoteSymbol { get; set; }
        public decimal priceQuote { get; set; }

        private decimal _priceUsd;
        public decimal? priceUsd
        {
            get => _priceUsd;
            set
            {
                _priceUsd = value != null ? value.Value : 0;
            }
        }
    }
}
