using System;

namespace NorthWind.Model
{
    interface IRepository
    {
        Product[] Products { get; }
        Order[] Orders { get; }
        Category[] Categories { get; }
        void CreateOrder(string name, string address, string city, string region, string postalCode, string country);
    }
}
