﻿using Project.Model;
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
        public bool IsLogin { get; set; }
        public int UserID { get; set; }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int count = DataProvider.Ins.DB.FUser.Where(p => (p.Username == txtUser.Text && p.Passwrd == txtPassword.Password)).Count();
            if(count > 0)
            {
                IsLogin = true;
                DataProvider.Ins.Current_UserID = DataProvider.Ins.DB.FUser.SingleOrDefault(p => p.Username == txtUser.Text).UserID;
                this.Close();
            }
            else
            {
                IsLogin = false;
                txtUser.Text = null;
                txtPassword.Password = null;
                MessageBox.Show("Tài khoản hoặc mật khẩu bị sai");
            }
        }
    }
}
