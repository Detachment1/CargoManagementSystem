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
    public class WarehouseViewModel : NotificationObject
    {
        public Warehouse Warehouse { get; set; }
        public WarehouseRootViewModel WarehouseRootViewModel { get; set; }
        public ObservableCollection<PlaneViewModel> PlaneViewModels { get; set; }
        public DelegateCommand DeleteWarehouseCommand { get; set; }
        public DelegateCommand AddPlaneCommand { get; set; }
        public CargoManagementContext CMContext { get; set; }
        public WarehouseViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            Warehouse = new Warehouse();
            WarehouseRootViewModel = new WarehouseRootViewModel(cmContext);
            PlaneViewModels = new ObservableCollection<PlaneViewModel>();
            DeleteWarehouseCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteWarehouseExecute) };
            AddPlaneCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddPlaneExecute) };
        }
        public void DeleteWarehouseExecute(object parameter)
        {
            string message = "是否确定删除";
            string detailMessage = string.Format("本操作将会删除仓库：{0}，以及该仓库内的全部楼层，区域和区域内的货物", Warehouse.WarehouseName);
            PromptWindow prompt = new PromptWindow(message, detailMessage);
            bool? IsConfirmed = prompt.ShowDialog();
            if (IsConfirmed == true)
            {
                WarehouseManagementUserControl wmuc = parameter as WarehouseManagementUserControl;
                WarehouseManagementUserControlViewModel wmucvm = wmuc.DataContext as WarehouseManagementUserControlViewModel;
                wmucvm.CargoCollectionViewModels = null;
                DeleteCargoCollections();
                CMContext.Warehouse.Remove(Warehouse);
                WarehouseRootViewModel.WarehouseViewModels.Remove(this);
                CMContext.SaveChanges();
            }
        }
        public void AddPlaneExecute(object parameter)
        {
            AddPlaneWindow addPlaneWindow = new AddPlaneWindow();
            AddPlaneWindowViewModel AddPlaneWindowvm = addPlaneWindow.DataContext as AddPlaneWindowViewModel;
            AddPlaneWindowvm.CallBack = new Action<Plane>(CallBack);
            addPlaneWindow.Show();
            
        }
        public void CallBack(Plane plane)
        {
            if (plane != null)
            {
                plane.WarehouseName = Warehouse.WarehouseName;
                PlaneViewModel planeViewModel = new PlaneViewModel(CMContext)
                {
                    WarehouseViewModel = this,
                    Plane = plane
                };
                CMContext.Plane.Add(plane);
                CMContext.SaveChanges();
                PlaneViewModels.Add(planeViewModel);
            }
        }
        public void DeleteCargoCollections()
        {
            foreach (var planeViewModel in PlaneViewModels)
            {
                planeViewModel.DeleteCargoCollections();
            }
        }
    }
    
}
