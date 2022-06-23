using System.Collections.ObjectModel;
using System.Windows.Input;
using Cryptocurrencies.Models;
using Cryptocurrencies.Commands;

namespace Cryptocurrencies.ViewModels
{
    class ListOfCoinViewModel : BaseViewModel
    {
        public static ObservableCollection<CoinInfo> Coins { get; set; }
        public CoinInfo SelectedCoin { get; set; }

        public ListOfCoinViewModel()
        {
            Coins = new ObservableCollection<CoinInfo>(HttpWorcker.GetCoinsInfo());

        }

        public ICommand SelectedItem_click
        {
            get
            {
                return new RelayCommand((_) => MainViewModel.CurrentPage = new CoinInformViewModel(SelectedCoin.id));
            }
        }


    }
}
