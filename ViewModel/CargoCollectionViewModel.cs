using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuzzySharp;
using System.Collections.ObjectModel;
using CargoManagementSystem.View;

namespace CargoManagementSystem.ViewModel
{
    public class CargoCollectionViewModel : NotificationObject
    {
        private int _orderScore;
        public DelegateCommand ShowDetailCommand { get; set; }
        public DelegateCommand SellCommand { get; set; }
        public DelegateCommand DeleteCargoCollectionCommand { get; set; }

        public CargoManagementContext CMContext { get; set; }
        public CargoCollection CargoCollection { get; set; }
        public BlockViewModel BlockViewModel { get; set; }
        private PurchasePrizeDic _selectedPurchasePrizeDic;

        public PurchasePrizeDic SelectedPurchasePrizeDic
        {
            get { return _selectedPurchasePrizeDic; }
            set { _selectedPurchasePrizeDic = value; RaisePropertyChanged("SelectedPurchasePrizeDic"); }
        }
        public ObservableCollection<CargoCollectionViewModel> CargoCollectionViewModels { get; set; }
        public int OrderScore
        {
            get { return _orderScore; }
            set { _orderScore = value; RaisePropertyChanged("OrderScore"); }
        }
        private SellOrderCollectionViewModel SellOrderCollectionViewModel { get; set; }

