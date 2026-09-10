using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace SfDataGridSample
{
    public class OrderInfoRepository : INotifyPropertyChanged
    {
        private ObservableCollection<OrderInfo> orderInfo;
        private int swipedRowIndex = -1;
        private OrderInfo? currentSwipeRow;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ObservableCollection<OrderInfo> OrderInfoCollection
        {
            get { return orderInfo; }
            set { this.orderInfo = value; }
        }

        public ICommand TapCommand { get; }

        public Action<OrderInfo>? ShowRowDetails { get; set; }

        public OrderInfo? CurrentSwipeRow
        {
            get => currentSwipeRow;
            set
            {
                if (currentSwipeRow != value)
                {
                    currentSwipeRow = value;
                    OnPropertyChanged();
                }
            }
        }

        public int SwipedRowIndex
        {
            get { return swipedRowIndex; }
            set
            {
                if (swipedRowIndex != value)
                {
                    swipedRowIndex = value;
                    OnPropertyChanged();
                }
            }
        }

        public OrderInfoRepository()
        {
            orderInfo = new ObservableCollection<OrderInfo>();
            TapCommand = new RelayCommand(ExecuteTapCommand);
            this.GenerateOrders();
        }

        private void ExecuteTapCommand()
        {
            var row = GetRowFromSwipedIndex();
            if (row != null)
            {
                ShowRowDetails?.Invoke(row);
            }
        }

        private OrderInfo? GetRowFromSwipedIndex()
        {
            if (SwipedRowIndex >= 0 && SwipedRowIndex <= orderInfo.Count)
            {
                // (-1)Need to Skip the Header Row
                var details = orderInfo[SwipedRowIndex - 1 ];
                return details;
            }

            return null;
        }

        public void GenerateOrders()
        {
            orderInfo.Add(new OrderInfo(1001, "Maria Anders", "Germany", "ALFKI", "Berlin"));
            orderInfo.Add(new OrderInfo(1002, "Ana Trujillo", "Mexico", "ANATR", "Mexico D.F."));
            orderInfo.Add(new OrderInfo(1003, "Ant Fuller", "Mexico", "ANTON", "Mexico D.F."));
            orderInfo.Add(new OrderInfo(1004, "Thomas Hardy", "UK", "AROUT", "London"));
            orderInfo.Add(new OrderInfo(1005, "Tim Adams", "Sweden", "BERGS", "London"));
            orderInfo.Add(new OrderInfo(1006, "Hanna Moos", "Germany", "BLAUS", "Mannheim"));
            orderInfo.Add(new OrderInfo(1007, "Andrew Fuller", "France", "BLONP", "Strasbourg"));
            orderInfo.Add(new OrderInfo(1008, "Martin King", "Spain", "BOLID", "Madrid"));
            orderInfo.Add(new OrderInfo(1009, "Lenny Lin", "France", "BONAP", "Marsiella"));
            orderInfo.Add(new OrderInfo(1010, "John Carter", "Canada", "BOTTM", "Lenny Lin"));
            orderInfo.Add(new OrderInfo(1011, "Laura King", "UK", "AROUT", "London"));
            orderInfo.Add(new OrderInfo(1012, "Anne Wilson", "Germany", "BLAUS", "Mannheim"));
            orderInfo.Add(new OrderInfo(1013, "Martin King", "France", "BLONP", "Strasbourg"));
            orderInfo.Add(new OrderInfo(1014, "Gina Irene", "UK", "AROUT", "London"));
            orderInfo.Add(new OrderInfo(1015, "Maria Anders", "Germany", "ALFKI", "Berlin"));
            orderInfo.Add(new OrderInfo(1016, "Anabella", "Mexico", "ANATR", "Mexico D.F."));
            orderInfo.Add(new OrderInfo(1017, "Ant louis", "Mexico", "ANTON", "Mexico D.F."));
            orderInfo.Add(new OrderInfo(1018, "Michael Scofield", "UK", "AROUT", "London"));
            orderInfo.Add(new OrderInfo(1019, "Tom cook", "Sweden", "BERGS", "London"));
            orderInfo.Add(new OrderInfo(1020, "Jack Wilson", "Germany", "BLAUS", "Mannheim"));      
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private sealed class RelayCommand : ICommand
        {
            private readonly Action execute;

            public RelayCommand(Action execute)
            {
                this.execute = execute;
            }

            public event EventHandler? CanExecuteChanged
            {
                add { }
                remove { }
            }

            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                execute();
            }
        }
    }
}
