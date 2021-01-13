using CargoManagementSystem.Command;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class PromptWindowViewModel : NotificationObject
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
        public DelegateCommand CancelCommand { get; set; }

        public PromptWindowViewModel(string message, string detailMessage)
        {
            Message = message;
            DetailMessage = detailMessage;
            CancelCommand = new DelegateCommand() { ExecuteAction = new Action<object>(CancelExecute) };
            ConfirmCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmExecute) };
        }
        private void CancelExecute(object parameter)
        {
            PromptWindow promptWindow = parameter as PromptWindow;
            promptWindow.DialogResult = false;
        }
        private void ConfirmExecute(object parameter)
        {
            PromptWindow promptWindow = parameter as PromptWindow;
            promptWindow.DialogResult = true;
        }
    }
}
