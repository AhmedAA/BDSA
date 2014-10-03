using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    class NorthWindContext : DbContext
    {

        static NorthWindContext()
        {
            Database.SetInitializer(new NullDatabaseInitializer<NorthWindContext>());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
