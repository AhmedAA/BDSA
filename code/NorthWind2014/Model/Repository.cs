using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    class Repository : IRepository
    {
        public event EventHandler<NewOrderEventArgs> NewOrderEvent;
        public event PropertyChangedEventHandler PropertyChanged;

        public ICollection<Product> Products
        {
            get
            {
                using (var context = new northwindEntities())
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    IEnumerable<Product> all = from p in context.Products
                                      select p;

                    return all.ToList();
                }
            }
        }

        public ICollection<Order> Orders
        {
            get
            {
                using (var context = new northwindEntities())
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    IEnumerable<Order> all = from p in context.Orders
                                      select p;

                    return all.ToList();
                }
            }
        }

        public ICollection<Category> Categories
        {
            get
            {
                using (var context = new northwindEntities())
                {
                    context.Configuration.ProxyCreationEnabled = false;
                    IEnumerable<Category> all = from p in context.Categories
                              select p;

                    return all.ToList();
                }
            }
        }

        public void CreateOrder(string name, string address, string city, string region, string postalCode, string country)
        {
            NotifyPropertyChanged("Order");
            throw new NotImplementedException();
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
