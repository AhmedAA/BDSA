using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    public class NorthWindContext : DbContext
    {

        static NorthWindContext()
        {
            Database.SetInitializer<NorthWindContext>(new DropCreateDatabaseIfModelChanges<NorthWindContext>());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
