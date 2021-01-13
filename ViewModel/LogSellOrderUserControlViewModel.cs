using CargoManagementSystem.Command;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CargoManagementSystem.ViewModel
{
    public class LogSellOrderUserControlViewModel : NotificationObject
    {
        private DateTime _startTime;
        private DateTime _endTime;
        public CargoManagementContext CMContext { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        public DateTime StartTime
        {
            get { return _startTime; }
            set { _startTime = value; RaisePropertyChanged("StartTime"); }
        }
        public DateTime EndTime
        {
            get { return _endTime; }
            set { _endTime = value; RaisePropertyChanged("EndTime"); }
        }

        public ObservableCollection<SellOrderCollectionViewModel> SellOrderCollectionViewModels { get; set; }

        public LogSellOrderUserControlViewModel(CargoManagementContext cmContext, ObservableCollection<SellOrderCollectionViewModel> socvms)
        {
            CMContext = cmContext;
            SellOrderCollectionViewModels = socvms;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
            SearchCommand = new DelegateCommand() { ExecuteAction = new Action<object>(SearchExecute) };
        }
        private void SearchExecute(object parameter)
        {
            if (StartTime > EndTime)
            {
                string message = "起始时间应早于结束时间";
                string detailMessage = "选择时间区间时，起始时间应早于结束时间";
                WarningWindow warn = new WarningWindow(message, detailMessage);
                warn.ShowDialog();
            }
            else
            {
                DataGrid grid = parameter as DataGrid;
                IEnumerable<SellOrderCollectionViewModel> show = SellOrderCollectionViewModels.Where(item => (item.SellOrderCollection.SellTime >= StartTime && item.SellOrderCollection.SellTime <= EndTime));
                grid.ItemsSource = new ObservableCollection<SellOrderCollectionViewModel>(show.OrderBy(item => item.SellOrderCollection.SellTime));
            }
        }
    }
}
