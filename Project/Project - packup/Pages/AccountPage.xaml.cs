using Project.Model;
using Project.UserControlXAML.AcountPage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Project.Pages
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        static private FUser _CurrentUser = null;

        static public FUser CurrentUser
        {
            get
            {
                if (_CurrentUser == null || _CurrentUser.UserID != DataProvider.Ins.Current_UserID)
                {
                    _CurrentUser = DataProvider.Ins.DB.FUser.Where(user => user.UserID == DataProvider.Ins.Current_UserID).SingleOrDefault();
                }
                return _CurrentUser;
            }
        }

        public AccountPage()
        {
            InitializeComponent();

        }

        public void SetContent()
        {
            Screen.Content = null;
        }


        private void page_Load(object sender, RoutedEventArgs e)
        {
            Screen.Content = new AP_Menu();
        }
    }
}
