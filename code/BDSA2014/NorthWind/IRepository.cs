using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind
{
    interface IRepository
    {
        Product[] Products { get; }
        Order[] Orders { get; }
        Category[] Categories { get; }
        void CreateOrder();
    }
}
