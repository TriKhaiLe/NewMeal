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
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
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
            button_back.Margin = new Thickness(0, 0, 0, 0);
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
            e.Handled = !number_checking(height.Text.Insert(height.CaretIndex, e.Text));
        }

        private void weight_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !number_checking(weight.Text.Insert(weight.CaretIndex, e.Text));
        }

        private void age_LostFocus(object sender, RoutedEventArgs e)
        {
            if (age.Text == "")
            {
                age.Text = "1";
            }
        }

        private void height_LostFocus(object sender, RoutedEventArgs e)
        {
            if (height.Text == "")
            {
                height.Text = "1";
            }
        }

        private void weight_LostFocus(object sender, RoutedEventArgs e)
        {
            if (weight.Text == "")
            {
                weight.Text = "1";
            }
        }

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

        private bool number_checking(string text)
        {
            try
            {
                Convert.ToDouble(text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

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

        private void edit_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((bool)(edit.IsChecked) && !profile_name_checking())
            {
                e.Handled = true;
            }
        }
    }
}
