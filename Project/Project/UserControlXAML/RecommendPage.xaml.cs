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
    /// Interaction logic for RecommendPage.xaml
    /// </summary>
    public partial class RecommendPage : UserControl
    {
        public RecommendPage()
        {
            InitializeComponent();
            this.DataContext = this;
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
            lvBreakfastRecommendation.ItemsSource= items;
            lvLunchRecommendation.ItemsSource= items;
            lvDinnerRecommendation.ItemsSource= items;
        }
        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }
        }
        private void lvBreakfastRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void lvLunchRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void lvDinnerRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            
        }
    }
}
