using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind
{
    class Order
    {
        public int OrderID { get; set; }
        //public Customer Customer { get; set; }
        //public Employee Employee { get; set; }
        public DateTime OrderDate { get; set; }
        //public DateTime RequiredDate { get; set; }
        //public DateTime ShippedDate { get; set; }
        //public SOMETHING ShipVia { get; set; }
        //public double Freight { get; set; }
        //public string ShipName { get; set; }
        //public string ShipAddress { get; set; }
        //public string ShipCity { get; set; }
        //public string ShipRegion { get; set; }
        //public int ShipPostalCode { get; set; }
        //public string ShipCountry { get; set; }

        public Order(string[] csvArray)
        {
            OrderID = Int32.Parse(csvArray[0]);
            OrderDate = DateTime.Parse(csvArray[3]);
        }

    }
}
