using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NorthWind.Model
{
    class Repository : IRepository
    {
        public event EventHandler<NewOrderEventArgs> NewOrderEvent;
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Product> _productsCache;
        private ObservableCollection<Order> _ordersCache;
        private ObservableCollection<Category> _categoriesCache;

        public ICollection<Product> Products
        {
            get
            {
                if (_productsCache == null)
                {
                    using (var context = new northwindEntities())
                    {
                        context.Configuration.ProxyCreationEnabled = false;
                        IEnumerable<Product> all = from p in context.Products
                                                   select p;

                        _productsCache = new ObservableCollection<Product>(all);
                    }
                }
                return _productsCache;
            }
        }

        public ICollection<Order> Orders
        {
            get
            {
                if (_ordersCache == null)
                {
                    using (var context = new northwindEntities())
                    {
                        context.Configuration.ProxyCreationEnabled = false;
                        IEnumerable<Order> all = from p in context.Orders
                                                 select p;

                        _ordersCache = new ObservableCollection<Order>(all);
                    }
                }
                return _ordersCache;
            }
        }

        public ICollection<Category> Categories
        {
            get
            {
                if (_categoriesCache == null)
                {
                    using (var context = new northwindEntities())
                    {
                        context.Configuration.ProxyCreationEnabled = false;
                        IEnumerable<Category> all = from p in context.Categories
                                                    select p;

                        _categoriesCache = new ObservableCollection<Category>(all);
                    }
                }
                return _categoriesCache;
            }
        }

        public void CreateOrder(string name, string address, string city, string region, string postalCode,
            string country)
        {
            using (var context = new northwindEntities())
            {
                var newestOrder = (from o in context.Orders
                                   orderby o.OrderID descending
                                   select o).First();

                DateTime orderDate = DateTime.Today;
                var order = new Order
                {
                    OrderDate = orderDate,
                    OrderID = newestOrder.OrderID + 1,
                    //Databasen kunne selv gøre det her, men det var en del af opgaven
                    ShipName = name,
                    ShipAddress = address,
                    ShipCity = city,
                    ShipRegion = region,
                    ShipPostalCode = postalCode,
                    ShipCountry = country
                };
                context.Orders.Add(order); // Add to database.
                context.SaveChanges();
                _ordersCache.Add(order); // Add to the list displayed.
                NewOrderEvent(this, new NewOrderEventArgs() { OrderId = order.OrderID, OrderDate = orderDate });
                NotifyPropertyChanged("Order");
                // Fire the new order event, when changes are saved to the database.
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
