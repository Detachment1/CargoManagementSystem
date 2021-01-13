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
    /// Interaction logic for PurchaseCargoUserControl.xaml
    /// </summary>
    public partial class PurchaseCargoUserControl : UserControl
    {
        public PurchaseCargoUserControl(CargoManagementContext CMContext, WarehouseRootViewModel wrvm, ObservableCollection<CargoViewModel> cvms, ObservableCollection<CargoCollectionViewModel> ccvms, ObservableCollection<PurchaseOrderCollectionViewModel> pocvms)
        {
            InitializeComponent();
            this.DataContext = new PurchaseCargoUserControlViewModel(CMContext, wrvm, cvms, ccvms, pocvms);
        }
    }
}
