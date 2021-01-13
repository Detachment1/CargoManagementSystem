using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class SellOrderCollectionDetailWindowViewModel : NotificationObject
    {
        private SellOrderCollectionViewModel _sellOrderCollectionViewModel;
        public SellOrderCollectionViewModel SellOrderCollectionViewModel
        {
            get { return _sellOrderCollectionViewModel; }
            set { _sellOrderCollectionViewModel = value; RaisePropertyChanged("SellOrderCollectionViewModel"); }
        }

        public SellOrderCollectionDetailWindowViewModel(SellOrderCollectionViewModel socvm)
        {
            SellOrderCollectionViewModel = socvm;
        }
    }
}
