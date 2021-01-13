using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class SellOrderViewModel : NotificationObject
    {
        private SellOrder _sellOrder;
        private CargoCollectionViewModel _cargoCollectionViewModel;
        public SellOrder SellOrder
        {
            get { return _sellOrder; }
            set { _sellOrder = value; RaisePropertyChanged("SellOrder"); }
        }
        public CargoCollectionViewModel CargoCollectionViewModel
        {
            get { return _cargoCollectionViewModel; }
            set { _cargoCollectionViewModel = value; RaisePropertyChanged("CargoCollectionViewModel"); }
        }
        public SellOrderCollectionViewModel SellOrderCollectionViewModel { get; set; }


        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand ShowDetailCommand { get; set; }
        public CargoManagementContext CMContext { get; set; }
        public SellOrderViewModel(CargoManagementContext cmContext, CargoCollectionViewModel cargoCollectionViewModel)
        {
            CMContext = cmContext;
            CargoCollectionViewModel = cargoCollectionViewModel;
            DeleteCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteExecute) };
            ShowDetailCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ShowDetailExecute) };
        }
        private void DeleteExecute(object parameter)
        {
            SellOrderCollectionViewModel.SellOrderCollection.TotalPurchasePrize -= SellOrder.Amount * SellOrder.AvgUnitPurchasePrize;
            SellOrderCollectionViewModel.SellOrderCollection.TotalSellPrize -= SellOrder.Amount * SellOrder.UnitSellPrize;
            SellOrderCollectionViewModel.SellOrderCollection.TotalProfit = SellOrderCollectionViewModel.SellOrderCollection.TotalSellPrize - SellOrderCollectionViewModel.SellOrderCollection.TotalPurchasePrize;
            SellOrderCollectionViewModel.SellOrderViewModels.Remove(this);
        }
        private void ShowDetailExecute(object parameter)
        {

        }
    }
}
