using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class PurchaseOrderViewModel : NotificationObject
    {
        public PurchaseOrder PurchaseOrder { get; set; }
        public BlockViewModel BlockViewModel { get; set; }
        public PurchaseOrderCollectionViewModel PurchaseOrderCollectionViewModel { get; set; }
        public DelegateCommand DeletePurchaseOrderCommand { get; set; }
        public DelegateCommand ShowDetailCommand { get; set; }
        public CargoManagementContext CMContext { get; set; }
        public PurchaseOrderViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            PurchaseOrder = new PurchaseOrder();
            BlockViewModel = new BlockViewModel(CMContext);
            PurchaseOrderCollectionViewModel = new PurchaseOrderCollectionViewModel(CMContext);
            DeletePurchaseOrderCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeletePurchaseOrderExecute) };
            ShowDetailCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ShowDetailExecute) };
        }
        private void DeletePurchaseOrderExecute(object parameter)
        {
            PurchaseOrderCollectionViewModel.PurchaseOrderCollection.TotalPurchasePrize -= PurchaseOrder.Amount * PurchaseOrder.UnitPurchasePrize;
            PurchaseOrderCollectionViewModel.PurchaseOrderViewModels.Remove(this);
        }
        private void ShowDetailExecute(object parameter)
        {
            
        }
    }
}
