using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace CargoManagementSystem.ViewModel
{
    public class CategoryManagementUserControlViewModel : NotificationObject
    {
        public CargoManagementContext CMContext { get; set; }
        public DelegateCommand AddCargoCommand { get; set; }
        public ObservableCollection<CargoCollectionViewModel> CargoCollectionViewModels { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        private ObservableCollection<CargoViewModel> _cargoViewModels;
        public ObservableCollection<CargoViewModel> CargoViewModels
        {
            get { return _cargoViewModels; }
            set { _cargoViewModels = value; RaisePropertyChanged("CargoViewModels"); }
        }
        

        public ICollectionView CargoViewModelsView { get; set; }
        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set { _searchString = value; RaisePropertyChanged("SearchString"); }
        }
        public CategoryManagementUserControlViewModel(CargoManagementContext cmContext, 
            ObservableCollection<CargoViewModel> cvms,
            ObservableCollection<CargoCollectionViewModel> ccvms)
        {
            CMContext = cmContext;
            CargoViewModels = cvms;
            CargoCollectionViewModels = ccvms;
            CargoViewModelsView = CollectionViewSource.GetDefaultView(CargoViewModels);
            CargoViewModelsView.SortDescriptions.Add(new SortDescription("OrderScore", ListSortDirection.Descending));
            AddCargoCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddCargoExecute)};
            SearchCommand = new DelegateCommand() { ExecuteAction = new Action<object>(SearchExecute) };
        }
        private void AddCargoExecute(object parameter)
        {
            AddCargoWindow AddCargoWindow = new AddCargoWindow(CMContext);
            AddCargoWindowViewModel AddCargoWindowvm = AddCargoWindow.DataContext as AddCargoWindowViewModel;
            AddCargoWindowvm.CallBack = new Func<Cargo, bool>(CallBack);
            AddCargoWindow.Show();
        }
        public bool CallBack(Cargo cargo)
        {
            if (cargo != null)
            {
                bool IsExist = CargoViewModels.Any<CargoViewModel>
                    (item => item.Cargo.PreciseCargoName == cargo.PreciseCargoName);
                if (!IsExist)
                {
                    CargoViewModel cargoViewModel = new CargoViewModel(CMContext);
                    cargoViewModel.Cargo = cargo;
                    cargoViewModel.CargoViewModels = CargoViewModels;
                    cargoViewModel.CargoCollectionViewModels = CargoCollectionViewModels;
                    CMContext.Cargo.Add(cargo);
                    CMContext.SaveChanges();
                    CargoViewModels.Add(cargoViewModel);
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
        private void SearchExecute(object parameter)
        {
            if (SearchString != null)
            {
                foreach (var cargoViewModel in CargoViewModels)
                {
                    cargoViewModel.UpdateOrderScore(SearchString);
                }
                CargoViewModelsView.Refresh();
                //DataGrid grid = parameter as DataGrid;
                //CargoViewModels = new ObservableCollection<CargoViewModel>(CargoViewModels.OrderByDescending(item => item.OrderScore));
                //grid.ItemsSource = CargoViewModels;
            }
        }
    }
}
