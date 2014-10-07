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
                    new Product(new[] {"1","Chai","1","1","10 boxes x 20 bags","18","39","0","10","0"}),
                    new Product(new[] {"2","Product2","1","1","10 boxes x 20 bags","18","39","0","10","0"})
                };
            }
        }

        public Order[] Orders
        {
            get
            {
                return new Order[]
                {
                    new Order(new[] {"1","VINET","5","1996-07-04 00:00:00","1996-08-01 00:00:00","1996-07-16 00:00:00","3","32.38","Vins et alcools Chevalier","59 rue de l'Abbaye","Reims",null,"51100","France"}),
                    new Order(new[] {"2","ORDER2","5","2005-02-24 00:00:00","2005-02-24 00:00:00","2005-02-24 00:00:00","3","32.38","Vins et alcools Chevalier","59 rue de l'Abbaye","Reims",null,"51100","France"})
                };
            }
        }

        public Category[] Categories
        {
            get
            {
                return new Category[]
                {
                    new Category(new[] {"1","Beverages","Soft drinks, coffees, teas, beers, and ales"}),
                    new Category(new[] {"2","Condiments","Sweet and savory sauces, relishes, spreads, and seasonings"})
                };
            }
        }

        public void CreateOrder(string name, string address, string city, string region, string postalCode, string country)
        {
            throw new NotImplementedException();
        }
    }
}