        public CargoCollectionViewModel()
        {
            SelectedPurchasePrizeDic = new PurchasePrizeDic();
            ShowDetailCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ShowDetailExecute) };
            SellCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddSellOrderExecute) };
            DeleteCargoCollectionCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteCargoCollectionExecute), CanExecuteFunc = new Func<object, bool>(AddSellOrderCanExecute) };
        }
        public CargoCollectionViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            SelectedPurchasePrizeDic = new PurchasePrizeDic();
            ShowDetailCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ShowDetailExecute) };
            SellCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddSellOrderExecute), CanExecuteFunc = new Func<object, bool>(AddSellOrderCanExecute) };
        }
        public CargoCollectionViewModel(CargoManagementContext cmContext, PurchaseOrderViewModel purchaseOrderViewModel)
        {
            CMContext = cmContext;
            CargoCollection = new CargoCollection(purchaseOrderViewModel.PurchaseOrder);
            SelectedPurchasePrizeDic = new PurchasePrizeDic();
            ShowDetailCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ShowDetailExecute) };
            SellCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddSellOrderExecute) , CanExecuteFunc = new Func<object, bool>(AddSellOrderCanExecute)};
        }
        public void UpdateOrderScore(string SearchString)
        {
            int score1 = Fuzz.Ratio(SearchString, CargoCollection.PreciseCargoName);
            int score2 = Fuzz.Ratio(SearchString, CargoCollection.Cargo.CargoName);
            OrderScore = Math.Max(score1, score2);
        }
        public void ShowDetailExecute(object parameter)
        {
            CargoCollectionDetailWindow cargoCollectionDetailWindow = new CargoCollectionDetailWindow(CMContext, CargoCollection);
            cargoCollectionDetailWindow.Show();
        }
        public void DeleteCargoCollectionExecute(object parameter)
        {
            DeleteCargoCollection();
        }
        public bool AddSellOrderCanExecute(object parameter)
        {
            SellCargoUserControl sc = parameter as SellCargoUserControl;
            SellCargoUserControlViewModel scvm = sc.DataContext as SellCargoUserControlViewModel;
            if (scvm.SellOrderCollectionViewModel == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AddSellOrderExecute(object parameter)
        {
            SellCargoUserControl sellCargoUserControl = parameter as SellCargoUserControl;
            SellCargoUserControlViewModel sellCargoUserControlvm = sellCargoUserControl.DataContext as SellCargoUserControlViewModel;
            SellOrderCollectionViewModel = sellCargoUserControlvm.SellOrderCollectionViewModel;
            if (sellCargoUserControlvm.OutSellOrderButtonIsEnabled == false)
            {
                string message = "尚未创建订单";
                string detailMessage = "卖出货品前，需要首先创建一个订单，每次卖出物品会在订单中添加一个条目";
                WarningWindow warn = new WarningWindow(message, detailMessage);
                warn.ShowDialog();
            }
            else
            {
                bool IsExist = SellOrderCollectionViewModel.SellOrderViewModels.Any<SellOrderViewModel>
                    (item => item.SellOrder.WarehouseName == CargoCollection.WarehouseName &&
                    item.SellOrder.PlaneName == CargoCollection.PlaneName &&
                    item.SellOrder.BlockName == CargoCollection.BlockName &&
                    item.SellOrder.PreciseCargoName == CargoCollection.PreciseCargoName);
                if (IsExist)
                {
                    string message = "订单中已存在同名条目";
                    string detailMessage = string.Format("同一订单中的不同条目之间，以下四个项目应至少有一个不重复：仓库名称，楼层名称，区域名称，货品名称");
                    WarningWindow warn = new WarningWindow(message, detailMessage);
                    warn.ShowDialog();
                }
                else
                {
                    AddSellOrderWindow addSellOrderWindow = new AddSellOrderWindow(CargoCollection);
                    AddSellOrderWindowViewModel addSellOrderWindowvm = addSellOrderWindow.DataContext as AddSellOrderWindowViewModel;
                    addSellOrderWindowvm.CallBack = new Action<SellOrder>(CallBack);
                    addSellOrderWindow.Show();
                }
            }
        }
        public void CallBack(SellOrder sellOrder)
        {
            if (sellOrder != null)
            {
                int BufferAmount = sellOrder.Amount;
                double BufferTotalPurchasePrize = 0;
                foreach (var dic in CargoCollection.PurchasePrizeDics)
                {
                    if (dic.UnitPurchasePrize == -1)
                    {
                        continue;
                    }
                    else if (BufferAmount == 0)
                    {
                        break;
                    }
                    else if (dic.Amount >= BufferAmount)
                    {
                        BufferTotalPurchasePrize += dic.UnitPurchasePrize * BufferAmount;
                        BufferAmount = 0;
                    }
                    else if (dic.Amount < BufferAmount)
                    {
                        BufferTotalPurchasePrize += dic.UnitPurchasePrize * dic.Amount;
                        BufferAmount -= dic.Amount;
                    }
                }
                sellOrder.AvgUnitPurchasePrize = BufferTotalPurchasePrize / sellOrder.Amount;
                SellOrderCollectionViewModel.SellOrderCollection.TotalPurchasePrize = BufferTotalPurchasePrize;
                SellOrderCollectionViewModel.SellOrderCollection.TotalSellPrize += sellOrder.UnitSellPrize * sellOrder.Amount;
                SellOrderCollectionViewModel.SellOrderCollection.TotalProfit = SellOrderCollectionViewModel.SellOrderCollection.TotalSellPrize - SellOrderCollectionViewModel.SellOrderCollection.TotalPurchasePrize;
                SellOrderViewModel sellOrderViewModel = new SellOrderViewModel(CMContext, this);
                sellOrder.PreciseCargoName = CargoCollection.PreciseCargoName;
                sellOrder.CargoName = CargoCollection.Cargo.CargoName;
                sellOrder.Material = CargoCollection.Cargo.Material;
                sellOrder.Category = CargoCollection.Cargo.Category;
                sellOrder.StdCategory = CargoCollection.Cargo.StdCategory;
                sellOrder.StdName = CargoCollection.Cargo.StdName;
                sellOrder.Size = CargoCollection.Cargo.Size;
                sellOrder.SizeUnit = CargoCollection.Cargo.SizeUnit;
                sellOrder.WarehouseName = CargoCollection.WarehouseName;
                sellOrder.PlaneName = CargoCollection.PlaneName;
                sellOrder.BlockName = CargoCollection.BlockName;
                sellOrderViewModel.SellOrder = sellOrder;
                sellOrderViewModel.CargoCollectionViewModel = this;
                sellOrderViewModel.SellOrderCollectionViewModel = SellOrderCollectionViewModel;
                SellOrderCollectionViewModel.SellOrderViewModels.Add(sellOrderViewModel);
            }
        }
        public void DeleteCargoCollection()
        {
            BlockViewModel.CargoCollectionViewModels.Remove(this);
            CargoCollectionViewModels.Remove(this);
            CMContext.CargoCollection.Remove(CargoCollection);
            CMContext.SaveChanges();
        }
    }
}
