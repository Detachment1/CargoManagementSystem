using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CargoManagementSystem.ViewModel
{
    public class AddSellOrderWindowViewModel : NotificationObject
    {
        private SellOrder _sellOrder;
        private CargoCollection _cargoCollection;
        public SellOrder SellOrder
        {
            get { return _sellOrder; }
            set { _sellOrder = value; RaisePropertyChanged("SellOrder"); }
        }
        public CargoCollection CargoCollection
        {
            get { return _cargoCollection; }
            set { _cargoCollection= value; RaisePropertyChanged("CargoCollection"); }
        }
        public Action<SellOrder> CallBack { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }
        public object WarningWindow { get; private set; }

        public AddSellOrderWindowViewModel(CargoCollection cargoCollection)
        {
            CargoCollection = cargoCollection;
            SellOrder = new SellOrder();
            CancelCommand = new DelegateCommand() { ExecuteAction = new Action<object>(CancelExecute) };
            ConfirmCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmExecute) };
        }
        private void CancelExecute(object parameter)
        {
            SellOrder = null;
            AddSellOrderWindow AddSellOrderWindow = parameter as AddSellOrderWindow;
            CallBack(SellOrder);
            AddSellOrderWindow.Close();
        }
        private void ConfirmExecute(object parameter)
        {
            bool IsValid = true;
            string message = "存在非法输入";
            string detailMessage = "";
            if (SellOrder.UnitSellPrize<=0)
            {
                detailMessage += "单位售价不允许小于等于零\n";
                IsValid = false;
            }
            if (SellOrder.Amount <= 0)
            {
                detailMessage += "数量不允许小于等于零\n";
                IsValid = false;
            }
            if (IsValid)
            {
                if (CargoCollection.Amount < SellOrder.Amount)
                {
                    string message2 = "货物数量不足";
                    string detailMessage2 = string.Format("仓库：{0}，楼层：{1}，区域：{2}中的商品：{3}，库存数量：{4}，订单要求卖出数量：{5}。数量不足！", CargoCollection.WarehouseName, CargoCollection.PlaneName, CargoCollection.BlockName, CargoCollection.Cargo.CargoName, CargoCollection.Amount, SellOrder.Amount);
                    WarningWindow warn = new WarningWindow(message2, detailMessage2);
                    warn.ShowDialog();
                }
                else
                {
                    CallBack(SellOrder);
                    AddSellOrderWindow AddSellOrderWindow = parameter as AddSellOrderWindow;
                    AddSellOrderWindow.Close();
                }
            }
            else
            {
                WarningWindow warn = new WarningWindow(message, detailMessage);
                warn.ShowDialog();
            }
            
        }
    }
}
