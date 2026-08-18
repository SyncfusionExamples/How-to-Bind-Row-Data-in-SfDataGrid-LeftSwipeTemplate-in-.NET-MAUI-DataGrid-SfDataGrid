using Microsoft.Maui.Controls;
using System;

namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        private readonly OrderInfoRepository viewModel;

        public MainPage()
        {
            InitializeComponent();

            viewModel = new OrderInfoRepository();
            viewModel.ShowRowDetails = async row =>
            {
                await DisplayAlert(
                    "Row Details",
                    $"Order ID: {row.OrderID}\nCustomer ID: {row.CustomerID}\nCustomer Name: {row.Customer}\nShip Country: {row.ShipCountry}\nShip City: {row.ShipCity}",
                    "OK");
            };

            BindingContext = viewModel;
        }

        private void Datagrid_SwipeEnded(object? sender, Syncfusion.Maui.DataGrid.DataGridSwipeEndedEventArgs e)
        {
            viewModel.SwipedRowIndex = e.RowIndex;
        }

        private void dataGrid_SwipeStarting(object sender, Syncfusion.Maui.DataGrid.DataGridSwipeStartingEventArgs e)
        {
            if(e.RowData != null)
            {
                viewModel.CurrentSwipeRow = e.RowData as OrderInfo;
            }      
        }
    }
}
