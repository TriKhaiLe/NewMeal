using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Project.ViewModel
{
   
    public class MainViewModel
    {
        public ICommand LoadedCommand { get; set; }
        public MainViewModel()
        {
            LoadedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

            });
        } 
    }
}
