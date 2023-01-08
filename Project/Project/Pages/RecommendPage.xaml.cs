using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            FoodUser = DataProvider.Ins.DB.UserFood.Where(p => p.UserID == DataProvider.Ins.Current_UserID).ToList();
            InitializeComponent();
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvBreakfastRecommendation.ItemsSource);
        }

        private void recommend_page_Loaded(object sender, RoutedEventArgs e)
        {
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
            lvBreakfastRecommendation.Items.Refresh();
            lvLunchRecommendation.Items.Refresh();
            lvDinnerRecommendation.Items.Refresh();
            Gauge_Kcal.To = DataProvider.Ins.Kcal_UserID;
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
            UserFood uf = DataProvider.Ins.DB.UserFood.SingleOrDefault(p => p.UserID == DataProvider.Ins.Current_UserID && p.FoodID == food.FoodID);
            tb_calo.Text = food.Kcal.Value.ToString();
            if (uf == null)
            {
                favorite_button.IsChecked = false;
                tb_last_eat.Text = "Bạn chưa bao giờ thử món này!";
            }
            else
            {
                if (uf.Favorite == null)
                {
                    favorite_button.IsChecked = false;
                }
                else
                {
                    if (uf.Favorite == 1)
                    {
                        favorite_button.IsChecked = true;
                    }
                    else
                    {
                        favorite_button.IsChecked = false;
                    }
                }
                if (uf.Last_eat == null)
                {
                    tb_last_eat.Text = "Bạn chưa bao giờ thử món này!";
                }
                else
                {
                    tb_last_eat.Text = uf.Last_eat.Value.ToShortDateString();
                }
            }
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
            UserFood uf = DataProvider.Ins.DB.UserFood.SingleOrDefault(p => p.UserID == DataProvider.Ins.Current_UserID && p.FoodID == food.FoodID);
            tb_calo.Text = food.Kcal.Value.ToString();
            if (uf == null)
            {
                favorite_button.IsChecked = false;
                tb_last_eat.Text = "Bạn chưa bao giờ thử món này!";
            }
            else
            {
                if (uf.Favorite == null)
                {
                    favorite_button.IsChecked = false;
                }
                else
                {
                    if (uf.Favorite == 1)
                    {
                        favorite_button.IsChecked = true;
                    }
                    else
                    {
                        favorite_button.IsChecked = false;
                    }
                }
                if (uf.Last_eat == null)
                {
                    tb_last_eat.Text = "Bạn chưa bao giờ thử món này!";
                }
                else
                {
                    tb_last_eat.Text = uf.Last_eat.Value.ToShortDateString();
                }
            }
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
            UserFood uf = DataProvider.Ins.DB.UserFood.SingleOrDefault(p => p.UserID == DataProvider.Ins.Current_UserID && p.FoodID == food.FoodID);
            tb_calo.Text = food.Kcal.Value.ToString();
            if (uf == null)
            {
                favorite_button.IsChecked = false;
                tb_last_eat.Text = "Bạn chưa bao giờ thử món này!";
            }
            else
            {
                if (uf.Favorite == null)
                {
                    favorite_button.IsChecked = false;
                }
                else
                {
                    if (uf.Favorite == 1)
                    {
                        favorite_button.IsChecked = true;
                    }
                    else
                    {
                        favorite_button.IsChecked = false;
                    }
                }
                if (uf.Last_eat == null)
                {
                    tb_last_eat.Text = "Bạn chưa bao giờ thử món này!";
                }
                else
                {
                    tb_last_eat.Text = uf.Last_eat.Value.ToShortDateString();
                }
            }
        }

        private void btn_them_Click(object sender, RoutedEventArgs e)
        {
            TabItem selected_tab = (TabItem)tab_control.SelectedItem;
            Food food = new Food();
            switch (selected_tab.Name)
            {
                case "breakfast":
                    {
                        food = (Food)lvBreakfastRecommendation.SelectedItem;
                        break;
                    }
                case "lunch":
                    {
                        food = (Food)lvLunchRecommendation.SelectedItem;
                        break;
                    }
                case "dinner":
                    {
                        food = (Food)lvDinnerRecommendation.SelectedItem;
                        break;
                    }
                default:
                    {
                        return;
                    }
            }
            if (food != null)
            {
                Gauge_Kcal.Value += (double)food.Kcal;
                SelectedFood_lv.Items.Add(food);
                if (Gauge_Kcal.Value > Gauge_Kcal.To)
                {
                    kcal_txt.Visibility = Visibility.Visible;
                }
            }
        }
        private void DelSelected_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            FoodDays food = button.DataContext as FoodDays;
            Gauge_Kcal.Value -= (double)food.Food.Kcal;
            SelectedFood_lv.Items.Remove(food);
            if (Gauge_Kcal.Value <= Gauge_Kcal.To)
            {
                kcal_txt.Visibility = Visibility.Hidden;
            }
        }

        private void favorite_button_Click(object sender, RoutedEventArgs e)
        {
            Food food = new Food();
            switch (tab_control.SelectedIndex)
            {
                case 0:
                    {
                        food = lvBreakfastRecommendation.SelectedItem as Food;
                    }
                    break;
                case 1:
                    {
                        food = lvLunchRecommendation.SelectedItem as Food;
                    }
                    break;
                case 2:
                    {
                        food = lvDinnerRecommendation.SelectedItem as Food;
                    }
                    break;

            }
            UserFood userFood = DataProvider.Ins.DB.UserFood.SingleOrDefault(p => p.UserID == DataProvider.Ins.Current_UserID && p.FoodID == food.FoodID);
            if (userFood == null)
            {
                userFood = new UserFood();
                userFood.UserID = DataProvider.Ins.Current_UserID;
                userFood.FoodID = food.FoodID;
                userFood.Favorite = Convert.ToInt16(favorite_button.IsChecked);
                userFood.Last_eat = null;
                DataProvider.Ins.DB.UserFood.Add(userFood);
                DataProvider.Ins.DB.SaveChanges();
            }
            else
            {
                userFood.Favorite = Convert.ToInt16(favorite_button.IsChecked);
                DataProvider.Ins.DB.SaveChanges();
            }
        }
    }
}
