using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace Project.Pages.SubCalorieBurnPage
{
    /// <summary>
    /// Interaction logic for InsertExerciseWindow.xaml
    /// </summary>
    public partial class InsertExerciseWindow : Window
    {
        public InsertExerciseWindow()
        {
            InitializeComponent();
        }

        private void AddImg_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Title = "Hãy chọn 1 tấm ảnh";
            image.Filter = "Image (*.jpeg;*.png;*.jpg;*.gif)|*.jpeg;*.png;*.jpg;*.gif";
            if (image.ShowDialog() == true)
            {
                ExerciseImg.ImageSource = new BitmapImage(new Uri(image.FileName));
            }
        }
    }
}
