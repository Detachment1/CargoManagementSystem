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
    /// Interaction logic for PurchaseOrderCollectionDetailWindow.xaml
    /// </summary>
    public partial class PurchaseOrderCollectionDetailWindow : Window
    {
        public PurchaseOrderCollectionDetailWindow(PurchaseOrderCollectionViewModel pocvm)
        {
            InitializeComponent();
            this.DataContext = new PurchaseOrderCollectionDetailWindowViewModel(pocvm);
        }
    }
}
