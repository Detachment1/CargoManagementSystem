using CargoManagementSystem.Command;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class WarningWindowViewModel : NotificationObject
    {
        private string _message;
        private string _detailMessage;
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged("Message"); }
        }
        public string DetailMessage
        {
            get { return _detailMessage; }
            set { _detailMessage = value; RaisePropertyChanged("DetailMessage"); }
        }
        public DelegateCommand ConfirmCommand { get; set; }
        public WarningWindowViewModel(string message, string detailMessage)
        {
            Message = message;
            DetailMessage = detailMessage;
            ConfirmCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmExecute) };
        }
        private void ConfirmExecute(object parameter)
        {
            WarningWindow warningWindow = parameter as WarningWindow;
            warningWindow.DialogResult = true;
        }
    }
}
