// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using FineFabrics.CustomersApp.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WiredBrainCoffee.CustomersApp.Data;

namespace FineFabrics.CustomersApp
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Title = "Customers App";
            ViewModel = new MainViewModel(new CustomerDataProvider());
            root.DataContext = ViewModel;
            root.Loaded += Root_Loaded;
        }

        public MainViewModel ViewModel { get; }

        private async void Root_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadAsync();
        }

        
        private void ButtonMoveNavigation_Click(object sender, RoutedEventArgs e)
        {
            //var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            var column = Grid.GetColumn(customerListGrid);
            var newValue = column == 0 ? 2 : 0;

            //customerListGrid.SetValue(Grid.ColumnProperty, newValue);
            Grid.SetColumn(customerListGrid, newValue);

            symbolIconMovenavigation.Symbol = newValue == 0 ? Symbol.Forward : Symbol.Back;
        }
    }
}
