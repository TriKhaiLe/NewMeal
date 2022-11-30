using Project.UserControlXAML.AcountPage;
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

namespace Project.UserControlXAML
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : UserControl
    {

        public AccountPage()
        {
            InitializeComponent();
            Screen.Content = new AP_Menu();
            
        }

        public void SetContent()
        {
            Screen.Content = null;
        }
    }
}
