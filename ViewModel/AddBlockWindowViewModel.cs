using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class AddBlockWindowViewModel : NotificationObject
    {
        private Block _block;

        public Block Block
        {
            get { return _block; }
            set { _block = value;  RaisePropertyChanged("Block"); }
        }

        public Action<Block> CallBack { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }
        public AddBlockWindowViewModel()
        {
            Block = new Block();
            CancelCommand = new DelegateCommand() { ExecuteAction = new Action<object>(CancelExecute) };
            ConfirmCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmExecute) };
        }
        private void CancelExecute(object parameter)
        {
            Block = null;
            AddBlockWindow AddBlockWindow = parameter as AddBlockWindow;
            CallBack(Block);
            AddBlockWindow.Close();
        }
        private void ConfirmExecute(object parameter)
        {
            AddBlockWindow AddBlockWindow = parameter as AddBlockWindow;
            CallBack(Block);
            AddBlockWindow.Close();
        }
    }
}
