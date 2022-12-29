﻿using Project.Model;
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
using Project.Pages;

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

        private int _remainingTime = 300;
        private int _totalCalo = 0;
        private double _burnedCalo = 0;

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



        private void Count_Tick(object sender, EventArgs e)
        {
            if (_remainingTime-- <= 0)
                _timer.Stop();
            else
            {
                // test
                _burnedCalo += 1.27;
                Gauge_Kcal.Value = (int)_burnedCalo;
                CountdownTimer.Text = TimeSpan.FromSeconds(_remainingTime).ToString();

            }
            // show time string
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

        private void Calculate_btn_Click(object sender, RoutedEventArgs e)
        {
            // noi dung trong textbox khong hop le
            if (!int.TryParse(CaloBox.Text, out _totalCalo))
                return;

            Gauge_Kcal.To = _totalCalo;
        }
    }

}

