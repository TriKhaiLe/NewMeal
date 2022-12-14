using Project.Model;
using Project.ViewModel;
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
    /// Interaction logic for FoodPage.xaml
    /// </summary>
    public partial class FoodPage : Page
    {
        public List<UserFood> FoodUser { get; set; }
        public List<Food> Com { get; set; }
        public List<Food> MonNuoc { get; set; }
        public List<Food> DoBien { get; set; }
        public List<Food> Canh { get; set; }
        public List<Food> ThucUong { get; set; }
        public List<Food> AnVat { get; set; }
        public List<Food> foodList { get; set; }
        CollectionView view;
        public FoodPage()
        {
            InitializeComponent();
            this.DataContext = this;
            Com = new List<Food>();
            MonNuoc = new List<Food>();
            Canh = new List<Food>();
            DoBien = new List<Food>();
            ThucUong = new List<Food>();
            AnVat = new List<Food>();
            foodList = new List<Food>();
            FoodUser = new List<UserFood>();
            foodList = DataProvider.Ins.DB.Food.ToList();
            lvDataBinding.ItemsSource = foodList;

            view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource);
            view.Filter = UserFilter;

            textchangebytime();
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Food).FoodName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        public void textchangebytime()
        {

            int time = Convert.ToInt32(DateTime.Now.Hour.ToString());
            if (time >= 4 && time < 11)
            {
                HelloTime_tb.Text = "Chào buổi sáng !";
            }
            else if (time >= 11 && time <= 12)
            {
                HelloTime_tb.Text = "Chào buổi trưa !";
            }
            else if (time > 12 && time < 18)
            {
                HelloTime_tb.Text = "Chào buổi chiều !";
            }
            else HelloTime_tb.Text = "Chào buổi tối !";
        }

        private void lvDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedFood_lv.Items.Add(lvDataBinding.SelectedItem);
        }

        private void ComButton_Checked(object sender, RoutedEventArgs e)
        {
            
            lvDataBinding.ItemsSource = Com;
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource);
            view.Filter = UserFilter;
        }
        private void foodpage_Loaded(object sender, RoutedEventArgs e)
        {
            
            Food food = new Food();
            FoodUser = DataProvider.Ins.DB.UserFood.Where(p => p.UserID == DataProvider.Ins.Current_UserID).ToList();
            
            foreach (UserFood user in FoodUser)
            {
                
                food = DataProvider.Ins.DB.Food.SingleOrDefault(p => p.FoodID == user.FoodID); 
                switch(food.Type)
                {
                    case "Cơm":
                        Com.Add(food);
                        break;
                    case "Món nước":
                        MonNuoc.Add(food);
                        break;
                    case "Canh":
                        Canh.Add(food);
                        break;
                    case "Thức uống":
                        ThucUong.Add(food);
                        break;
                    case "Đồ biển":
                        DoBien.Add(food);
                        break;
                    default:
                        AnVat.Add(food);
                        break;
                }    
            }
            
            
        }

        private void MNButton_Checked(object sender, RoutedEventArgs e)
        {

            lvDataBinding.ItemsSource = MonNuoc;
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource);
            view.Filter = UserFilter;
        }

        private void DBButton_Checked(object sender, RoutedEventArgs e)
        {

            lvDataBinding.ItemsSource = DoBien;
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource);
            view.Filter = UserFilter;
        }

        private void CanhButton_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.ItemsSource = Canh;
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource);
            view.Filter = UserFilter;
        }

        private void TUButton_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.ItemsSource = ThucUong;
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource);
            view.Filter = UserFilter;
        }

        private void AVButton_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.ItemsSource = AnVat;
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource);
            view.Filter = UserFilter;
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(lvDataBinding.ItemsSource).Refresh();
        }
    }
}
