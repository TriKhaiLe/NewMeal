using Microsoft.Win32;
using Project.Model;
using Project.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.Pages.SubFoodPage
{
    /// <summary>
    /// Interaction logic for InsertFoodWindow.xaml
    /// </summary>
    public partial class InsertFoodWindow : Window
    {
        public static List<string> Types { get; set; }
        public string Text1 { get; set; }
        public InsertFoodWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Text1 = null;
            
            Types = new List<string>() { "Cơm", "Món nước", "Đồ biển", "Canh", "Thức uống", "Đồ ăn vặt" };
        }

        private void AddImgButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Hãy chọn 1 tấm ảnh";
            image.Filter = "Image (*.jpeg;*.png;*.jpg;*.gif)|*.jpeg;*.png;*.jpg;*.gif";
            if (image.ShowDialog() == true)
            {
                FoodImage.ImageSource = new BitmapImage(new Uri(image.FileName));
            }
        }

        private void Minize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Minimized)
            {
                this.WindowState = (WindowState.Minimized);
            }
            else { this.WindowState = WindowState.Normal; }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            int ok = 0;
            if (FoodName_txt.Text != null && Kcal_txt.Text != null && Type_cb.Text != null && Mealtime_lv.SelectedItems.Count > 0)
            {
                int kcal = 0;
                try
                {
                    kcal = Convert.ToInt32(Kcal_txt.Text);
                    if (kcal < 0)
                    {
                        MessageBox.Show("Xin vui lòng điền lượng kcal là số nguyên không âm!");
                    }
                    else { ok = 1; }
                }
                catch
                {
                    MessageBox.Show("Xin vui lòng điền lượng kcal là số nguyên không âm!");
                }

                if (ok == 1)
                {
                    Food food = new Food();
                    food.FoodName = FoodName_txt.Text;
                    food.Kcal = kcal;
                    food.Imgsrc = FoodImage.ImageSource.ToString();
                    int mealtime = 0;
                    foreach (ListBoxItem item in Mealtime_lv.SelectedItems)
                    {
                        string period = item.Content.ToString();
                        if (period == "Sáng") mealtime += 3;
                        if (period == "Trưa") mealtime += 4;
                        if (period == "Tối") mealtime += 5;
                    }
                    food.MealTime = mealtime;
                    food.Ingredients = Ingredients_txt.Text;
                    food.Recipe = Recipe_txt.Text;
                    food.Descript = Descript_txt.Text;
                    food.Type = Type_cb.Text;
                    DataProvider.Ins.DB.Food.Add(food);
                    DataProvider.Ins.DB.SaveChanges();
                    UserFood userFood = new UserFood();
                    userFood.UserID = DataProvider.Ins.Current_UserID;
                    userFood.FoodID = food.FoodID;
                    userFood.Favorite =(int) FoodRatingBar.Value;
                    DataProvider.Ins.DB.UserFood.Add(userFood);
                    DataProvider.Ins.DB.SaveChanges();
                    MainWindow mainWindow = this.Owner as MainWindow;
                    mainWindow.Main.Refresh();
                    //FoodPage foodPage = this.Parent as FoodPage;
                   
                    
                }
                MessageBox.Show("Món ăn của bạn đã được thêm vào !");
            }
            else
            {
                MessageBox.Show("Nhập thiếu thông tin bắt buộc !");
            }
            //MessageBox.Show(DataProvider.Ins.DB.Food.Count().ToString());
        }
    }
    
}
