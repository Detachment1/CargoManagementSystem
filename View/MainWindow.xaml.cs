using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CargoManagementSystem.Model;
using CargoManagementSystem.Service;
using CargoManagementSystem.ViewModel;
using MaterialDesignThemes;

namespace CargoManagementSystem.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public SearchUserControl SearchView { get; set; }
        public PurchaseCargoUserControl PurchaseCargoView { get; set; }
        public SellCargoUserControl SellCargoView { get; set; }
        public CategoryManagementUserControl CategoryManagementView { get; set; }
        public WarehouseManagementUserControl WarehouseManagementView { get; set; }
        public LogPurchaseOrderUserControl LogPurchaseOrderView { get; set; }
        public LogSellOrderUserControl LogSellOrderView { get; set; }
        public CargoManagementContext CMContext { get; set; }

        public ObservableCollection<CargoViewModel> CargoViewModels { get; set; }
        public ObservableCollection<CargoCollectionViewModel> CargoCollectionViewModels { get; set; }
        public WarehouseRootViewModel WarehouseRootViewModel { get; set; }
        public ObservableCollection<PurchaseOrderCollectionViewModel> PurchaseOrderCollectionViewModels { get; set; }
        public ObservableCollection<SellOrderCollectionViewModel> SellOrderCollectionViewModels { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CargoCollectionViewModels = new ObservableCollection<CargoCollectionViewModel>();
            CargoViewModels = new ObservableCollection<CargoViewModel>();
            CMContext = new CargoManagementContext();
            CMContext.CargoCollection.Load();
            CMContext.Cargo.Load();
            CMContext.Block.Load();
            CMContext.Warehouse.Load();
            CMContext.Plane.Load();
            CMContext.PurchaseOrder.Load();
            CMContext.PurchaseOrderCollection.Load();
            CMContext.SellOrder.Load();
            CMContext.SellOrderCollection.Load();
            CMContext.PurchasePrizeDic.Load();
            InitializeViewModels();

            SearchView = new SearchUserControl(CMContext, CargoCollectionViewModels) { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch};
            PurchaseCargoView = new PurchaseCargoUserControl(CMContext, WarehouseRootViewModel, CargoViewModels, CargoCollectionViewModels, PurchaseOrderCollectionViewModels) { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch };
            SellCargoView = new SellCargoUserControl(CMContext, CargoCollectionViewModels, SellOrderCollectionViewModels) { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch };
            CategoryManagementView = new CategoryManagementUserControl(CMContext, CargoViewModels, CargoCollectionViewModels) { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch };
            WarehouseManagementView = new WarehouseManagementUserControl(CMContext, WarehouseRootViewModel, CargoCollectionViewModels) { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch };
            LogPurchaseOrderView = new LogPurchaseOrderUserControl(CMContext, PurchaseOrderCollectionViewModels) { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch };
            LogSellOrderView = new LogSellOrderUserControl(CMContext, SellOrderCollectionViewModels) { VerticalAlignment = VerticalAlignment.Stretch, HorizontalAlignment = HorizontalAlignment.Stretch };

            //DateTime time = new DateTime();
            //Console.WriteLine(time);
            //Thread.Sleep(1000);
            //DateTime time2 = DateTime.Now;
            //Console.WriteLine(time2);
            //Console.WriteLine(time < time2);
            this.DataContext = new MainWindowViewModel(CMContext);
            this.ShowPanel.Children.Add(SearchView);
            
        }

        private void ShowSearchView(object sender, RoutedEventArgs e)
        {
            List<UIElement> buffer = new List<UIElement>();
            foreach (UIElement uie in this.ShowPanel.Children)
            {
                buffer.Add(uie);
            }
            foreach (UIElement uie in buffer)
            {
                this.ShowPanel.Children.Remove(uie);
            }
            this.ShowPanel.Children.Add(SearchView);
        }
        private void ShowPurchaseCargoView(object sender, RoutedEventArgs e)
        {
            List<UIElement> buffer = new List<UIElement>();
            foreach (UIElement uie in this.ShowPanel.Children)
            {
                buffer.Add(uie);
            }
            foreach (UIElement uie in buffer)
            {
                this.ShowPanel.Children.Remove(uie);
            }
            this.ShowPanel.Children.Add(PurchaseCargoView);
        }
        private void ShowSellCargoView(object sender, RoutedEventArgs e)
        {
            List<UIElement> buffer = new List<UIElement>();
            foreach (UIElement uie in this.ShowPanel.Children)
            {
                buffer.Add(uie);
            }
            foreach (UIElement uie in buffer)
            {
                this.ShowPanel.Children.Remove(uie);
            }
            this.ShowPanel.Children.Add(SellCargoView);
        }
        private void ShowCategoryManagementView(object sender, RoutedEventArgs e)
        {
            List<UIElement> buffer = new List<UIElement>();
            foreach (UIElement uie in this.ShowPanel.Children)
            {
                buffer.Add(uie);
            }
            foreach (UIElement uie in buffer)
            {
                this.ShowPanel.Children.Remove(uie);
            }
            this.ShowPanel.Children.Add(CategoryManagementView);
        }
        private void ShowWarehouseManagementView(object sender, RoutedEventArgs e)
        {
            List<UIElement> buffer = new List<UIElement>();
            foreach (UIElement uie in this.ShowPanel.Children)
            {
                buffer.Add(uie);
            }
            foreach (UIElement uie in buffer)
            {
                this.ShowPanel.Children.Remove(uie);
            }
            this.ShowPanel.Children.Add(WarehouseManagementView);
        }
        private void ShowLogPurchaseOrderView(object sender, RoutedEventArgs e)
        {
            List<UIElement> buffer = new List<UIElement>();
            foreach (UIElement uie in this.ShowPanel.Children)
            {
                buffer.Add(uie);
            }
            foreach (UIElement uie in buffer)
            {
                this.ShowPanel.Children.Remove(uie);
            }
            this.ShowPanel.Children.Add(LogPurchaseOrderView);
        }
        private void ShowLogSellOrderView(object sender, RoutedEventArgs e)
        {
            List<UIElement> buffer = new List<UIElement>();
            foreach (UIElement uie in this.ShowPanel.Children)
            {
                buffer.Add(uie);
            }
            foreach (UIElement uie in buffer)
            {
                this.ShowPanel.Children.Remove(uie);
            }
            this.ShowPanel.Children.Add(LogSellOrderView);
        }

        private void InitializeViewModels()
        {
            WarehouseRootViewModel = new WarehouseRootViewModel(CMContext);
            foreach (var warehouse in CMContext.Warehouse.Local)
            {
                WarehouseViewModel bufferWarehouseViewModel = new WarehouseViewModel(CMContext);
                bufferWarehouseViewModel.Warehouse = warehouse;
                foreach(var plane in warehouse.Planes)
                {
                    PlaneViewModel bufferPlaneViewModel = new PlaneViewModel(CMContext);
                    bufferPlaneViewModel.Plane = plane;
                    foreach(var block in plane.Blocks)
                    {
                        BlockViewModel bufferBlockViewModel = new BlockViewModel(CMContext);
                        bufferBlockViewModel.Block = block;
                        foreach (var cargoCollection in block.CargoCollections)
                        {
                            CargoCollectionViewModel bufferCargoCollectionViewModel = new CargoCollectionViewModel(CMContext)
                            { CargoCollectionViewModels = CargoCollectionViewModels};
                            bufferCargoCollectionViewModel.CargoCollection = cargoCollection;
                            bufferCargoCollectionViewModel.BlockViewModel = bufferBlockViewModel;
                            bufferCargoCollectionViewModel.SelectedPurchasePrizeDic = bufferCargoCollectionViewModel.CargoCollection.PurchasePrizeDics[0];
                            bufferCargoCollectionViewModel.CargoCollectionViewModels = CargoCollectionViewModels;

                            bufferBlockViewModel.CargoCollectionViewModels.Add(bufferCargoCollectionViewModel);
                            CargoCollectionViewModels.Add(bufferCargoCollectionViewModel);
                        }
                        bufferBlockViewModel.PlaneViewModel = bufferPlaneViewModel;
                        bufferPlaneViewModel.BlockViewModels.Add(bufferBlockViewModel);
                    }
                    bufferPlaneViewModel.WarehouseViewModel = bufferWarehouseViewModel;
                    bufferWarehouseViewModel.PlaneViewModels.Add(bufferPlaneViewModel);
                }
                bufferWarehouseViewModel.WarehouseRootViewModel = WarehouseRootViewModel;
                WarehouseRootViewModel.WarehouseViewModels.Add(bufferWarehouseViewModel);
            }
            foreach (var cargo in CMContext.Cargo.Local)
            {
                CargoViewModel bufferCargoViewModel = new CargoViewModel(CMContext);
                bufferCargoViewModel.Cargo = cargo;
                bufferCargoViewModel.CargoViewModels = CargoViewModels;
                bufferCargoViewModel.CargoCollectionViewModels = CargoCollectionViewModels;
                CargoViewModels.Add(bufferCargoViewModel);
            }
            PurchaseOrderCollectionViewModels = new ObservableCollection<PurchaseOrderCollectionViewModel>();
            foreach (var purchaseOrderCollection in CMContext.PurchaseOrderCollection.Local)
            {
                PurchaseOrderCollectionViewModel pocvm = new PurchaseOrderCollectionViewModel(CMContext)
                { PurchaseOrderCollection = purchaseOrderCollection, PurchaseOrderCollectionViewModels = PurchaseOrderCollectionViewModels};
                foreach (var purchaseOrder in purchaseOrderCollection.PurchaseOrders)
                {
                    PurchaseOrderViewModel povm = new PurchaseOrderViewModel(CMContext)
                    { PurchaseOrder = purchaseOrder, PurchaseOrderCollectionViewModel = pocvm};
                    pocvm.PurchaseOrderViewModels.Add(povm);
                }
                PurchaseOrderCollectionViewModels.Add(pocvm);
            }
            SellOrderCollectionViewModels = new ObservableCollection<SellOrderCollectionViewModel>();
            foreach (var sellOrderCollection in CMContext.SellOrderCollection.Local)
            {
                SellOrderCollectionViewModel socvm = new SellOrderCollectionViewModel(CMContext)
                { SellOrderCollection = sellOrderCollection, SellOrderCollectionViewModels = SellOrderCollectionViewModels };
                foreach (var sellOrder in sellOrderCollection.SellOrders)
                {
                    SellOrderViewModel sovm = new SellOrderViewModel(CMContext, new CargoCollectionViewModel())
                    { SellOrder = sellOrder};
                    socvm.SellOrderViewModels.Add(sovm);
                }
                SellOrderCollectionViewModels.Add(socvm);
            }
        }
    }
}
