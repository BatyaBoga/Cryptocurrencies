using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Cryptocurrencies.ViewModels;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cryptocurrencies.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для CoinInfrom.xaml
    /// </summary>
    public partial class CoinInfrom : UserControl
    {
        public CoinInfrom()
        {
            InitializeComponent();
            this.DataContext = MainViewModel.CurrentPage;
        }
    }
}
