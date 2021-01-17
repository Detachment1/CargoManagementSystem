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

        public Func<Block, bool> CallBack { get; set; }
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
            if (string.IsNullOrWhiteSpace(Block.BlockName))
            {
                string message = "区域名称不能为空";
                string detailMessage = "区域名称不允许为空";
                WarningWindow warn = new WarningWindow(message, detailMessage);
                warn.ShowDialog();
            }
            else
            {
                AddBlockWindow AddBlockWindow = parameter as AddBlockWindow;
                bool IsExist = CallBack(Block);
                if (IsExist == true)
                {
                    string message = "该层已存在相同名字的区域";
                    string detailMessage = "同一层中的区域名字不允许重复";
                    WarningWindow warn = new WarningWindow(message, detailMessage);
                    warn.ShowDialog();
                }
                else
                {
                    AddBlockWindow.Close();
                }
            }
        }
    }
}
