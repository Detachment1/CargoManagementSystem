using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoManagementSystem.ViewModel;

namespace CargoManagementSystem.Model
{
    [Table("Block")]
    public partial class Block : NotificationObject
    {
        private string _warehouesName;
        private string _planeName;
        private string _blockName;

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
        [Key]
        [Column(Order = 2)]
        public string BlockName
        {
            get { return _blockName; }
            set { _blockName = value; RaisePropertyChanged("BlockName"); }
        }

        public Block()
        {
            CargoCollections = new ObservableCollection<CargoCollection>();
        }


        public virtual Plane Plane { get; set; }
        public virtual ObservableCollection<CargoCollection> CargoCollections { get; set; }
    }
}
