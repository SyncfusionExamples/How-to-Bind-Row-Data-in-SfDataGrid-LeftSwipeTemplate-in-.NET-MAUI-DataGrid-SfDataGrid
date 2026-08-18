# How to Bind Row Data in SfDataGrid LeftSwipeTemplate in .NET MAUI DataGrid SfDataGrid?
This Sample demonstrates how to bind Row Data in SfDataGrid LeftSwipeTemplate with the Syncfusion [.NET Maui DataGrid](https://help.syncfusion.com/maui/datagrid/overview)(SfDataGrid).

This approach uses the SwipeStarting event to capture the currently swiped row and bind its data within the LeftSwipeTemplate. It also enables performing row-specific actions directly from the swipe template using commands.

## Xaml
```
 <ContentPage.Content>
     <syncfusion:SfDataGrid x:Name="dataGrid"
                            AllowSwiping="True"
                            SwipeEnded="Datagrid_SwipeEnded"
                            SwipeStarting="dataGrid_SwipeStarting"
                            ColumnWidthMode="Fill"
                            GridLinesVisibility="Both"
                            HeaderGridLinesVisibility="Both"
                            ItemsSource="{Binding OrderInfoCollection}">
         <syncfusion:SfDataGrid.LeftSwipeTemplate>
             <DataTemplate>
                 <Grid WidthRequest="140" 
                       Padding="0"
                       HorizontalOptions="Fill"
                       VerticalOptions="Center">
                     <Grid.GestureRecognizers>
                         <TapGestureRecognizer NumberOfTapsRequired="1"
                                               Command="{Binding Source={x:Reference dataGrid}, Path=BindingContext.TapCommand}" />
                     </Grid.GestureRecognizers>
                     <StackLayout HorizontalOptions="Center"
                                  VerticalOptions="Center"
                                  Spacing="0">
                         <Label Text="{Binding Source={x:Reference dataGrid}, Path=BindingContext.CurrentSwipeRow.OrderID}"
                                FontSize="16"
                                HorizontalTextAlignment="Center"
                                FontAttributes="Bold"
                                VerticalTextAlignment="Center"
                                TextColor="Black"/>
                     </StackLayout>
                 </Grid>
             </DataTemplate>
         </syncfusion:SfDataGrid.LeftSwipeTemplate>
     </syncfusion:SfDataGrid>
 </ContentPage.Content>


```
## Xaml.cs
```
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

```
## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion's samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion's samples.