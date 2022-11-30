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
            lvBreakfastRecommendation.ItemsSource = items;
            lvLunchRecommendation.ItemsSource = items;
            lvDinnerRecommendation.ItemsSource = items;
        }
        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }
        }
        private void lvBreakfastRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(@"\Assets\meat.png", UriKind.Relative);
            bitimg.EndInit();
            food_image.Source = bitimg;
            food_review.Text = "This is a piece of meat!!!";
        }
        private void lvLunchRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(@"\Assets\noodle.png", UriKind.Relative);
            bitimg.EndInit();
            food_image.Source = bitimg;
            food_review.Text = "This is a piece of noodle!!!";
        }
        private void lvDinnerRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(@"\Assets\rice.png", UriKind.Relative);
            bitimg.EndInit();
            food_image.Source = bitimg;
            food_review.Text = "This is a piece of rice!!!";
        }

        private void btn_them_Click(object sender, RoutedEventArgs e)
        {
            TabItem selected_tab = (TabItem)tab_control.SelectedItem;
            switch (selected_tab.Name)
            {
                case "breakfast":
                    {
                        SelectedFood_lv.Items.Add(lvBreakfastRecommendation.SelectedItem);
                        break;
                    }
                case "lunch":
                    {
                        SelectedFood_lv.Items.Add(lvLunchRecommendation.SelectedItem);
                        break;
                    }
                case "dinner":
                    {
                        SelectedFood_lv.Items.Add(lvDinnerRecommendation.SelectedItem);
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
        }
    }
}
