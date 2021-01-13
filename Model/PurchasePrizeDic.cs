using CargoManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.Model
{
    [Table("PurchasePrizeDic")]
    public partial class PurchasePrizeDic : NotificationObject
    {
        private string _warehouesName;
        private string _planeName;
        private string _blockName;
        private string _preciseCargoName;
        private double _unitPurchasePrize;
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
        [Key]
        [Column(Order = 4)]
        public double UnitPurchasePrize
        {
            get { return _unitPurchasePrize; }
            set { _unitPurchasePrize = value; RaisePropertyChanged("UnitPurchasePrize"); }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; RaisePropertyChanged("Amount"); }
        }

        public PurchasePrizeDic()
        {

        }
        public PurchasePrizeDic(PurchaseOrder purchaseOrder)
        {
            WarehouseName = purchaseOrder.WarehouseName;
            PlaneName = purchaseOrder.PlaneName;
            BlockName = purchaseOrder.BlockName;
            PreciseCargoName = purchaseOrder.PreciseCargoName;
            UnitPurchasePrize = purchaseOrder.UnitPurchasePrize;
            Amount = purchaseOrder.Amount;
        }

        public virtual CargoCollection CargoCollection { get; set; }
    }
}
