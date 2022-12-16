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
using Project.Pages;
using Project.Model;

namespace Project.UserControlXAML.AcountPage
{
    /// <summary>
    /// Interaction logic for AP_Password.xaml
    /// </summary>
    public partial class AP_Delete : UserControl
    {
        public string Username
        {
            get
            {
                if (AccountPage.CurrentUser == null)
                {
                    return "User";
                }
                else
                {
                    return AccountPage.CurrentUser.UName;
                }
            }
        }

        public AP_Delete()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Checking

        private bool test_empty()
        {
            if (password1.Password == "" || password2.Password == "")
            {
                MessageBox.Show("Vui lòng không để trống các ô thông tin","Thông báo");
                return false;
            }
            return true;
        }

        private bool test_password()
        {
            if (password1.Password != AccountPage.CurrentUser.Passwrd)
            {
                MessageBox.Show("Mật khẩu không đúng", "Thông báo");
                return false;
            }
            return true;
        }

        private bool test_retype_password()
        {
            if (password1.Password != password2.Password)
            {
                MessageBox.Show("Nhập lại mật khẩu không trùng khớp", "Thông báo");
                return false;
            }
            return true;
        }


        private void close_tag()
        {
            (this.Parent as ContentControl).Content = new AP_Menu();
        }

        private void delete_account()
        {
            // Delete Account
            

            DataProvider.Ins.DB.SaveChanges();
            MessageBox.Show("Bạn đã xóa tài khoản thành công!", "Thông báo");
            close_tag();
        }

        private void empty_Textbox()
        {
            password1.Clear();
            password2.Clear();
        }
        #endregion

        #region Event

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
            close_tag();
        }

        private void changePass_Click(object sender, RoutedEventArgs e)
        {
            if (test_empty() && test_retype_password() && test_password())
            {
                delete_account();
            }
            else
            {
                empty_Textbox();
            }
        }
        #endregion


    }
}
