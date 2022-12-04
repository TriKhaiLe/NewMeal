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

namespace Project.UserControlXAML.AcountPage
{
    /// <summary>
    /// Interaction logic for AP_Menu.xaml
    /// </summary>
    public partial class AP_Menu : UserControl
    {
        public AP_Menu()
        {
            InitializeComponent();
        }

        private void profile_MouseEnter(object sender, MouseEventArgs e)
        {
            button_profile.Margin = new Thickness(0, 15, 0, 5);
        }

        private void profile_MouseLeave(object sender, MouseEventArgs e)
        {
            button_profile.Margin = new Thickness(0, 20, 0, 10);
        }

        private void password_MouseEnter(object sender, MouseEventArgs e)
        {
            button_password.Margin = new Thickness(0, 15, 0, 5);
        }

        private void password_MouseLeave(object sender, MouseEventArgs e)
        {
            button_password.Margin = new Thickness(0, 20, 0, 10);
        }

        private void settings_MouseEnter(object sender, MouseEventArgs e)
        {
            button_settings.Margin = new Thickness(0, 15, 0, 5);
        }

        private void settings_MouseLeave(object sender, MouseEventArgs e)
        {
            button_settings.Margin = new Thickness(0, 20, 0, 10);
        }

        private void password_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (this.Parent as ContentControl).Content = new AP_Password();
        }

        private void profile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (this.Parent as ContentControl).Content = new AP_Profile();
        }
    }
}
