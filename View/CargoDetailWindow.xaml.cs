using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.ViewModel;
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

namespace CargoManagementSystem.View
{
    /// <summary>
    /// Interaction logic for CargoDetailWindow.xaml
    /// </summary>
    public partial class CargoDetailWindow : Window
    {
        public CargoDetailWindow(CargoManagementContext cmContext, Cargo Cargo)
        {
            InitializeComponent();
            this.DataContext = new CargoDetailWindowViewModel(cmContext, Cargo);
        }
    }
}
