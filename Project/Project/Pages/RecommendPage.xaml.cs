using Project.Model;
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

namespace Project.Pages
{
    /// <summary>
    /// Interaction logic for RecommendPage.xaml
    /// </summary>
    public partial class RecommendPage : Page
    {
        public List<UserFood> FoodUser { get; set; }
        public List<Food> Breakfast_food { get; set; }
        public List<Food> Lunch_food { get; set; }
        public List<Food> Dinner_food { get; set; }
        public List<Food> foodList { get; set; }
        CollectionView view;
        public RecommendPage()
        {
            this.DataContext = this;
            foodList = new List<Food>();
            Breakfast_food = new List<Food>();
            Lunch_food = new List<Food>();
            Dinner_food = new List<Food>();
            foodList = DataProvider.Ins.DB.Food.ToList();
            InitializeComponent();
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvBreakfastRecommendation.ItemsSource);
        }

        private void recommend_page_Loaded(object sender, RoutedEventArgs e)
        {
            FoodUser = DataProvider.Ins.DB.UserFood.Where(p => p.UserID == DataProvider.Ins.Current_UserID).ToList();
            foreach (Food food in foodList)
            {
                switch (food.MealTime)
                {
                    case 3:
                        {
                            Breakfast_food.Add(food);
                        }
                        break;
                    case 4:
                        {
                            Lunch_food.Add(food);
                        }
                        break;
                    case 5:
                        {
                            Dinner_food.Add(food);
                        }
                        break;
                    case 7:
                        {
                            Breakfast_food.Add(food);
                            Lunch_food.Add(food);
                        }
                        break;
                    case 8:
                        {
                            Breakfast_food.Add(food);
                            Dinner_food.Add(food);
                        }
                        break;
                    case 9:
                        {
                            Lunch_food.Add(food);
                            Dinner_food.Add(food);
                        }
                        break;
                    case 12:
                        {
                            Breakfast_food.Add(food);
                            Lunch_food.Add(food);
                            Dinner_food.Add(food);
                        }
                        break;
                }
                lvBreakfastRecommendation.ItemsSource = Breakfast_food;
                lvLunchRecommendation.ItemsSource = Lunch_food;
                lvDinnerRecommendation.ItemsSource = Dinner_food;
            }
        }

        private void lvBreakfastRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage bitimg = new BitmapImage();
            Food food = lvBreakfastRecommendation.SelectedItem as Food;
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(food.Imgsrc, UriKind.Relative);
            bitimg.EndInit();
            food_image.Source = bitimg;
            food_review.Text = food.Descript;
            try
            {
                UserFood uf = FoodUser.Where(p => p.FoodID == food.FoodID).First();
                tb_last_eat.Text = uf.Last_eat.Value.ToShortDateString();
            }
            catch
            {
                tb_last_eat.Text = "Bạn chưa bao giờ thử món này!";
            }
            tb_calo.Text = food.Kcal.Value.ToString();
        }
        private void lvLunchRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage bitimg = new BitmapImage();
            Food food = lvLunchRecommendation.SelectedItem as Food;
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(food.Imgsrc, UriKind.Relative);
            bitimg.EndInit();
            food_image.Source = bitimg;
            food_review.Text = food.Descript;
            try
            {
                UserFood uf = FoodUser.Where(p => p.FoodID == food.FoodID).First();
                tb_last_eat.Text = uf.Last_eat.Value.ToShortDateString();
            }
            catch
            {
                tb_last_eat.Text = "Bạn chưa bao giờ thử món này!";
            }
            tb_calo.Text = food.Kcal.Value.ToString();
        }
        private void lvDinnerRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage bitimg = new BitmapImage();
            Food food = lvDinnerRecommendation.SelectedItem as Food;
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(food.Imgsrc, UriKind.Relative);
            bitimg.EndInit();
            food_image.Source = bitimg;
            food_review.Text = food.Descript;
            try
            {
                UserFood uf = FoodUser.Where(p => p.FoodID == food.FoodID).First();
                tb_last_eat.Text = uf.Last_eat.Value.ToShortDateString();
            }
            catch
            {
                tb_last_eat.Text = "Bạn chưa bao giờ thử món này!";
            }
            tb_calo.Text = food.Kcal.Value.ToString();
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

        private void favorite_button_Checked(object sender, RoutedEventArgs e)
        {
            if (tab_control.SelectedIndex == 1)
            {
                MessageBox.Show("1");
            }
        }

        private void favorite_button_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
