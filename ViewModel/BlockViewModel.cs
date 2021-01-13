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
    public class BlockViewModel : NotificationObject
    {
        public Block Block { get; set; }
        public CargoManagementContext CMContext { get; set; }
        public DelegateCommand DeleteBlockCommand { get; set; }
        public DelegateCommand ShowCargoCollectionCommand { get; set; }
        public PlaneViewModel PlaneViewModel { get; set; }
        public ObservableCollection<CargoCollectionViewModel> CargoCollectionViewModels { get; set; }
        public ObservableCollection<CargoCollectionViewModel> AllCargoCollectionViewModels { get; set; }

        public BlockViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            CargoCollectionViewModels = new ObservableCollection<CargoCollectionViewModel>();
            DeleteBlockCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteBlockExecute)};
            ShowCargoCollectionCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ShowCargoCollectionExecute) };
        }
        public void DeleteBlockExecute(object parameter)
        {
            string message = "是否确定删除";
            string detailMessage = string.Format("本操作将会删除区域：{0}，以及该区域内的全部货物", Block.BlockName);
            PromptWindow prompt = new PromptWindow(message, detailMessage);
            bool? IsConfirmed = prompt.ShowDialog();
            if (IsConfirmed == true)
            {
                WarehouseManagementUserControl wmuc = parameter as WarehouseManagementUserControl;
                WarehouseManagementUserControlViewModel wmucvm = wmuc.DataContext as WarehouseManagementUserControlViewModel;
                wmucvm.CargoCollectionViewModels = null;
                AllCargoCollectionViewModels = wmucvm.AllCargoCollectionViewModels;
                DeleteCargoCollections();
                CMContext.Block.Remove(Block);
                PlaneViewModel.BlockViewModels.Remove(this);
                CMContext.SaveChanges();
            } 
        }
        public void ShowCargoCollectionExecute(object parameter)
        {
            WarehouseManagementUserControl wmuc = parameter as WarehouseManagementUserControl;
            WarehouseManagementUserControlViewModel wmucvm = wmuc.DataContext as WarehouseManagementUserControlViewModel;
            wmucvm.BlockViewModel= this;
        }
        public void DeleteCargoCollections()
        {
            foreach (var cargoCollection in CargoCollectionViewModels.ToList())
            {
                cargoCollection.DeleteCargoCollection();
            }
        }

    }
}
