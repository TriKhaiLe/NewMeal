using Project.Model;
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
    /// Interaction logic for CalorieBurnPage.xaml
    /// </summary>
    public partial class CalorieBurnPage : Page
    {
        public List<Exercise> ExerciseList { get; set; }
        public List<UserExercise> ExerciseUser { get; set; }
        CollectionView view;

        public CalorieBurnPage()
        {
            InitializeComponent();
            this.DataContext = this;

            ExerciseUser = new List<UserExercise>();

            ExerciseList = DataProvider.Ins.DB.Exercise.ToList();
            lvCaloriesBurned.ItemsSource = ExerciseList;
            view = (CollectionView)CollectionViewSource.GetDefaultView(lvCaloriesBurned.ItemsSource);
        }
        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }
        }


        private void Calculate(object sender, RoutedEventArgs e)
        {

            lvCaloriesBurned.ItemsSource = CalculateCalories(Convert.ToInt32(CaloBox.Text));
        }


        private List<string> CalculateCalories(int calories)
        {
            return new List<string> { calories.ToString() };
        }
    }
}
