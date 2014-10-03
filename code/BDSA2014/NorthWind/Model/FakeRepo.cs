using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    class FakeRepo : IRepository
    {
        public Product[] Products
        {
            get
            {
                return new Product[]
                {
                    new Product(new[] {"1", "Product1", "20.0", "1"}),
                    new Product(new[] {"2", "Product2", "10.0", "1"})
                };
            }
        }

        public Order[] Orders
        {
            get
            {
                return new Order[]
                {
                    new Order(new[] {"1", "2014-09-15 00:00:00"}),
                    new Order(new[] {"2", "2014-09-20 00:00:00"})
                };
            }
        }

        public Category[] Categories
        {
            get
            {
                return new Category[]
                {
                    new Category(new[] {"1", "Category1"}),
                    new Category(new[] {"2", "Category2"})
                };
            }
        }

        public void CreateOrder()
        {
            throw new NotImplementedException();
        }
    }
}
