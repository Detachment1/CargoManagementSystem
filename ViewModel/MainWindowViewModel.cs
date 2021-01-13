using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class MainWindowViewModel : NotificationObject
    {
        public CargoManagementContext CMContext { get; set; }
        public MainWindowViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
        }
    }
}
