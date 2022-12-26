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

namespace Project
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
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
        public bool IsRegister { get; set; }
        
        public int UserID { get; set; }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            int count = DataProvider.Ins.DB.FUser.Where(p => (p.Username == txtUser.Text)).Count();
            if(count > 0)
            {
                IsRegister = false;
                txtUser.Text = "";
                txtPassword.Password = "";
                txtrePassword.Password = "";
                MessageBox.Show("Username đã tồn tại");
            }
            else if (test_empty() && test_password() && test_length())
            {
                IsRegister = false;
                txtUser.Text = "";
                txtPassword.Password = "";
                txtrePassword.Password = "";
            }
            else
            {
                FUser newUser = new FUser();
                newUser.Username = txtUser.Text;
                newUser.Passwrd = txtPassword.Password;
                newUser.UHeight = 150;
                newUser.UWeight = 60;
                newUser.UStatus = 0;
                newUser.Sex = 2;
                newUser.Age = 18;
                DataProvider.Ins.DB.FUser.Add(newUser);
                DataProvider.Ins.DB.SaveChanges();
                IsRegister = true;
                this.Close();
            }
        }

        #region Validating

        private bool test_empty()
        {
            if (txtUser.Text == "" || txtPassword.Password == "" || txtrePassword.Password == "")
            {
                MessageBox.Show("Vui lòng không để trống các ô thông tin", "Thông báo");
                return false;
            }
            return true;
        }

        private bool test_password()
        {
            if (txtPassword.Password != txtrePassword.Password)
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo");
                return false;
            }
            return true;
        }

        private bool test_length()
        {
            if (txtPassword.Password.Length < 8)
            {
                MessageBox.Show("Mật khẩu phải từ 8 kí tự trở lên", "Thông báo");
                return false;
            }
            return true;
        }

        #endregion
    }
}
