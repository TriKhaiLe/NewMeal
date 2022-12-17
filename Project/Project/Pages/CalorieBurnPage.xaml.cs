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
    /// Interaction logic for CalorieBurnPage.xaml
    /// </summary>
    public partial class CalorieBurnPage : Page
    {
        public List<Exercise> ExerciseList { get; set; }
        public List<UserExercise> ExerciseUser { get; set; }

        public CalorieBurnPage()
        {
            ExerciseUser = new List<UserExercise>();
            ExerciseList = DataProvider.Ins.DB.Exercise.ToList();
            //lvCaloriesBurned.ItemsSource = ExerciseList;

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
