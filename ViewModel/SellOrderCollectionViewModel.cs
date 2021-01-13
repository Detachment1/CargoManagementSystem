using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using System;
using System.Collections.ObjectModel;

namespace CargoManagementSystem.ViewModel
{
    public class SellOrderCollectionViewModel : NotificationObject
    {
        private SellOrderCollection _sellOrderCollection;
        public SellOrderCollection SellOrderCollection
        {
            get { return _sellOrderCollection; }
            set { _sellOrderCollection = value; RaisePropertyChanged("SellOrderCollection"); }
        }
        public CargoManagementContext CMContext { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public ObservableCollection<SellOrderViewModel> SellOrderViewModels { get; set; }
        public ObservableCollection<SellOrderCollectionViewModel> SellOrderCollectionViewModels { get; set; }
        public DelegateCommand ShowDetailCommand { get; set; }
        public SellOrderCollectionViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            SellOrderCollection = new SellOrderCollection();
            SellOrderViewModels = new ObservableCollection<SellOrderViewModel>();
            ShowDetailCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ShowDetailExecute) };
            DeleteCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteExecute) };
        }
        public void ShowDetailExecute(object parameter)
        {
            SellOrderCollectionDetailWindow sellOrderCollectionDetailWindow = new SellOrderCollectionDetailWindow(this);
            sellOrderCollectionDetailWindow.Show();
        }
        private void DeleteExecute(object parameter)
        {
            string message = "是否删除卖货订单";
            string detailMessage = "删除的卖货订单记录将无法恢复，请确认是否是删除该订单\n删除之前备份订单的信息以便错误删除后进行恢复";
            PromptWindow prompt = new PromptWindow(message, detailMessage);
            bool? IsConfirmed = prompt.ShowDialog();
            if (IsConfirmed == true)
            {
                SellOrderCollectionViewModels.Remove(this);
                CMContext.SellOrderCollection.Remove(SellOrderCollection);
                CMContext.SaveChanges();
            }
        }
    }
}