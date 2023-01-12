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
using System.Net.Mail;
using System.Net;

namespace Project.UserControlXAML.AcountPage
{
    /// <summary>
    /// Interaction logic for AP_Password.xaml
    /// </summary>
    public partial class AP_Response : UserControl
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

        public AP_Response()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Checking

        private bool test_empty()
        {

            return true;
        }

        private void close_tag()
        {
            (this.Parent as ContentControl).Content = new AP_Menu();
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

        private void send_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Other
        // send response
        //private void GetPass_Click(object sender, RoutedEventArgs e)
        //{
        //    string from, pass, messageBody, NewPass;
        //    bool UserExist = true, UserMailExist = true;
        //    Random rand = new Random();
        //    randomCode = (rand.Next(999999)).ToString();
        //    NewPass = "pa$$" + randomCode.ToString();
        //    MailMessage message = new MailMessage();
        //    to = (Mail_txt.Text).ToString();
        //    from = "todaywhateat008@gmail.com";
        //    pass = "fvpxzbucxtmohsgi";
        //    messageBody = "Mật khẩu mới của bạn là : " + NewPass;
        //    message.To.Add(to);
        //    message.From = new MailAddress(from);
        //    message.Body = messageBody;
        //    message.Subject = "Mật khẩu mới";
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
        //    smtp.EnableSsl = true;
        //    smtp.Port = 587;
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtp.Credentials = new NetworkCredential(from, pass);
        //    try
        //    {
        //        smtp.Send(message);
        //        if (MessageBox.Show("Mật khẩu mới đã được gửi đến mail của bạn !", "Thông báo") == MessageBoxResult.OK)
        //        {
        //            Main.turn_back();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }

        //    user = DataProvider.Ins.DB.FUser.SingleOrDefault(p => p.Username == Acc_txt.Text);
        //    if (user != null)
        //    {
        //        user.Passwrd = NewPass;
        //        DataProvider.Ins.DB.SaveChanges();
        //    }
        //    else UserExist = false;

        //    if (!UserExist || !UserMailExist)
        //    {
        //        MessageBox.Show("Tài khoản của bạn không tồn tại hoặc mail của bạn không đúng !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //}

        #endregion


    }
}
