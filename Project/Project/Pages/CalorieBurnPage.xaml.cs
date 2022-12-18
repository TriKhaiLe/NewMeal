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
using System.Windows.Threading;

namespace Project.Pages
{
    /// <summary>
    /// Interaction logic for CalorieBurnPage.xaml
    /// </summary>
    public partial class CalorieBurnPage : Page
    {
        public List<Exercise> ExerciseList { get; set; }
        public List<UserExercise> ExerciseUser { get; set; }

        private CollectionView _view;
        private DispatcherTimer _timer = new DispatcherTimer();
        private int _remainingTime = 20;

        public CalorieBurnPage()
        {
            InitializeComponent();

            _timer.Interval = TimeSpan.FromSeconds(1);

            //this.DataContext = this;

            //ExerciseUser = new List<UserExercise>();

            //ExerciseList = DataProvider.Ins.DB.Exercise.ToList();
            //lvCaloriesBurned.ItemsSource = ExerciseList;
            //_view = (CollectionView)CollectionViewSource.GetDefaultView(lvCaloriesBurned.ItemsSource);
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



        void Countdown(TimeSpan interval, Action<int> ts)
        {
            _timer.Interval = interval;
            _timer.Tick += (_, a) =>
            {
                if (_remainingTime-- == 0)
                    _timer.Stop();
                else
                    // show time string
                    ts(_remainingTime);
            };

            ts(_remainingTime);
            _timer.Start();
        }

        private void Count_Tick(object sender, EventArgs e)
        {
            if (_remainingTime-- <= 0)
                _timer.Stop();
            else
                // show time string
                CountdownTimer.Text = TimeSpan.FromSeconds(_remainingTime).ToString();
        }
        private void Play_btn_Click(object sender, RoutedEventArgs e)
        {
            _timer.Tick += Count_Tick;
            _timer.Start();
            (sender as Button).IsEnabled = false;
            Pause_btn.IsEnabled = true;
        }

        private void Pause_btn_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            _timer.Tick -= Count_Tick;
            (sender as Button).IsEnabled = false;
            Play_btn.IsEnabled = true;
        }
    }

}

