using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    class Repository : IRepository
    {
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

        public void CreateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
