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
    public class AddPlaneWindowViewModel : NotificationObject
    {
        public Plane Plane { get; set; }

        public Action<Plane> CallBack { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }
        public AddPlaneWindowViewModel()
        {
            Plane= new Plane();
            CancelCommand = new DelegateCommand() { ExecuteAction = new Action<object>(CancelExecute) };
            ConfirmCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmExecute) };
        }
        private void CancelExecute(object parameter)
        {
            Plane = null;
            AddPlaneWindow AddPlaneWindow = parameter as AddPlaneWindow;
            CallBack(Plane);
            AddPlaneWindow.Close();
        }
        private void ConfirmExecute(object parameter)
        {
            AddPlaneWindow AddPlaneWindow = parameter as AddPlaneWindow;
            CallBack(Plane);
            AddPlaneWindow.Close();
        }
    }
}
