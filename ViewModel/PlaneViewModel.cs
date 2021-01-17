using CargoManagementSystem.Command;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoManagementSystem.ViewModel
{
    public class PlaneViewModel : NotificationObject
    {
        public Plane Plane { get; set; }
        public CargoManagementContext CMContext { get; set; }
        public WarehouseViewModel WarehouseViewModel { get; set; }
        public ObservableCollection<BlockViewModel> BlockViewModels { get; set; }
        public DelegateCommand AddBlockCommand { get; set; }
        public DelegateCommand DeletePlaneCommand { get; set; }

        public PlaneViewModel(CargoManagementContext cmContext)
        {
            CMContext = cmContext;
            BlockViewModels = new ObservableCollection<BlockViewModel>();
            AddBlockCommand = new DelegateCommand() { ExecuteAction = new Action<object>(AddBlockExecute) };
            DeletePlaneCommand = new DelegateCommand() { ExecuteAction = new Action<object>(DeletePlaneExecute) };
        }
        public void AddBlockExecute(object parameter)
        {
            AddBlockWindow addBlockWindow = new AddBlockWindow();
            AddBlockWindowViewModel AddBlockWindowvm = addBlockWindow.DataContext as AddBlockWindowViewModel;
            AddBlockWindowvm.CallBack = new Func<Block, bool>(CallBack);
            addBlockWindow.Show();
        }
        public void DeletePlaneExecute(object parameter)
        {
            string message = "是否确定删除";
            string detailMessage = string.Format("本操作将会删除楼层：{0}，以及该楼层内全部区域和区域内的货物", Plane.PlaneName);
            PromptWindow prompt = new PromptWindow(message, detailMessage);
            bool? IsConfirmed = prompt.ShowDialog();
            if (IsConfirmed == true)
            {
                WarehouseManagementUserControl wmuc = parameter as WarehouseManagementUserControl;
                WarehouseManagementUserControlViewModel wmucvm = wmuc.DataContext as WarehouseManagementUserControlViewModel;
                wmucvm.CargoCollectionViewModels = null;
                DeleteCargoCollections();
                CMContext.Plane.Remove(Plane);
                WarehouseViewModel.PlaneViewModels.Remove(this);
                CMContext.SaveChanges();
            }
            
        }
        public bool CallBack(Block block)
        {
            if (block != null)
            {
                bool IsExist = BlockViewModels.Any<BlockViewModel>
                    (item => item.Block.BlockName == block.BlockName);
                if (!IsExist)
                {
                    block.WarehouseName = Plane.WarehouseName;
                    block.PlaneName = Plane.PlaneName;
                    BlockViewModel newBlockViewModel = new BlockViewModel(CMContext)
                    {
                        Block = block,
                        PlaneViewModel = this
                    };
                    CMContext.Block.Add(block);
                    BlockViewModels.Add(newBlockViewModel);
                    CMContext.SaveChanges();
                    return false;
                }
                else
                {
                    return true;
                }   
            }
            else
            {
                return false;
            }
        }
        public void DeleteCargoCollections()
        {
            foreach (var blockViewModel in BlockViewModels)
            {
                blockViewModel.DeleteCargoCollections();
            }
        }
    }
}
