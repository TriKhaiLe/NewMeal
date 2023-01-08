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
using Project.Pages;
using Project.Pages.SubCalorieBurnPage;

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

        private int _remainingTime = 0;
        private int _totalCalo = 0;
        private double _caloBurnedPerSec = 0;
        private double _burnedCalo = 0;

        public CalorieBurnPage()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromSeconds(1);
            this.DataContext = this;
            ExerciseUser = new List<UserExercise>();
            ExerciseList = new List<Exercise>();

            Play_btn.IsEnabled = false;
            Pause_btn.IsEnabled = false;
        }

        private void CaloBurnPage_Loaded(object sender, RoutedEventArgs e)
        {
            ExerciseUser = DataProvider.Ins.DB.UserExercise.Where(p => p.UserID == DataProvider.Ins.Current_UserID).ToList();
            Exercise exercise = new Exercise();
            ExerciseList = new List<Exercise>();

            foreach (UserExercise user in ExerciseUser)
            {
                exercise = DataProvider.Ins.DB.Exercise.SingleOrDefault(p => p.ExID == user.ExID);
                ExerciseList.Add(exercise);
            }

            lvCaloriesBurned.ItemsSource = ExerciseList;
            _view = (CollectionView)CollectionViewSource.GetDefaultView(lvCaloriesBurned.ItemsSource);
            _view.Filter = UserFilter;
        }


        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            lvCaloriesBurned.Items.Filter = UserFilter;
        }

        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(txtFilter.Text))
                return true;
            else
                return ((item as Exercise).ExName.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }


        private void Count_Tick(object sender, EventArgs e)
        {
            if (_remainingTime-- <= 0)
            {
                _timer.Stop();
                Pause_btn.IsEnabled = false;
                MessageBox.Show("Chúc mừng bạn đã hoàn thành buổi tập!\nMời bạn tính lại lượng calo");
                return;
            }

            // tang so calo dot moi giay
            _burnedCalo += _caloBurnedPerSec;
            Gauge_Kcal.Value = (int)_burnedCalo;

            // giam tong so calo can tinh
            _totalCalo -= (int)Gauge_Kcal.Value;
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

        private void Calculate_btn_Click(object sender, RoutedEventArgs e)
        {
            // nhan so calo moi, kiem tra hop le
            if (!int.TryParse(CaloBox.Text, out _totalCalo))
            {
                MessageBox.Show("Số calo nhập vào chưa hợp lệ!");
                return;
            }
            // reset calo da dot, item da chon
            _burnedCalo = 0;
            lvCaloriesBurned.SelectedIndex = -1;

            // reset dong ho
            MessageBox.Show("Đã tính xong, mời bạn chọn bài tập");
            _timer.Stop();
            _timer.Tick -= Count_Tick;
            CountdownTimer.Text = TimeSpan.FromSeconds(0).ToString();

            // reset dong ho calo
            Gauge_Kcal.To = _totalCalo;
            Gauge_Kcal.Value = 0;

        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            InsertExerciseWindow insertExerciseWindow = new InsertExerciseWindow();
            insertExerciseWindow.Owner = Window.GetWindow(this);
            insertExerciseWindow.ShowDialog();
            _view.Refresh();
        }

        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn xóa bài tập này không ?") == MessageBoxResult.OK)
            {
                Button button = (Button)sender;
                Exercise exercise = button.DataContext as Exercise;

                // xoa userEx khoi DB
                DataProvider.Ins.DB.UserExercise.Remove(DataProvider.Ins.DB.UserExercise.SingleOrDefault(p => p.ExID == exercise.ExID && p.UserID == DataProvider.Ins.Current_UserID));

                // khong xoa nhung bai tap mac dinh
                if (exercise.ExID > 15)
                    DataProvider.Ins.DB.Exercise.Remove(exercise);

                DataProvider.Ins.DB.SaveChanges();

                ExerciseList.Remove(exercise);
                _view.Refresh();
            }
        }


        private void lvCaloriesBurned_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_totalCalo <= 0 || lvCaloriesBurned.SelectedIndex == -1)
                return;

            _timer.Stop();
            _timer.Tick -= Count_Tick;
            if (MessageBox.Show("Bạn muốn chọn bài tập này?", "Thông báo", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // kich hoat nut play
                Play_btn.IsEnabled = true;

                Exercise exercise = (Exercise)lvCaloriesBurned.SelectedItem;

                // tinh tong thoi gian va calo dot moi giay
                _remainingTime = _totalCalo * 3600 / (int)exercise.Kps;
                _caloBurnedPerSec = (double)exercise.Kps / 3600;

                // hien thi thoi gian
                CountdownTimer.Text = TimeSpan.FromSeconds(_remainingTime).ToString();
            }
            else
                _timer.Start();

        }
    }

}

