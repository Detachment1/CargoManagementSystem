using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class AddCargoWindowViewModel : NotificationObject
    {
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; RaisePropertyChanged("ImagePath"); }
        }
        public CargoManagementContext CMContext { get; set; }
        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand ConfirmCommand { get; set; }
        public DelegateCommand AddImageCommand { get; set; }
        public DelegateCommand DeleteImageCommand { get; set; }
        public Action<Cargo> CallBack { get; set; }
        public Cargo Cargo { get; set; }

        public AddCargoWindowViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            Cargo = new Cargo();
            CancelCommand = new DelegateCommand() { ExecuteAction = new Action<object>(CancelExecute) };
            ConfirmCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmExecute) };
            AddImageCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddImageExecute) };
            DeleteImageCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteImageExecute) };
        }
        private void CancelExecute(object parameter)
        {
            Cargo = null;
            AddCargoWindow AddCargoWindow = parameter as AddCargoWindow;
            CallBack(Cargo);
            AddCargoWindow.Close();
        }
        private void ConfirmExecute(object parameter)
        {
            AddCargoWindow AddCargoWindow = parameter as AddCargoWindow;
            Cargo.SetPreciseCargoName();
            CallBack(Cargo);
            AddCargoWindow.Close();
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
            }
            FileStream fs = new FileStream(ImagePath, FileMode.Open);
            byte[] byData = new byte[fs.Length];
            fs.Read(byData, 0, byData.Length);
            fs.Close();
            Cargo.CargoImage = byData;
            CMContext.SaveChanges();
        }
        private void DeleteImageExecute(object parameter)
        {
            Cargo.CargoImage = null;
            CMContext.SaveChanges();
        }
    }
}
