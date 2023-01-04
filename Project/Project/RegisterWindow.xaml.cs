using Project.Model;
using Project.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Project.RegisterPage;

namespace Project
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public bool IsRegister { get; set; }

        public RegisterWindow()
        {
            InitializeComponent();
            Screen.Content = new Re_Account(this);
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
                this.btnMaximize.Content = "🗗";
            }
            else {this.WindowState = WindowState.Normal; }
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
           
            if (this.WindowState != WindowState.Maximized)
            {
                this.WindowState = (WindowState.Maximized);
                this.btnMaximize.Content = "🗗";
            }
            else { this.WindowState = WindowState.Normal; }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void next_step(FUser newUser)
        {
            Re_Account page = ((Re_Account)Screen.Content);
            if (page.IsRegister)
            {
                Screen.Content = new Re_Info(this, newUser);
            }
        }

        public void finish_register(FUser newUser)
        {
            Re_Info page = ((Re_Info)Screen.Content);
            if (page.IsRegister)
            {
                DataProvider.Ins.DB.FUser.Add(newUser);
                DataProvider.Ins.DB.SaveChanges();
                IsRegister = true;
            }
        }
    }
}
