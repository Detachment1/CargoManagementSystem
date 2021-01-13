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
    [Table("PurchaseOrder")]
    public partial class PurchaseOrder : NotificationObject
    {
        private string _warehouesName;
        private string _planeName;
        private string _blockName;
        private string _preciseCargoName;
        private DateTime _purchaseTime;
        private double _unitPurchasePrize;
        private int _amount;
        private string _supplierName;
        private string _supplierTel;
        private string _cargoName;
        private string _material;
        private string _category;
        private string _stdCategory;
        private string _stdName;
        private string _size;
        private string _sizeUnit;




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
        public DateTime PurchaseTime
        {
            get { return _purchaseTime; }
            set { _purchaseTime = value; RaisePropertyChanged("PurchaseTime"); }
        }
        [Key]
        [Column(Order = 5)]
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
        public string SupplierName
        {
            get { return _supplierName; }
            set { _supplierName = value; RaisePropertyChanged("SupplierName"); }
        }
        public string SupplierTel
        {
            get { return _supplierTel; }
            set { _supplierTel = value; RaisePropertyChanged("SupplierTel"); }
        }
        public string CargoName
        {
            get { return _cargoName; }
            set { _cargoName = value; RaisePropertyChanged("CargoName"); }
        }
        public string Material
        {
            get { return _material; }
            set { _material = value; RaisePropertyChanged("Material"); }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; RaisePropertyChanged("Category"); }
        }
        public string StdCategory
        {
            get { return _stdCategory; }
            set { _stdCategory = value; RaisePropertyChanged("StdCategory"); }
        }
        public string StdName
        {
            get { return _stdName; }
            set { _stdName = value; RaisePropertyChanged("StdName"); }
        }
        public string Size
        {
            get { return _size; }
            set { _size = value; RaisePropertyChanged("Size"); }
        }
        public string SizeUnit
        {
            get { return _sizeUnit; }
            set { _sizeUnit = value; RaisePropertyChanged("SizeUnit"); }
        }

        public virtual PurchaseOrderCollection PurchaseOrderCollection { get; set; }
    }
}
