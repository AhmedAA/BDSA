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
        public event EventHandler<NewOrderEventArgs> NewOrderEvent;

        private bool _productUpdated = true, _ordersUpdated = true, _categoriesUpdated = true;
        private Product[] _productCache;
        private Order[] _orderCache;
        private Category[] _categoryCache;

        public Product[] Products
        {
            get
            {
                if (!_productUpdated) return _productCache;
                using (var repo = new NorthWindContext())
                {
                    var allProducts = from p in repo.Products
                        select p;

                    _productCache = allProducts.ToArray();
                    _productUpdated = false;
                }
                return _productCache;
            }
        }

        public Order[] Orders
        {
            get
            {
                if (!_ordersUpdated) return _orderCache;
                using (var repo = new NorthWindContext())
                {
                    var allOrders = from o in repo.Orders
                                    select o;

                    _orderCache = allOrders.ToArray();
                    _ordersUpdated = false;
                }
                return _orderCache;
            }

        }

        public Category[] Categories
        {
            get
            {
                if (!_categoriesUpdated) return _categoryCache;
                using (var repo = new NorthWindContext())
                {
                    var allCategories = from a in repo.Categories
                                        select a;

                    _categoryCache = allCategories.ToArray();
                    _categoriesUpdated = false;
                }
                return _categoryCache;
            }
        }

        public void CreateOrder(string name, string address, string city, string region, string postalCode, string country)
        {
            using (var context = new NorthWindContext())
            {
                var newestOrder = (from o in context.Orders
                                   orderby o.Id descending
                                   select o).First();

                var order = new Order
                {
                    OrderDate = DateTime.Today,
                    Id = newestOrder.Id + 1,      //Databasen kunne selv gøre det her, men det var en del af opgaven
                    ShipName = name,
                    ShipAddress = address,
                    ShipCity = city,
                    ShipRegion = region,
                    ShipPostalCode = postalCode,
                    ShipCountry = country
                };
                context.Orders.Add(order);
                context.SaveChanges();
                NewOrderEvent(this, new NewOrderEventArgs() { OrderId = order.Id, OrderDate = order.OrderDate }); // Fire the new order event, when changes are saved to the database.
                _ordersUpdated = true;
            }
        }
    }
}
