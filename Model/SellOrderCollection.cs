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
    [Table("SellOrderCollection")]
    public partial class SellOrderCollection : NotificationObject
    {
        private DateTime _sellTime;
        private double _totalPurchasePrize;
        private double _totalSellPrize;
        private double _totalProfit;
        private string _customerName;
        private string _customerTel;

        [Key]
        public DateTime SellTime
        {
            get { return _sellTime; }
            set { _sellTime = value; RaisePropertyChanged("SellTime"); }
        }
        public double TotalPurchasePrize
        {
            get { return _totalPurchasePrize; }
            set { _totalPurchasePrize = value; RaisePropertyChanged("TotalPurchasePrize"); }
        }
        public double TotalSellPrize
        {
            get { return _totalSellPrize; }
            set { _totalSellPrize = value; RaisePropertyChanged("TotalSellPrize"); }
        }
        public double TotalProfit
        {
            get { return _totalProfit; }
            set { _totalProfit = value; RaisePropertyChanged("TotalProfit"); }
        }
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; RaisePropertyChanged("CustomerName"); }
        }
        public string CustomerTel
        {
            get { return _customerTel; }
            set { _customerTel = value; RaisePropertyChanged("CustomerTel"); }
        }


        public SellOrderCollection()
        {
            SellOrders = new ObservableCollection<SellOrder>();
        }
        public virtual ObservableCollection<SellOrder> SellOrders { get; set; }
    }
}
