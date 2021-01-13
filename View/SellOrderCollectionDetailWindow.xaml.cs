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
    /// Interaction logic for SellOrderCollectionDetailWindow.xaml
    /// </summary>
    public partial class SellOrderCollectionDetailWindow : Window
    {
        public SellOrderCollectionDetailWindow(SellOrderCollectionViewModel socvm)
        {
            InitializeComponent();
            this.DataContext = new SellOrderCollectionDetailWindowViewModel(socvm);
        }
    }
}
