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

namespace Project.UserControlXAML
{
    /// <summary>
    /// Interaction logic for FoodPage.xaml
    /// </summary>
    public partial class FoodPage : UserControl
    {
        public FoodPage()
        {
            InitializeComponent();
            List<User> items = new List<User>();
            
            items.Add(new User() { Name = "John Doe", Age = 42, Mail = "john@doe-family.com" });
            items.Add(new User() { Name = "Jane Doe", Age = 39, Mail = "jane@doe-family.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });
            items.Add(new User() { Name = "Sammy Doe", Age = 13, Mail = "sammy.doe@gmail.com" });
            lvDataBinding.ItemsSource = items;
            textchangebytime();
        }
        public void textchangebytime()
        {

            int time = Convert.ToInt32(DateTime.Now.Hour.ToString());
            if (time >= 4 && time < 11)
            {
                HelloTime_tb.Text = "Xin chào buổi sáng !";
            }
            else if (time >= 11 && time <= 12)
            {
                HelloTime_tb.Text = "Xin chào buổi trưa !";
            }
            else if (time > 12 && time < 18)
            {
                HelloTime_tb.Text = "Xin chào buổi chiều !";
            }
            else HelloTime_tb.Text = "Xin chào buổi tối";
        }
        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }
        }

        private void lvDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedFood_lv.Items.Add(lvDataBinding.SelectedItem);
        }
    }
}
