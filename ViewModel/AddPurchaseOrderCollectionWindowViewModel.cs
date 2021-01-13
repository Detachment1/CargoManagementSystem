using CargoManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{

    public class AddPurchaseOrderCollectionWindowViewModel : NotificationObject
    {
        public CargoManagementContext CMContext { get; set; }
        public AddPurchaseOrderCollectionWindowViewModel()
        {

        }
    }
}
