using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CargoManagementSystem.ViewModel
{
    public class PurchaseCargoUserControlViewModel : NotificationObject
    {
        private bool _outPurchaseOrderButtonIsEnabled;
        private PurchaseOrderCollectionViewModel _purchaseOrderCollectionViewModel;
        public CargoManagementContext CMContext { get; set; }
        public DelegateCommand AddPurchaseOrderCollectionCommand { get; set; }
        public DelegateCommand DeletePurchaseOrderCollectionCommand { get; set; }
        public DelegateCommand ConfirmPurchaseOrderCollectionCommand { get; set; }
        public bool OutPurchaseOrderButtonIsEnabled
        {
            get { return _outPurchaseOrderButtonIsEnabled; }
            set { _outPurchaseOrderButtonIsEnabled = value; RaisePropertyChanged("OutPurchaseOrderButtonIsEnabled"); }
        }
        public PurchaseOrderCollectionViewModel PurchaseOrderCollectionViewModel 
        {
            get { return _purchaseOrderCollectionViewModel; }
            set { _purchaseOrderCollectionViewModel = value; RaisePropertyChanged("PurchaseOrderCollectionViewModel"); }
        }
        public WarehouseRootViewModel WarehouseRootViewModel { get; set; }
        public ObservableCollection<PurchaseOrderCollectionViewModel> PurchaseOrderCollectionViewModels { get; set; }
        public ObservableCollection<CargoViewModel> CargoViewModels { get; set; }
        public ObservableCollection<CargoCollectionViewModel> CargoCollectionViewModels { get; set; }
        public PurchaseCargoUserControlViewModel(CargoManagementContext cmContext, 
            WarehouseRootViewModel wrvm, ObservableCollection<CargoViewModel> cvms, 
            ObservableCollection<CargoCollectionViewModel> ccvms,
            ObservableCollection<PurchaseOrderCollectionViewModel> pocvms)
        {
            CMContext = cmContext;
            WarehouseRootViewModel = wrvm;
            CargoViewModels = cvms;
            CargoCollectionViewModels = ccvms;
            PurchaseOrderCollectionViewModels = pocvms;
            OutPurchaseOrderButtonIsEnabled = false;
            AddPurchaseOrderCollectionCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddPurchaseOrderCollectionExecute)};
            DeletePurchaseOrderCollectionCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeletePurchaseOrderCollectionExecute) };
            ConfirmPurchaseOrderCollectionCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmPurchaseOrderCollectionExecute) };
        }
        private void AddPurchaseOrderCollectionExecute(object parameter)
        {
            if (OutPurchaseOrderButtonIsEnabled)
            {
                string message = "已存在一个订单，无法添加订单";
                string detailMessage = "同一时间只允许存在一个订单，不允许同一时间编辑两个订单";
                WarningWindow warn = new WarningWindow(message, detailMessage);
                warn.ShowDialog();
            }
            else
            {
                OutPurchaseOrderButtonIsEnabled = true;
                PurchaseOrderCollectionViewModel = new PurchaseOrderCollectionViewModel(CMContext);
            }  
        }
        private void DeletePurchaseOrderCollectionExecute(object parameter)
        {
            string message = "是否删除订单";
            string detailMessage = "删除进货订单将删除订单中的每一个条目，请确定后删除";
            PromptWindow prompt = new PromptWindow(message, detailMessage);
            bool? IsConfirmed = prompt.ShowDialog();
            if (IsConfirmed == true)
            {
                PurchaseOrderCollectionViewModel = null;
                OutPurchaseOrderButtonIsEnabled = false;
            }
        }
        private void ConfirmPurchaseOrderCollectionExecute(object parameter)
        {
            string message = "是否确认订单";
            string detailMessage = "请检查进货订单中的每一个条目是否正确，确认订单后将无法修改";
            PromptWindow prompt = new PromptWindow(message, detailMessage);
            bool? IsConfirmed = prompt.ShowDialog();
            if (IsConfirmed == true)
            {
                DateTime CurrentTime = DateTime.Now;
                PurchaseOrderCollectionViewModel.PurchaseOrderCollection.PurchaseTime = CurrentTime;
                foreach (var purchaseorderviewmodel in PurchaseOrderCollectionViewModel.PurchaseOrderViewModels)
                {
                    purchaseorderviewmodel.PurchaseOrder.PurchaseTime = CurrentTime;
                    CMContext.PurchaseOrder.Add(purchaseorderviewmodel.PurchaseOrder);
                    BlockViewModel blockViewModel = purchaseorderviewmodel.BlockViewModel;
                    IEnumerable<CargoCollectionViewModel> cc = blockViewModel.CargoCollectionViewModels.Where<CargoCollectionViewModel>(item => item.CargoCollection.PreciseCargoName == purchaseorderviewmodel.PurchaseOrder.PreciseCargoName);
                    if (cc.Count() == 0)
                    {
                        CargoCollectionViewModel c = new CargoCollectionViewModel(CMContext, purchaseorderviewmodel)
                        { BlockViewModel = blockViewModel, CargoCollectionViewModels = CargoCollectionViewModels };
                        CargoCollectionViewModels.Add(c);
                        blockViewModel.CargoCollectionViewModels.Add(c);
                        CMContext.CargoCollection.Add(c.CargoCollection);
                        PurchasePrizeDic p1 = new PurchasePrizeDic(purchaseorderviewmodel.PurchaseOrder)
                        { UnitPurchasePrize = -1 };
                        PurchasePrizeDic p2 = new PurchasePrizeDic(purchaseorderviewmodel.PurchaseOrder);
                        CMContext.PurchasePrizeDic.Add(p1);
                        CMContext.PurchasePrizeDic.Add(p2);
                        c.SelectedPurchasePrizeDic = p1;
                    }
                    else
                    {
                        CargoCollectionViewModel c = cc.First();
                        c.CargoCollection.Amount += purchaseorderviewmodel.PurchaseOrder.Amount;
                        c.CargoCollection.PurchasePrizeDics[0].Amount = c.CargoCollection.Amount;
                        IEnumerable<PurchasePrizeDic> pp = c.CargoCollection.PurchasePrizeDics.Where<PurchasePrizeDic>(item => item.UnitPurchasePrize == purchaseorderviewmodel.PurchaseOrder.UnitPurchasePrize);
                        if (pp.Count() == 0)
                        {
                            PurchasePrizeDic p = new PurchasePrizeDic(purchaseorderviewmodel.PurchaseOrder);
                            CMContext.PurchasePrizeDic.Add(p);
                        }
                        else
                        {
                            pp.First().Amount += purchaseorderviewmodel.PurchaseOrder.Amount;
                        }
                    }

                }
                CMContext.PurchaseOrderCollection.Add(PurchaseOrderCollectionViewModel.PurchaseOrderCollection);
                PurchaseOrderCollectionViewModels.Add(PurchaseOrderCollectionViewModel);
                CMContext.SaveChanges();
                PurchaseOrderCollectionViewModel = null;
                OutPurchaseOrderButtonIsEnabled = false;
            }
        }
    }
}
