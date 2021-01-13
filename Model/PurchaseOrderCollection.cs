using CargoManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.Model
{
    [Table("PurchaseOrderCollection")]
    public partial class PurchaseOrderCollection : NotificationObject
    {
        private DateTime _purchaseTime;
        private double _totalPurchasePrize;

        [Key]
        public DateTime PurchaseTime
        {
            get { return _purchaseTime; }
            set { _purchaseTime = value; RaisePropertyChanged("PurchaseTime"); }
        }
        public double TotalPurchasePrize
        {
            get { return _totalPurchasePrize; }
            set { _totalPurchasePrize = value; RaisePropertyChanged("TotalPurchasePrize"); }
        }

        public PurchaseOrderCollection()
        {
            PurchaseOrders = new ObservableCollection<PurchaseOrder>();
        }
        public virtual ObservableCollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
