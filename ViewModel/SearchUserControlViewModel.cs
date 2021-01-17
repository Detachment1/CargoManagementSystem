using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using FuzzySharp;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace CargoManagementSystem.ViewModel
{
    public class SearchUserControlViewModel : NotificationObject
    {
        public DelegateCommand SearchCommand { get; set; }
        public CargoManagementContext CMContext { get; set; }
        public ObservableCollection<CargoCollectionViewModel> CargoCollectionViewModels { get; set; }
        public ICollectionView CargoCollectionViewModelsView { get; set; }
        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set { _searchString = value; RaisePropertyChanged("SearchString"); }
        }
        public SearchUserControlViewModel(CargoManagementContext cmContext, ObservableCollection<CargoCollectionViewModel>ccvms)
        {
            CMContext = cmContext;
            CargoCollectionViewModels = ccvms;
            CargoCollectionViewModelsView = CollectionViewSource.GetDefaultView(CargoCollectionViewModels);
            CargoCollectionViewModelsView.SortDescriptions.Add(new SortDescription("OrderScore", ListSortDirection.Descending));
            SearchCommand = new DelegateCommand() { ExecuteAction = new Action<object>(SearchExecute)};
        }
        private void SearchExecute(object parameter)
        {
            if (SearchString != null)
            {
                foreach (var cargoCollectionViewModel in CargoCollectionViewModels)
                {
                    cargoCollectionViewModel.UpdateOrderScore(SearchString);
                }
                CargoCollectionViewModelsView.Refresh();
                //DataGrid grid = parameter as DataGrid;
                //CargoCollectionViewModels = new ObservableCollection<CargoCollectionViewModel>(CargoCollectionViewModels.OrderByDescending(item => item.OrderScore));
                //grid.ItemsSource = CargoCollectionViewModels;
            }      
        }
    }
}
