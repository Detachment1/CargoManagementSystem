using CargoManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.Model
{
    [Table("Plane")]
    public partial class Plane : NotificationObject
    {
        private string _warehouesName;
        private string _planeName;

        [Key]
        [Column(Order = 0)]
        public string WarehouseName
        {
            get { return _warehouesName; }
            set { _warehouesName = value; RaisePropertyChanged("WarehouseName"); }
        }
        [Key]
        [Column(Order = 1)]
        public string PlaneName
        {
            get { return _planeName; }
            set { _planeName = value; RaisePropertyChanged("PlaneName"); }
        }

        public Plane()
        {
            Blocks = new ObservableCollection<Block>();
        }

        public virtual Warehouse Warehouse { get; set; }
        public virtual ObservableCollection<Block> Blocks { get; set; }
    }
}
