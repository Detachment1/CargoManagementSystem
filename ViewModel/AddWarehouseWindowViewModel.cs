using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class AddWarehouseWindowViewModel : NotificationObject
    {
        public Warehouse Warehouse { get; set; }

        public Func<Warehouse, bool> CallBack { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }
        public AddWarehouseWindowViewModel()
        {
            Warehouse = new Warehouse();
            CancelCommand = new DelegateCommand() { ExecuteAction = new Action<object>(CancelExecute) };
            ConfirmCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmExecute) };
        }
        private void CancelExecute(object parameter)
        {
            Warehouse = null;
            AddWarehouseWindow AddWarehouseWindow = parameter as AddWarehouseWindow;
            CallBack(Warehouse);
            AddWarehouseWindow.Close();
        }
        private void ConfirmExecute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Warehouse.WarehouseName))
            {
                string message = "仓库名称不能为空";
                string detailMessage = "仓库名称不允许为空";
                WarningWindow warn = new WarningWindow(message, detailMessage);
                warn.ShowDialog();
            }
            else
            {
                AddWarehouseWindow AddWarehouseWindow = parameter as AddWarehouseWindow;
                bool IsExist = CallBack(Warehouse);
                if (IsExist == true)
                {
                    string message = "已存在相同名字的仓库";
                    string detailMessage = "仓库名字不允许重复";
                    WarningWindow warn = new WarningWindow(message, detailMessage);
                    warn.ShowDialog();
                }
                else
                {
                    AddWarehouseWindow.Close();
                }
            }
        }
    }
}
