﻿using CargoManagementSystem.Service;
using CargoManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CargoManagementSystem.View
{
    /// <summary>
    /// Interaction logic for AddPurchaseOrderCollectionWindow.xaml
    /// </summary>
    public partial class AddPurchaseOrderCollectionWindow : Window
    {
        public CargoManagementContext CMContext { get; set; }
        public AddPurchaseOrderCollectionWindow()
        {
            InitializeComponent();
            this.DataContext = new AddPurchaseOrderCollectionWindowViewModel() { CMContext = CMContext};
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
