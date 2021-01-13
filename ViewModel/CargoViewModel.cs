using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using FuzzySharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CargoManagementSystem.ViewModel
{
    public class CargoViewModel : NotificationObject
    {
        private bool _purchaseButtonIsEnabled;
        private int _orderScore;
        public DelegateCommand ShowDetailCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand PurchaseCommand { get; set; }
        public CargoManagementContext CMContext { get; set; }
        public ObservableCollection<CargoViewModel> CargoViewModels { get; set; }
        public ObservableCollection<CargoCollectionViewModel> CargoCollectionViewModels { get; set; }
        public Cargo Cargo { get; set; }
        public bool PurchaseButtonIsEnabled
        {
            get { return _purchaseButtonIsEnabled; }
            set { _purchaseButtonIsEnabled = value; RaisePropertyChanged("PurchaseButtonIsEnabled"); }
        }
        public int OrderScore
        {
            get { return _orderScore; }
            set { _orderScore = value; RaisePropertyChanged("OrderScore"); }
        }
        private PurchaseOrderCollectionViewModel PurchaseOrderCollectionViewModel { get; set; }

        public CargoViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            CargoViewModels = new ObservableCollection<CargoViewModel>();
            ShowDetailCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ShowDetailExecute)};
            DeleteCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteExecute) };
            PurchaseCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddPurchaseOrderExecute), CanExecuteFunc = new Func<object, bool>(AddPurchaseOrderCanExecute) };
        }
        public void UpdateOrderScore(string SearchString)
        {
            int score1 = Fuzz.Ratio(SearchString, Cargo.PreciseCargoName);
            int score2 = Fuzz.Ratio(SearchString, Cargo.CargoName);
            OrderScore = Math.Max(score1, score2);
        }
        public void ShowDetailExecute(object parameter)
        {
            CargoDetailWindow cargoDetailWindow = new CargoDetailWindow(CMContext, Cargo);
            cargoDetailWindow.Show();
        }
        public void DeleteExecute(object parameter)
        {
            var p = CargoCollectionViewModels.Where<CargoCollectionViewModel>
                (item => item.CargoCollection.PreciseCargoName == Cargo.PreciseCargoName).ToList();
            foreach (var i in p)
            {
                i.DeleteCargoCollection();
            }
            CMContext.Cargo.Remove(Cargo);
            CargoViewModels.Remove(this);
            CMContext.SaveChanges();
        }
        public bool AddPurchaseOrderCanExecute(object parameter)
        {
            PurchaseCargoUserControl uc = parameter as PurchaseCargoUserControl;
            PurchaseCargoUserControlViewModel ucvm = uc.DataContext as PurchaseCargoUserControlViewModel;
            if (ucvm.PurchaseOrderCollectionViewModel == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AddPurchaseOrderExecute(object parameter)
        {
            PurchaseCargoUserControl purchaseCargoUserControl = parameter as PurchaseCargoUserControl;
            PurchaseCargoUserControlViewModel purchaseCargoUserControlvm = purchaseCargoUserControl.DataContext as PurchaseCargoUserControlViewModel;
            PurchaseOrderCollectionViewModel = purchaseCargoUserControlvm.PurchaseOrderCollectionViewModel;
            AddPurchaseOrderWindow addPurchaseWindow = new AddPurchaseOrderWindow(CMContext, purchaseCargoUserControlvm.WarehouseRootViewModel);
            AddPurchaseOrderWindowViewModel addPurchaseOrderWindowvm = addPurchaseWindow.DataContext as AddPurchaseOrderWindowViewModel;
            addPurchaseOrderWindowvm.CallBack = new Func<PurchaseOrderViewModel, bool>(CallBack);
            addPurchaseWindow.Show();
        }
        public bool CallBack(PurchaseOrderViewModel purchaseOrderViewModel)
        {
            if (purchaseOrderViewModel != null)
            {
                
                bool IsExist = PurchaseOrderCollectionViewModel.PurchaseOrderViewModels.Any<PurchaseOrderViewModel>
                    (item => item.PurchaseOrder.WarehouseName == purchaseOrderViewModel.PurchaseOrder.WarehouseName &&
                    item.PurchaseOrder.PlaneName == purchaseOrderViewModel.PurchaseOrder.PlaneName &&
                    item.PurchaseOrder.BlockName == purchaseOrderViewModel.PurchaseOrder.BlockName && 
                    item.PurchaseOrder.PreciseCargoName == Cargo.PreciseCargoName &&
                    item.PurchaseOrder.UnitPurchasePrize == purchaseOrderViewModel.PurchaseOrder.UnitPurchasePrize);
                if (!IsExist)
                {
                    purchaseOrderViewModel.PurchaseOrder.PreciseCargoName = Cargo.PreciseCargoName;
                    purchaseOrderViewModel.PurchaseOrder.Material = Cargo.Material;
                    purchaseOrderViewModel.PurchaseOrder.Size = Cargo.Size;
                    purchaseOrderViewModel.PurchaseOrder.SizeUnit = Cargo.SizeUnit;
                    purchaseOrderViewModel.PurchaseOrder.StdCategory = Cargo.StdCategory;
                    purchaseOrderViewModel.PurchaseOrder.StdName = Cargo.StdName;
                    purchaseOrderViewModel.PurchaseOrder.CargoName = Cargo.CargoName;
                    purchaseOrderViewModel.PurchaseOrder.Category = Cargo.Category;
                    purchaseOrderViewModel.PurchaseOrderCollectionViewModel = PurchaseOrderCollectionViewModel;
                    PurchaseOrderCollectionViewModel.PurchaseOrderCollection.TotalPurchasePrize += purchaseOrderViewModel.PurchaseOrder.UnitPurchasePrize * purchaseOrderViewModel.PurchaseOrder.Amount;
                    PurchaseOrderCollectionViewModel.PurchaseOrderViewModels.Add(purchaseOrderViewModel);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
