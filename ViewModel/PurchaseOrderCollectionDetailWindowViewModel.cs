using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class PurchaseOrderCollectionDetailWindowViewModel : NotificationObject
    {
        private PurchaseOrderCollectionViewModel _purchaseOrderCollectionViewModel;
        public PurchaseOrderCollectionViewModel PurchaseOrderCollectionViewModel
        {
            get { return _purchaseOrderCollectionViewModel; }
            set { _purchaseOrderCollectionViewModel = value; RaisePropertyChanged("PurchaseOrderCollectionViewModel"); }
        }
        public PurchaseOrderCollectionDetailWindowViewModel(PurchaseOrderCollectionViewModel pocvm)
        {
            PurchaseOrderCollectionViewModel = pocvm;

        }
    }
}
