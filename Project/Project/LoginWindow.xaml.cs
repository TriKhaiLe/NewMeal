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
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
          
            if (this.WindowState != WindowState.Minimized)
            {
                this.WindowState = (WindowState.Minimized);
            }
            else {this.WindowState = WindowState.Normal; }
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
           
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = (WindowState.Maximized);
            }
            else { this.WindowState = WindowState.Normal; }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Xin chào");
        }
    }
}
