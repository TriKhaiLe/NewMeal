using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalorieBurn_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new CalorieBurnViewModel();
        }

        private void Food_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new FoodViewModel();
        }

        private void History_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new HistoryViewModel();
        }

        private void Account_Checked(object sender, RoutedEventArgs e)
        {
            DataContext = new AccountViewModel();
        }
    }
}
