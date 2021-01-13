using CargoManagementSystem.Exception;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using CargoManagementSystem.ViewModel;

namespace CargoManagementSystem.Model
{
    [Table("Warehouse")]
    public partial class Warehouse : NotificationObject
    {
        private string _warehouesName;
        private string _location;

        [Key]
        [Column(Order = 0)]
        public string WarehouseName
        {
            get { return _warehouesName; }
            set { _warehouesName = value; RaisePropertyChanged("WarehouseName"); }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; RaisePropertyChanged("Location"); }
        }

        public Warehouse()
        {
            Planes = new ObservableCollection<Plane>();
        }
        public virtual ObservableCollection<Plane> Planes { get; set; }
    }
   
}
