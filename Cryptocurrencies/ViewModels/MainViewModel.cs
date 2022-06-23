using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public MainViewModel()
        {
            CurrentPage = new ListOfCoinViewModel();

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
