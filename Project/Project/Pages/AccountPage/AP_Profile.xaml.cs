using MaterialDesignThemes.Wpf;
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
using Project.Pages;
using Project.Model;

namespace Project.UserControlXAML.AcountPage
{
    /// <summary>
    /// Interaction logic for AP_Profile.xaml
    /// </summary>
    public partial class AP_Profile : UserControl, INotifyPropertyChanged
    {
        private string _Name_HelperText;
        public string Name_HelperText
        {
            get { return _Name_HelperText; }
            set
            {
                _Name_HelperText = value;
                OnPropertyChanged("Name_HelperText");
            }
        }

        public AP_Profile()
        {
            InitializeComponent();
            this.DataContext = this;
            Name_HelperText = "Nhập tên";
            Load_UserData();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }

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
            (this.Parent as ContentControl).Content = new AP_Menu();
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            profile_name_checking();
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            profile_name_checking();
        }

        private void age_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !number_int_checking(e.Text);
        }

        private void height_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !number_int_checking(height.Text.Insert(height.CaretIndex, e.Text));
        }

        private void weight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !number_int_checking(weight.Text.Insert(weight.CaretIndex, e.Text));
        }

        private void age_LostFocus(object sender, RoutedEventArgs e)
        {
            if (age.Text == "" || age.Text == "0")
            {
                age.Text = "1";
            }
        }

        private void height_LostFocus(object sender, RoutedEventArgs e)
        {
            if (height.Text == "" || height.Text == "0")
            {
                height.Text = "1";
            }
        }

        private void weight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (weight.Text == "" || weight.Text == "0" )
            {
                weight.Text = "1";
            }
        }

        private void edit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((bool)(edit.IsChecked) && !profile_name_checking())
            {
                e.Handled = true;
            }
            else if ((bool)edit.IsChecked)
            {
                Edit_UserData();
            }
        }

        private void redo_Click(object sender, RoutedEventArgs e)
        {
            Load_UserData();
        }

        #endregion


        #region Checking
        private bool profile_name_checking()
        {
            if (Fullname.Text.Length == 0)
            {
                Fullname.Foreground = Brushes.Red;
                Name_HelperText = "Tên không được để trống";
                return false;
            }
            else if (!Fullname.Foreground.Equals(new SolidColorBrush(Color.FromArgb(221, 0, 0, 0))))
            {
                Fullname.Foreground = new SolidColorBrush(Color.FromArgb(221, 0, 0, 0));
                Name_HelperText = "Nhập tên";
            }
            return true;
        }

        //private bool number_checking(string text)
        //{
        //    try
        //    {
        //        Convert.ToDouble(text);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        private bool number_int_checking(string text)
        {
            try
            {
                Convert.ToInt32(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Other Methods

        void Load_UserData()
        {
            Fullname.Text = AccountPage.CurrentUser.UName;
            age.Text = AccountPage.CurrentUser.Age.ToString();
            Gender.SelectedItem = Gender.Items[(int)AccountPage.CurrentUser.Sex];
            weight.Text = AccountPage.CurrentUser.UWeight.ToString();
            height.Text = AccountPage.CurrentUser.UHeight.ToString();
            Mode.SelectedItem = Gender.Items[(int)AccountPage.CurrentUser.UStatus];
        }

        void Edit_UserData()
        {
            AccountPage.CurrentUser.UName = Fullname.Text;
            AccountPage.CurrentUser.Age = Convert.ToInt32(age.Text);
            AccountPage.CurrentUser.Sex = Gender.SelectedIndex;
            AccountPage.CurrentUser.UWeight = Convert.ToInt32(weight.Text);
            AccountPage.CurrentUser.UHeight = Convert.ToInt32(height.Text);
            AccountPage.CurrentUser.UStatus = Mode.SelectedIndex;
            DataProvider.Ins.DB.SaveChanges();
        }
        #endregion


    }
}
