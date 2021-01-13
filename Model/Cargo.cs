using CargoManagementSystem.Exception;
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
    [Table("Cargo")]
    public partial class Cargo : NotificationObject
    {
        private string _preciseCargoName;
        private string _cargoName;
        private string _material;
        private string _category;
        private string _stdCategory;
        private string _stdName;
        private string _size;
        private string _sizeUnit;
        private byte[] _cargoImage;

        [Key]
        public string PreciseCargoName
        {
            get { return _preciseCargoName; }
            set { _preciseCargoName = value; RaisePropertyChanged("PreciseCargoName"); }
        }

        public string CargoName
        {
            get { return _cargoName; }
            set { _cargoName = value; RaisePropertyChanged("CargoName"); }
        }
        public string Material
        {
            get { return _material; }
            set { _material = value; RaisePropertyChanged("Material"); }
        }
        public string Category
        {
            get { return _category; }
            set { _category = value; RaisePropertyChanged("Category"); }
        }
        public string StdCategory
        {
            get { return _stdCategory; }
            set { _stdCategory = value; RaisePropertyChanged("StdCategory"); }
        }
        public string StdName
        {
            get { return _stdName; }
            set { _stdName = value; RaisePropertyChanged("StdName"); }
        }
        public string Size
        {
            get { return _size; }
            set { _size = value; RaisePropertyChanged("Size"); }
        }
        public string SizeUnit
        {
            get { return _sizeUnit; }
            set { _sizeUnit = value; RaisePropertyChanged("SizeUnit"); }
        }
        public byte[] CargoImage
        {
            get { return _cargoImage; }
            set { _cargoImage = value; RaisePropertyChanged("CargoImage"); }
        }

        public Cargo()
        {
            CargoCollections = new ObservableCollection<CargoCollection>();
        }
        public virtual ObservableCollection<CargoCollection> CargoCollections { get; set; }

        public void SetPreciseCargoName()
        {
            PreciseCargoName = Material + " " + Category + " " + StdCategory + " " + StdName + " " + Size + " " + SizeUnit;
        }
    }
}
