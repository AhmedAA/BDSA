using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    public class Repository : IRepository
    {
        private static int orderId = 50000;
        public Product[] Products
        {
            get
            {
                using (var repo = new NorthWindContext())
                {
                    var allProducts = from p in repo.Products
                        select p;

                    return allProducts.ToArray();
                }
            }
        }

        public Order[] Orders
        {
            get
            {
                using (var repo = new NorthWindContext())
                {
                    var allOrders = from o in repo.Orders
                                      select o;

                    return allOrders.ToArray();
                }
            }
            
        }

        public Category[] Categories
        {
            get
            {
                using (var repo = new NorthWindContext())
                {
                    var allCategories = from a in repo.Categories
                                      select a;

                    return allCategories.ToArray();
                }
            }
        }

        public void CreateOrder(string name, string address, string city, string region, string postalCode, string country)
        {
            using (var repo = new NorthWindContext())
            {

                var order = new Order
                {
                    OrderDate = DateTime.Today,
                    Id = orderId++,
                    ShipName = name,
                    ShipAddress = address,
                    ShipCity = city,
                    ShipRegion = region,
                    ShipPostalCode = postalCode,
                    ShipCountry = country
                };
                repo.Orders.Add(order);
                repo.SaveChanges();
            }
        }
    }
}
