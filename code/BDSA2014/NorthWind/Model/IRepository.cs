using System;

namespace NorthWind.Model
{
    public interface IRepository
    {
        event EventHandler<NewOrderEventArgs> NewOrderEvent;
        Product[] Products { get; }
        Order[] Orders { get; }
        Category[] Categories { get; }
        void CreateOrder(string name, string address, string city, string region, string postalCode, string country);
    }

    public class NewOrderEventArgs
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
