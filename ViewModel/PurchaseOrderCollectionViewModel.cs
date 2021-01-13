using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    
    public class PurchaseOrderCollectionViewModel : NotificationObject
    {
        public PurchaseOrderCollection PurchaseOrderCollection { get; set; }
        public ObservableCollection<PurchaseOrderViewModel> PurchaseOrderViewModels { get; set; }
        public ObservableCollection<PurchaseOrderCollectionViewModel> PurchaseOrderCollectionViewModels { get; set; }
        public CargoManagementContext CMContext { get; set; }
        public DelegateCommand ShowDetailCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public PurchaseOrderCollectionViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            PurchaseOrderCollection = new PurchaseOrderCollection();
            PurchaseOrderViewModels = new ObservableCollection<PurchaseOrderViewModel>();
            PurchaseOrderCollectionViewModels = new ObservableCollection<PurchaseOrderCollectionViewModel>();
            ShowDetailCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ShowDetailExecute) };
            DeleteCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteExecute) };
        }
        private void ShowDetailExecute(object parameter)
        {
            PurchaseOrderCollectionDetailWindow purchaseOrderCollectionDetailWindow = new PurchaseOrderCollectionDetailWindow(this);
            purchaseOrderCollectionDetailWindow.Show();
        }
        private void DeleteExecute(object parameter)
        {
            string message = "是否删除进货订单";
            string detailMessage = "删除的进货订单记录将无法恢复，请确认是否是删除该订单\n删除之前备份订单的信息以便错误删除后进行恢复";
            PromptWindow prompt = new PromptWindow(message, detailMessage);
            bool? IsConfirmed = prompt.ShowDialog();
            if (IsConfirmed == true)
            {
                PurchaseOrderCollectionViewModels.Remove(this);
                CMContext.PurchaseOrderCollection.Remove(PurchaseOrderCollection);
                CMContext.SaveChanges();
            }
        }
    }
}
