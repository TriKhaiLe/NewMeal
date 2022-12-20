using Project.Model;
using Project.Pages.SubFoodPage;
using Project.ViewModel;
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
        public List<Food> foodList 
        {
            get; set; 
        }
        
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


            Gauge_Kcal.To = 2800;
           
            textchangebytime();
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.Items);
            view.Filter = UserFilter;
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

            Food food = (Food)lvDataBinding.SelectedItem;
            if(food != null)
            {
                Gauge_Kcal.Value +=(double) food.Kcal;
                SelectedFood_lv.Items.Add(food);
                if (Gauge_Kcal.Value > Gauge_Kcal.To)
                {
                    kcal_txt.Visibility = Visibility.Visible;
                }
            }
            
        }

        private void ComButton_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            ComboBox_sort.Text = null;
            
            foodList = Com;
            foreach(Food fo in foodList)
            {
                lvDataBinding.Items.Add(fo);
            }

            //lvDataBinding.ItemsSource = foodList;

        }
        private void foodpage_Loaded(object sender, RoutedEventArgs e)
        {
            
            Food food = new Food();
            FoodUser = DataProvider.Ins.DB.UserFood.Where(p => p.UserID == DataProvider.Ins.Current_UserID).ToList();
            //MessageBox.Show(FoodUser.Count().ToString());
            
            foreach (UserFood user in FoodUser)
            {
                food = DataProvider.Ins.DB.Food.SingleOrDefault(p => p.FoodID == user.FoodID);
                switch (food.Type)
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
            ComRadioBtn.IsChecked = true;
            
            
        }

        private void MNButton_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            ComboBox_sort.Text = null;
            foodList = MonNuoc;
            
            foreach (Food fo in foodList)
            {
                lvDataBinding.Items.Add(fo);
            }
            //lvDataBinding.ItemsSource = foodList;
            
        }

        private void DBButton_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            ComboBox_sort.Text = null;
            foodList = DoBien;
            
            foreach (Food fo in foodList)
            {
                lvDataBinding.Items.Add(fo);
            }
            //lvDataBinding.ItemsSource = foodList;
           /* view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.Items);
            view.Filter = UserFilter;*/
        }

        private void CanhButton_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            ComboBox_sort.Text = null;
            foodList = Canh;
            
            foreach (Food fo in foodList)
            {
                lvDataBinding.Items.Add(fo);
            }
            //lvDataBinding.ItemsSource = foodList;
            /*view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.Items);
            view.Filter = UserFilter;*/
        }

        private void TUButton_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            ComboBox_sort.Text = null;
            foodList = ThucUong;
            foreach (Food fo in foodList)
            {
                lvDataBinding.Items.Add(fo);
            }
            //lvDataBinding.ItemsSource = foodList;
            /*view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.Items);
            view.Filter = UserFilter;*/
        }

        private void AVButton_Checked(object sender, RoutedEventArgs e)
        {
            lvDataBinding.Items.Clear();
            ComboBox_sort.Text = null;
            foodList = AnVat;
            foreach (Food fo in foodList)
            {
                lvDataBinding.Items.Add(fo);
            }
            //lvDataBinding.ItemsSource = foodList;
            /*view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.Items);
            view.Filter = UserFilter;*/
        }

        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvDataBinding.Items.Filter = UserFilter;
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            MessageBox.Show(comboBox.SelectedValue.ToString());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvDataBinding.Items);
            
            if (cb.SelectedIndex == 0)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("Kcal", ListSortDirection.Ascending));
                
            }
            else if (cb.SelectedIndex == 1)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription("FoodName", ListSortDirection.Ascending));
                
            }
            
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            InsertFoodWindow insertFoodWindow = new InsertFoodWindow();
            insertFoodWindow.Owner = Window.GetWindow(this);
            insertFoodWindow.ShowDialog();
            
        }

        private void ReviewRecipeBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if(SelectedFood_lv.Items.Count == 0)
            {
                MessageBox.Show("Hiện tại món đã chọn đang trống !");
            }
            else
            {
                RecipeWindow recipeWindow = new RecipeWindow();
                recipeWindow.recipe_lv.ItemsSource = SelectedFood_lv.Items;
                recipeWindow.Owner = Window.GetWindow(this);
                recipeWindow.ShowDialog();
            }    
            
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Food food = button.DataContext as Food;
            DataProvider.Ins.DB.UserFood.Remove(DataProvider.Ins.DB.UserFood.SingleOrDefault(p => p.FoodID == food.FoodID && p.UserID == DataProvider.Ins.Current_UserID));
            DataProvider.Ins.DB.SaveChanges();
            lvDataBinding.Items.Remove(food);

        }


        private void DelSelected_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Food food = button.DataContext as Food;
            Gauge_Kcal.Value -= (double) food.Kcal;
            SelectedFood_lv.Items.Remove(food);
            if (Gauge_Kcal.Value <= Gauge_Kcal.To)
            {
                kcal_txt.Visibility = Visibility.Hidden;
            }
        }
    }
}
