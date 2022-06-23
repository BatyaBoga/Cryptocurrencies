using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptocurrencies.Models;

namespace Cryptocurrencies.ViewModels
{
    class CoinInformViewModel : BaseViewModel
    {

        private CoinInfo _coinInfo;
        public CoinInfo CoinInfo
        {
            get { return _coinInfo; }
            set
            {
                _coinInfo = value;
                OnPropertyChanged();
            }
        }

        private string _id;
        public string id
        {
            get => _id;
            set
            {
                _id = value;
                InitializeComponent();
                OnPropertyChanged();
            }
        }

        private string _img;
        public string img
        {
            get { return _img; }
            set
            {
                _img = @"https://assets.coincap.io/assets/icons/" + CoinInfo.symbol.ToLower() + "@2x.png";
                OnPropertyChanged();
            }
        }

        private List<PriceChange> _prices;
        public List<PriceChange> Prices
        {
            get => _prices;
            set
            {
                _prices = value;
                OnPropertyChanged();
            }
        }
        public CoinInformViewModel(string id)
        {
            this.id = id;
        }

        private void InitializeComponent()
        {
            CoinInfo = HttpWorcker.GetCoinInfo(id);
            img = @"https://assets.coincap.io/assets/icons/" + CoinInfo.symbol.ToLower() + "@2x.png";
            Prices = new List<PriceChange>(HttpWorcker.GetPriceInfo(id));
            Prices.Reverse();
        }
    }
}
