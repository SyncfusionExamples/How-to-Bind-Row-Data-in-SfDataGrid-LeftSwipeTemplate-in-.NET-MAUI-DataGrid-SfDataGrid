using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SfDataGridSample
{
    public class OrderInfo : INotifyPropertyChanged
    {
        private int orderID;
        private string customerID;
        private string customer;
        private string shipCity;
        private string shipCountry;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int OrderID
        {
            get => orderID;
            set
            {
                if (orderID != value)
                {
                    orderID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string CustomerID
        {
            get => customerID;
            set
            {
                if (customerID != value)
                {
                    customerID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ShipCountry
        {
            get => shipCountry;
            set
            {
                if (shipCountry != value)
                {
                    shipCountry = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Customer
        {
            get => customer;
            set
            {
                if (customer != value)
                {
                    customer = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ShipCity
        {
            get => shipCity;
            set
            {
                if (shipCity != value)
                {
                    shipCity = value;
                    OnPropertyChanged();
                }
            }
        }

        public OrderInfo(int orderId, string customerId, string country, string customer, string shipCity)
        {
            OrderID = orderId;
            CustomerID = customerId;
            Customer = customer;
            ShipCountry = country;
            ShipCity = shipCity;
        }
    }

}
