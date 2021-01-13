﻿using CargoManagementSystem.Service;
using CargoManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CargoManagementSystem.View
{
    /// <summary>
    /// Interaction logic for CategoryManagementUserControl.xaml
    /// </summary>
    public partial class CategoryManagementUserControl : UserControl
    {
        public CategoryManagementUserControl(CargoManagementContext CMContext, 
            ObservableCollection<CargoViewModel> cvms,
            ObservableCollection<CargoCollectionViewModel> ccvms)
        {
            InitializeComponent();
            this.DataContext = new CategoryManagementUserControlViewModel(CMContext, cvms, ccvms);
        }
    }
}
