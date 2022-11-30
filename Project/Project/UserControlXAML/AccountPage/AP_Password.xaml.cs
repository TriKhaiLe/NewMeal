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
    /// Interaction logic for AP_Password.xaml
    /// </summary>
    public partial class AP_Password : UserControl
    {
        public AP_Password()
        {
            InitializeComponent();
        }

        private void Back_MouseEnter(object sender, MouseEventArgs e)
        {
            button_back.Width = 56;
            button_back.Height = 56;
            button_back.Margin = new Thickness(6, 6, 0, 0);
        }

        private void Back_MouseLeave(object sender, MouseEventArgs e)
        {
            button_back.Width = 48;
            button_back.Height = 48;
            button_back.Margin = new Thickness(10, 10, 0, 0);
        }



        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            (this.Parent as ContentControl).Content = new AP_Menu();
        }
    }
}
