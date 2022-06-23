using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptocurrencies.Commands;
using System.Windows.Input;
using System.Windows;

namespace Cryptocurrencies.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        public static BaseViewModel _currentPage;
        public static BaseViewModel CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                NotifyStaticPropertyChanged("CurrentPage");
            }
        }

        public string TxtBoxText { get; set; }

        public MainViewModel()
        {
            CurrentPage = new ListOfCoinViewModel();

        }
        public ICommand HomeClick
        {
            get
            {
                return new RelayCommand((_) => CurrentPage = CurrentPage is ListOfCoinViewModel ? CurrentPage : new ListOfCoinViewModel());
            }
        }

        public ICommand SearchClick
        {
            get
            {
                return new RelayCommand((_) =>
                {
                    var SearchQuery = from coins in ListOfCoinViewModel.Coins
                                      where coins.name == TxtBoxText || coins.id == TxtBoxText
                                      || coins.symbol == TxtBoxText.ToUpperInvariant()
                                      select coins.id;

                    if (TxtBoxText != "" && SearchQuery.Count() != 0)
                    {
                        if (CurrentPage is not CoinInformViewModel)
                        {
                            CurrentPage = new CoinInformViewModel(SearchQuery.First());
                        }
                        else
                        {
                            (CurrentPage as CoinInformViewModel).id = SearchQuery.First();
                        }

                    }
                    else
                    {
                        MessageBox.Show($"No results found for your search {TxtBoxText}");
                    }


                });
            }
        }

        #region ChangeProperty
        private static event EventHandler<PropertyChangedEventArgs> staticPC
                                                     = delegate { };
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged
        {
            add { staticPC += value; }
            remove { staticPC -= value; }
        }
        protected static void NotifyStaticPropertyChanged(string propertyName)
        {
            staticPC(null, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
