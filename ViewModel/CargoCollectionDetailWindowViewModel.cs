using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class CargoCollectionDetailWindowViewModel : NotificationObject
    {
        public CargoManagementContext CMContext { get; set; }
        private CargoCollection _cargoCollection;
        private PurchasePrizeDic _selectedPurchasePrizeDic;
        private string _imagePath;
        public CargoCollection CargoCollection
        {
            get { return _cargoCollection; }
            set { _cargoCollection = value; RaisePropertyChanged("CargoCollection"); }
        }
        public PurchasePrizeDic SelectedPurchasePrizeDic
        {
            get { return _selectedPurchasePrizeDic; }
            set { _selectedPurchasePrizeDic = value; RaisePropertyChanged("SelectedPurchasePrizeDic"); }
        }
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; RaisePropertyChanged("ImagePath"); }
        }
        public DelegateCommand AddImageCommand { get; set; }
        public DelegateCommand DeleteImageCommand { get; set; }
        public CargoCollectionDetailWindowViewModel(CargoManagementContext cmContext, CargoCollection cc)
        {
            CMContext = cmContext;
            CargoCollection = cc;
            SelectedPurchasePrizeDic = CargoCollection.PurchasePrizeDics[0];
            AddImageCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddImageExecute) };
            DeleteImageCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteImageExecute) };
        }
        private void AddImageExecute(object parameter)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "ALL Files (*.png, *.jpg, *.jpeg, *.gif, *.bmp)|*.png;*.jpg;*.jpeg;*.gif;*.bmp|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                ImagePath = dlg.FileName;
                Console.WriteLine(ImagePath);
                FileStream fs = new FileStream(ImagePath, FileMode.Open);
                Console.WriteLine(fs.Length);
                byte[] byData = new byte[fs.Length];
                fs.Read(byData, 0, byData.Length);
                fs.Close();
                CargoCollection.Cargo.CargoImage = byData;
                CMContext.SaveChanges();
            }
            
        }
        private void DeleteImageExecute(object parameter)
        {
            CargoCollection.Cargo.CargoImage = null;
            CMContext.SaveChanges();
        }
    }
}
