using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NorthWind.Model
{
    public interface IRepository : INotifyPropertyChanged
    {
        event EventHandler<NewOrderEventArgs> NewOrderEvent;
        ICollection<Product> Products { get; }
        ICollection<Order> Orders { get; }
        ICollection<Order_Detail> OrderDetails { get; }
        ICollection<Employee> Employees { get; }
        ICollection<Category> Categories { get; }
        void CreateOrder(string name, string address, string city, string region, string postalCode, string country);
    }

    public class NewOrderEventArgs
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
