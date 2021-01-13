using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CargoManagementSystem.ViewModel
{
    public class SellCargoUserControlViewModel : NotificationObject
    {
        private bool _outSellOrderButtonIsEnabled;
        private SellOrderCollectionViewModel _sellOrderCollectionViewModel;
        public CargoManagementContext CMContext { get; set; }
        public DelegateCommand AddSellOrderCollectionCommand { get; set; }
        public DelegateCommand DeleteSellOrderCollectionCommand { get; set; }
        public DelegateCommand ConfirmSellOrderCollectionCommand { get; set; }
        public bool OutSellOrderButtonIsEnabled
        {
            get { return _outSellOrderButtonIsEnabled; }
            set { _outSellOrderButtonIsEnabled = value; RaisePropertyChanged("OutSellOrderButtonIsEnabled"); }
        }
        public SellOrderCollectionViewModel SellOrderCollectionViewModel
        {
            get { return _sellOrderCollectionViewModel; }
            set { _sellOrderCollectionViewModel = value; RaisePropertyChanged("SellOrderCollectionViewModel"); }
        }
        public ObservableCollection<CargoCollectionViewModel> CargoCollectionViewModels { get; set; }
        public ObservableCollection<SellOrderCollectionViewModel> SellOrderCollectionViewModels { get; set; }

        public SellCargoUserControlViewModel(CargoManagementContext cmContext,
            ObservableCollection<CargoCollectionViewModel> ccvms,
            ObservableCollection<SellOrderCollectionViewModel> socvms)
        {
            CMContext = cmContext;
            OutSellOrderButtonIsEnabled = false;
            CargoCollectionViewModels = ccvms;
            SellOrderCollectionViewModels = socvms;

            AddSellOrderCollectionCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddSellOrderCollectionExecute)};
            DeleteSellOrderCollectionCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeleteSellOrderCollectionExecute) };
            ConfirmSellOrderCollectionCommand = new DelegateCommand() { ExecuteAction = new Action<object>(ConfirmSellOrderCollectionExecute) };
        }

        private void AddSellOrderCollectionExecute(object parameter)
        {
            if (OutSellOrderButtonIsEnabled)
            {
                string message = "已存在一个订单，无法添加订单";
                string detailMessage = "同一时间只允许存在一个订单，不允许同一时间编辑两个订单";
                WarningWindow warn = new WarningWindow(message, detailMessage);
                warn.ShowDialog();
            }
            else
            {
                AddSellOrderCollectionWindow AddSellOrderCollectionWindow = new AddSellOrderCollectionWindow();
                AddSellOrderCollectionWindowViewModel vm = AddSellOrderCollectionWindow.DataContext as AddSellOrderCollectionWindowViewModel;
                vm.CallBack = new Action<SellOrderCollection>(AddSellOrderCollectionCallBackAction);
                AddSellOrderCollectionWindow.Show();
            }
        }
        private void DeleteSellOrderCollectionExecute(object parameter)
        {
            string message = "是否删除订单";
            string detailMessage = "删除卖货订单将删除订单中的每一个条目，请确定后删除";
            PromptWindow prompt = new PromptWindow(message, detailMessage);
            bool? IsConfirmed = prompt.ShowDialog();
            if (IsConfirmed == true)
            {
                SellOrderCollectionViewModel = null;
                OutSellOrderButtonIsEnabled = false;
            }
        }
        private void ConfirmSellOrderCollectionExecute(object parameter)
        {
            string message = "是否确认订单";
            string detailMessage = "请检查卖货订单中的每一个条目是否正确，确认订单后将无法修改";
            PromptWindow prompt = new PromptWindow(message, detailMessage);
            bool? IsConfirmed = prompt.ShowDialog();
            if (IsConfirmed == true)
            {
                DateTime CurrentTime = DateTime.Now;
                SellOrderCollectionViewModel.SellOrderCollection.SellTime = CurrentTime;
                foreach (var sellorderviewmodel in SellOrderCollectionViewModel.SellOrderViewModels)
                {
                    sellorderviewmodel.SellOrder.SellTime = CurrentTime;
                    CMContext.SellOrder.Add(sellorderviewmodel.SellOrder);
                    CargoCollectionViewModel cargoCollectionViewModel = sellorderviewmodel.CargoCollectionViewModel;
                    if (cargoCollectionViewModel.CargoCollection.Amount == sellorderviewmodel.SellOrder.Amount)
                    {
                        CMContext.CargoCollection.Remove(cargoCollectionViewModel.CargoCollection);
                        cargoCollectionViewModel.BlockViewModel.CargoCollectionViewModels.Remove(cargoCollectionViewModel);
                        cargoCollectionViewModel.CargoCollectionViewModels.Remove(cargoCollectionViewModel);
                    }
                    else
                    {
                        int BufferAmount = sellorderviewmodel.SellOrder.Amount;
                        cargoCollectionViewModel.CargoCollection.PurchasePrizeDics[0].Amount -= sellorderviewmodel.SellOrder.Amount;
                        cargoCollectionViewModel.CargoCollection.Amount -= sellorderviewmodel.SellOrder.Amount;
                        foreach (var dic in cargoCollectionViewModel.CargoCollection.PurchasePrizeDics)
                        {
                            if (dic.UnitPurchasePrize == -1)
                            {
                                continue;
                            }
                            else if (BufferAmount == 0)
                            {
                                break;
                            }
                            else if (dic.Amount == BufferAmount)
                            {
                                dic.Amount = 0;
                                BufferAmount = 0;
                            }
                            else if (dic.Amount < BufferAmount)
                            {
                                BufferAmount -= dic.Amount;
                                dic.Amount = 0;
                            }
                            else if (dic.Amount > BufferAmount)
                            {
                                dic.Amount -= BufferAmount;
                                BufferAmount = 0;
                            }
                        }
                        var bufferresult = cargoCollectionViewModel.CargoCollection.PurchasePrizeDics.Where<PurchasePrizeDic>(item => item.Amount == 0).ToList();

                        for (int i = 0; i < bufferresult.Count(); i++)
                        {
                            cargoCollectionViewModel.CargoCollection.PurchasePrizeDics.Remove(bufferresult[i]);
                        }
                    }
                }
                CMContext.SellOrderCollection.Add(SellOrderCollectionViewModel.SellOrderCollection);
                SellOrderCollectionViewModels.Add(SellOrderCollectionViewModel);
                CMContext.SaveChanges();
                SellOrderCollectionViewModel = null;
                OutSellOrderButtonIsEnabled = false;
            }
        }
        private void AddSellOrderCollectionCallBackAction(SellOrderCollection sellOrderCollection) 
        {
            if (sellOrderCollection == null)
            {
                OutSellOrderButtonIsEnabled = false;
            }
            else
            {
                OutSellOrderButtonIsEnabled = true;
                SellOrderCollectionViewModel = new SellOrderCollectionViewModel(CMContext);
                SellOrderCollectionViewModel.SellOrderCollection = sellOrderCollection;
            }
        }

    }
}
