using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CargoManagementSystem.ViewModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.Model
{
    [Table("CargoCollection")]
    public partial class CargoCollection : NotificationObject
    {
        private string _warehouesName;
        private string _planeName;
        private string _blockName;
        private string _preciseCargoName;
        private int _amount;

        [Key]
        [Column(Order = 0)]
        public string WarehouseName
        {
            get { return _warehouesName; }
            set { _warehouesName = value; RaisePropertyChanged("WarehouseName"); }
        }
        [Key]
        [Column(Order = 1)]
        public string PlaneName
        {
            get { return _planeName; }
            set { _planeName = value; RaisePropertyChanged("PlaneName"); }
        }
        [Key]
        [Column(Order = 2)]
        public string BlockName
        {
            get { return _blockName; }
            set { _blockName = value; RaisePropertyChanged("BlockName"); }
        }
        [Key]
        [Column(Order = 3)]
        public string PreciseCargoName
        {
            get { return _preciseCargoName; }
            set { _preciseCargoName = value; RaisePropertyChanged("PreciseCargoName"); }
        }

        public int Amount 
        {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged("Amount");}
        }

        public CargoCollection()
        {
            PurchasePrizeDics = new ObservableCollection<PurchasePrizeDic>();
        }
        public CargoCollection(PurchaseOrder purchaseOrder)
        {
            WarehouseName = purchaseOrder.WarehouseName;
            PlaneName = purchaseOrder.PlaneName;
            BlockName = purchaseOrder.BlockName;
            Amount = purchaseOrder.Amount;
            PreciseCargoName = purchaseOrder.PreciseCargoName;
            PurchasePrizeDics = new ObservableCollection<PurchasePrizeDic>();
        }
        public virtual Cargo Cargo { get; set; }
        public virtual Block Block { get; set; }

        public virtual ObservableCollection<PurchasePrizeDic> PurchasePrizeDics { get; set; }
    }
}
