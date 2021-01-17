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

        public Func<Plane, bool> CallBack { get; set; }
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
            if (string.IsNullOrWhiteSpace(Plane.PlaneName))
            {
                string message = "层名称不能为空";
                string detailMessage = "层名称不允许为空";
                WarningWindow warn = new WarningWindow(message, detailMessage);
                warn.ShowDialog();
            }
            else
            {
                AddPlaneWindow AddPlaneWindow = parameter as AddPlaneWindow;
                bool IsExist = CallBack(Plane);
                if (IsExist == true)
                {
                    string message = "该仓库已存在相同名字的层";
                    string detailMessage = "同一仓库中的层名字不允许重复";
                    WarningWindow warn = new WarningWindow(message, detailMessage);
                    warn.ShowDialog();
                }
                else
                {
                    AddPlaneWindow.Close();
                }
            }
        }
    }
}
