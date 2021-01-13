using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class AddSellOrderCollectionWindowViewModel : NotificationObject
    {
        private SellOrderCollection _sellOrderCollection;
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }       
        public Action<SellOrderCollection> CallBack { get; set; }       
        public SellOrderCollection SellOrderCollection
        {
            get { return _sellOrderCollection; }
            set { _sellOrderCollection = value; RaisePropertyChanged("SellOrderCollection"); }
        }


        public AddSellOrderCollectionWindowViewModel()
        {
            SellOrderCollection = new SellOrderCollection();
            CancelCommand = new DelegateCommand() { ExecuteAction = new Action<object>(CancelExecute)};
            ConfirmCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmExecute) };
        }
        private void CancelExecute(object parameter)
        {
            SellOrderCollection = null;
            AddSellOrderCollectionWindow AddSellOrderCollectionWindow = parameter as AddSellOrderCollectionWindow;
            CallBack(SellOrderCollection);
            AddSellOrderCollectionWindow.Close();
            
        }
        private void ConfirmExecute(object parameter)
        {
            AddSellOrderCollectionWindow AddSellOrderCollectionWindow = parameter as AddSellOrderCollectionWindow;
            CallBack(SellOrderCollection);
            AddSellOrderCollectionWindow.Close();   
        }
    }
}
