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
    public class WarehouseRootViewModel : NotificationObject
    {
        public CargoManagementContext CMContext { get; set; }
        public ObservableCollection<WarehouseViewModel> WarehouseViewModels { get; set; }
        public DelegateCommand AddWarehouseCommand { get; set; }
        public WarehouseRootViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            WarehouseViewModels = new ObservableCollection<WarehouseViewModel>();
            AddWarehouseCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddWarehouseExecute) };
        }
        public void AddWarehouseExecute(object parameter)
        {
            AddWarehouseWindow addWarehouseWindow = new AddWarehouseWindow();
            AddWarehouseWindowViewModel AddWarehouseWindowvm = addWarehouseWindow.DataContext as AddWarehouseWindowViewModel;
            AddWarehouseWindowvm.CallBack = new Func<Warehouse, bool>(CallBack);
            addWarehouseWindow.Show();
        }
        public bool CallBack(Warehouse warehouse)
        {
            if (warehouse != null)
            {
                bool IsExist = WarehouseViewModels.Any<WarehouseViewModel>
                    (item => item.Warehouse.WarehouseName == warehouse.WarehouseName);
                if (!IsExist)
                {
                    WarehouseViewModel warehouseViewModel = new WarehouseViewModel(CMContext)
                    {
                        Warehouse = warehouse,
                        WarehouseRootViewModel = this
                    };
                    CMContext.Warehouse.Add(warehouse);
                    WarehouseViewModels.Add(warehouseViewModel);
                    CMContext.SaveChanges();
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
