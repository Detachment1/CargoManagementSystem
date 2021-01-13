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

        public Action<Warehouse> CallBack { get; set; }
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
            AddWarehouseWindow AddWarehouseWindow = parameter as AddWarehouseWindow;
            CallBack(Warehouse);
            AddWarehouseWindow.Close();
        }
    }
}
