using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using NorthWind.Model;

namespace NorthWind
{
    interface INorthWind
    {
        void AddOrder();
        Product[] Products { get; }
        Order[] Orders { get; } 
    }
}
