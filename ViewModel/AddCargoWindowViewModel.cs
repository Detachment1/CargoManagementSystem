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
        public Func<Cargo, bool> CallBack { get; set; }
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
            bool IsValid = true;
            string message = "存在非法输入";
            string detailMessage = "";
            if (string.IsNullOrWhiteSpace(Cargo.CargoName))
            {
                detailMessage += "商品名称不允许为空\n";
                IsValid = false;
            }
            if (string.IsNullOrWhiteSpace(Cargo.Material))
            {
                detailMessage += "商品材料不允许为空\n";
                IsValid = false;
            }
            if (string.IsNullOrWhiteSpace(Cargo.Size))
            {
                detailMessage += "商品尺寸不允许为空, 若该商品无尺寸, 则输入：无\n";
                IsValid = false;
            }
            if (string.IsNullOrWhiteSpace(Cargo.SizeUnit))
            {
                detailMessage += "商品尺寸单位不允许为空, 若该商品无尺寸单位, 则输入：无\n";
                IsValid = false;
            }
            if (string.IsNullOrWhiteSpace(Cargo.Category))
            {
                detailMessage += "商品类别不允许为空\n";
                IsValid = false;
            }
            if (string.IsNullOrWhiteSpace(Cargo.StdCategory))
            {
                detailMessage += "商品标准类别不允许为空\n";
                IsValid = false;
            }
            if (string.IsNullOrWhiteSpace(Cargo.StdName))
            {
                detailMessage += "商品标准名称不允许为空\n";
                IsValid = false;
            }
            if (IsValid)
            {
                AddCargoWindow AddCargoWindow = parameter as AddCargoWindow;
                Cargo.SetPreciseCargoName();
                bool IsExist = CallBack(Cargo);
                if (IsExist == true)
                {
                    string message2 = "已存在同名商品";
                    string detailMessage2 = string.Format("不同商品之间，以下六个项目应至少有一个不重复：商品类别，商品标准类别，商品标准名称，商品尺寸，商品尺寸单位，商品材料");
                    WarningWindow warn = new WarningWindow(message2, detailMessage2);
                    warn.ShowDialog();
                }
                else
                {
                    AddCargoWindow.Close();
                }
            }
            else
            {
                WarningWindow warn = new WarningWindow(message, detailMessage);
                warn.ShowDialog();
            }
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
                FileStream fs = new FileStream(ImagePath, FileMode.Open);
                byte[] byData = new byte[fs.Length];
                fs.Read(byData, 0, byData.Length);
                fs.Close();
                Cargo.CargoImage = byData;
                CMContext.SaveChanges();
            }
            
        }
        private void DeleteImageExecute(object parameter)
        {
            Cargo.CargoImage = null;
            CMContext.SaveChanges();
        }
    }
}
