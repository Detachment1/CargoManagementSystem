using CargoManagementSystem.Service;
using CargoManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CargoManagementSystem.View
{
    /// <summary>
    /// Interaction logic for SellCargoUserControl.xaml
    /// </summary>
    public partial class SellCargoUserControl : UserControl
    {
        public SellCargoUserControl(CargoManagementContext CMContext, ObservableCollection<CargoCollectionViewModel> ccvms, ObservableCollection<SellOrderCollectionViewModel> socvms)
        {
            InitializeComponent();
            this.DataContext = new SellCargoUserControlViewModel(CMContext, ccvms, socvms);
            
        }
    }
}
