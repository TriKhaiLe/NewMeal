using Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class RecommendPage : Page , INotifyPropertyChanged
    {
        public List<UserFood> FoodUser { get; set; }
        public List<FoodDays> Breakfast_food { get; set; }
        public List<FoodDays> Lunch_food { get; set; }
        public List<FoodDays> Dinner_food { get; set; }
        private List<FoodDays> _foodList;
        private int IsLoadFood;
        public List<FoodDays> foodList
        {
            get
            {
                if (_foodList == null) _foodList = new List<FoodDays>();
                return _foodList;
            }
            set
            {
                _foodList = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        CollectionView view;
        public RecommendPage()
        {
            this.DataContext = this;
            Breakfast_food = new List<FoodDays>();
            Lunch_food = new List<FoodDays>();
            Dinner_food = new List<FoodDays>();
            IsLoadFood = 1;
            InitializeComponent();
        }

        private void recommend_page_Loaded(object sender, RoutedEventArgs e)
        {
            FoodUser = DataProvider.Ins.DB.UserFood.Where(p => p.UserID == DataProvider.Ins.Current_UserID).ToList();
            Food food = new Food();
            List<Food> foods = DataProvider.Ins.DB.Food.ToList();
            foreach (UserFood user in FoodUser)
            {
                food = DataProvider.Ins.DB.Food.SingleOrDefault(p => p.FoodID == user.FoodID);
                switch (food.MealTime)
                {
                    case 3:
                        {
                            Breakfast_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                        }
                        break;
                    case 4:
                        {
                            Lunch_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                        }
                        break;
                    case 5:
                        {
                            Dinner_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                        }
                        break;
                    case 7:
                        {
                            Breakfast_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                            Lunch_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                        }
                        break;
                    case 8:
                        {
                            Breakfast_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                            Dinner_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                        }
                        break;
                    case 9:
                        {
                            Lunch_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                            Dinner_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                        }
                        break;
                    case 12:
                        {
                            Breakfast_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                            Lunch_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                            Dinner_food.Add(new FoodDays(food, user.Last_eat, user.Favorite));
                        }
                        break;
                }

            }
            if (IsLoadFood-- == 1)
            {
                tab_control.SelectedIndex = 0;
            }
            Gauge_Kcal.To = DataProvider.Ins.Kcal_UserID;
        }


        private void btn_them_Click(object sender, RoutedEventArgs e)
        {
            TabItem selected_tab = (TabItem)tab_control.SelectedItem;
            Food food = new Food();
            food = (Food)lvRecommendation.SelectedItem;
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
            food = lvRecommendation.SelectedItem as Food;
            UserFood userFood = DataProvider.Ins.DB.UserFood.SingleOrDefault(p => p.UserID == DataProvider.Ins.Current_UserID && p.FoodID == food.FoodID);
            userFood.Favorite = Convert.ToInt16(favorite_button.IsChecked);
            DataProvider.Ins.DB.SaveChanges();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            view = (CollectionView)CollectionViewSource.GetDefaultView(SelectedFood_lv.Items);

            if (cb.SelectedIndex == 0)
            {

            }
            else if (cb.SelectedIndex == 1)
            {

            }
            else if (cb.SelectedIndex == 2)
            {

            }
        }

        private void tab_control_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tab_control.SelectedIndex == 0)
            {
                foodList = Breakfast_food;
            }
            else if (tab_control.SelectedIndex == 1)
            {
                foodList = Lunch_food;
            }
            else if (tab_control.SelectedIndex == 2)
            {
                foodList = Dinner_food;
            }
        }

        private void lvRecommendation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FoodDays food = ((ListView)sender).SelectedItem as FoodDays;
            if (food == null)
            {
                food = foodList.First<FoodDays>();
            }
            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(food.Food.Imgsrc, UriKind.Relative);
            bitimg.EndInit();
            food_image.Source = bitimg;
            food_review.Text = food.Food.Descript;
            UserFood uf = DataProvider.Ins.DB.UserFood.SingleOrDefault(p => p.UserID == DataProvider.Ins.Current_UserID && p.FoodID == food.Food.FoodID);
            tb_calo.Text = food.Food.Kcal.Value.ToString();
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
    }
}
