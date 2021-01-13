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

namespace CargoManagementSystem.ViewModel
{
    public class AddPurchaseOrderWindowViewModel : NotificationObject
    {
        private WarehouseViewModel _selectedWarehouseViewModel;
        private PlaneViewModel _selectedPlaneViewModel;
        private BlockViewModel _selectedBlockViewModel;
        public CargoManagementContext CMContext { get; set; }
        public PurchaseOrderViewModel PurchaseOrderViewModel { get; set; }
        public WarehouseRootViewModel WarehouseRootViewModel { get; set; }        
        public WarehouseViewModel SelectedWarehouseViewModel
        {
            get { return _selectedWarehouseViewModel; }
            set { _selectedWarehouseViewModel = value; RaisePropertyChanged("SelectedWarehouseViewModel"); }
        }       
        public PlaneViewModel SelectedPlaneViewModel
        {
            get { return _selectedPlaneViewModel; }
            set { _selectedPlaneViewModel = value; RaisePropertyChanged("SelectedPlaneViewModel"); }
        }       
        public BlockViewModel SelectedBlockViewModel
        {
            get { return _selectedBlockViewModel; }
            set { _selectedBlockViewModel = value; RaisePropertyChanged("SelectedBlockViewModel"); }
        }
        
        public Func<PurchaseOrderViewModel, bool> CallBack { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }
        private string _teststring;

        public string TestString
        {
            get { return _teststring; }
            set { _teststring = value; RaisePropertyChanged("TestString"); }
        }

        public AddPurchaseOrderWindowViewModel(CargoManagementContext cmContext, WarehouseRootViewModel wrvm)
        {
            CMContext = cmContext;
            WarehouseRootViewModel = wrvm;
            PurchaseOrderViewModel = new PurchaseOrderViewModel(CMContext);
            CancelCommand = new DelegateCommand() { ExecuteAction = new Action<object>(CancelExecute) };
            ConfirmCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmExecute) };
        }
        private void CancelExecute(object parameter)
        {
            PurchaseOrderViewModel = null;
            AddPurchaseOrderWindow AddPurchaseOrderWindow = parameter as AddPurchaseOrderWindow;
            CallBack(PurchaseOrderViewModel);
            AddPurchaseOrderWindow.Close();

        }
        private void ConfirmExecute(object parameter)
        {
            bool IsValid = true;
            string message = "存在非法输入";
            string detailMessage = "";
            if (PurchaseOrderViewModel.PurchaseOrder.UnitPurchasePrize <= 0)
            {
                detailMessage += "单位进价不允许小于等于零\n";
                IsValid = false;
            }
            if (PurchaseOrderViewModel.PurchaseOrder.Amount <= 0)
            {
                detailMessage += "数量不允许小于等于零\n";
                IsValid = false;
            }
            if (SelectedWarehouseViewModel == null)
            {
                detailMessage += "未选择仓库\n";
                IsValid = false;
            }
            if (SelectedPlaneViewModel == null)
            {
                detailMessage += "未选择层数\n";
                IsValid = false;
            }
            if (SelectedBlockViewModel == null)
            {
                detailMessage += "未选择区域\n";
                IsValid = false;
            }
            if (IsValid)
            {
                PurchaseOrderViewModel.BlockViewModel = SelectedBlockViewModel;
                PurchaseOrderViewModel.PurchaseOrder.WarehouseName = SelectedWarehouseViewModel.Warehouse.WarehouseName;
                PurchaseOrderViewModel.PurchaseOrder.PlaneName = SelectedPlaneViewModel.Plane.PlaneName;
                PurchaseOrderViewModel.PurchaseOrder.BlockName = SelectedBlockViewModel.Block.BlockName;
                AddPurchaseOrderWindow AddPurchaseOrderWindow = parameter as AddPurchaseOrderWindow;
                bool IsExist = CallBack(PurchaseOrderViewModel);
                if (IsExist)
                {
                    string message2 = "订单中已存在同名条目";
                    string detailMessage2 = string.Format("同一订单中的不同条目之间，以下五个项目应至少有一个不重复：仓库名称，楼层名称，区域名称，货品名称，单位进价");
                    WarningWindow warn = new WarningWindow(message2, detailMessage2);
                    warn.ShowDialog();
                }
                else
                {

                    AddPurchaseOrderWindow.Close();
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
