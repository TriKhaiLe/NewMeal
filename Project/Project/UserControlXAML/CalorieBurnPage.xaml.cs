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
    /// Interaction logic for CalorieBurnPage.xaml
    /// </summary>
    
    public partial class CalorieBurnPage : UserControl
    {
        public CalorieBurnPage()
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
            lvCaloriesBurned.ItemsSource = items;
        }

        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Calculate(object sender, RoutedEventArgs e)
        {
            
            lvCaloriesBurned.ItemsSource = CalculateCalories(Convert.ToInt32(CaloBox.Text));
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private List<string> CalculateCalories(int calories)
        {
            return new List<string> { calories.ToString() };
        }

        private void lvCaloriesBurned_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Add_click(object sender, RoutedEventArgs e)
        {

        }

        private void Calculate_click(object sender, RoutedEventArgs e)
        {

        }

        private void Find_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
