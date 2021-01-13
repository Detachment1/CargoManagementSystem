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

namespace CargoManagementSystem.ViewModel
{
    public class WarehouseManagementUserControlViewModel : NotificationObject
    {
        private ObservableCollection<CargoCollectionViewModel> _cargoCollectionViewModels;
        private BlockViewModel _blockViewModel;
        public CargoManagementContext CMContext { get; set; }
        public WarehouseRootViewModel WarehouseRootViewModel { get; set; }
        public DelegateCommand AddWarehouseCommand { get; set; }
        public DelegateCommand AddCargoCollectionCommand { get; set; }
        public BlockViewModel BlockViewModel
        {
            get { return _blockViewModel; }
            set { _blockViewModel = value; RaisePropertyChanged("BlockViewModel"); }
        }

        public ObservableCollection<CargoCollectionViewModel> CargoCollectionViewModels
        {
            get { return _cargoCollectionViewModels; }
            set { _cargoCollectionViewModels = value; RaisePropertyChanged("CargoCollectionViewModels"); }
        }
        public ObservableCollection<CargoCollectionViewModel> AllCargoCollectionViewModels { get; set; }

        public WarehouseManagementUserControlViewModel(CargoManagementContext cmContext, WarehouseRootViewModel wrvm, ObservableCollection<CargoCollectionViewModel> accvms)
        {
            CMContext = cmContext;
            WarehouseRootViewModel = wrvm;
            AllCargoCollectionViewModels = accvms;
            CargoCollectionViewModels = new ObservableCollection<CargoCollectionViewModel>();
            AddWarehouseCommand = WarehouseRootViewModel.AddWarehouseCommand;
            AddCargoCollectionCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddCargoCollectionExecute) };
        }
        public void AddCargoCollectionExecute(object parameter)
        {
            //AddCargoCollectionWindow addCargoCollectionWindow = new AddCargoCollectionWindow(CMContext);
            //addCargoCollectionWindow.Show();
        }
    }
}