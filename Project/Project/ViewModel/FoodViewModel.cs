using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Project.ViewModel
{
    public class FoodViewModel:BaseViewModel
    {
        public ICommand LoadedCommand { get; set; }
        public FoodViewModel()
        {
            LoadedCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
            });
        }
    }
}
