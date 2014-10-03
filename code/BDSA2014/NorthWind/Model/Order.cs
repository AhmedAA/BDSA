using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWind.Model
{
    public class Order
    {
        [Column("OrderID")]
        public int Id { get; set; }
        //public Customer Customer { get; set; }
        //public Employee Employee { get; set; }
        [Column("OrderDate")]
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
            Id = Int32.Parse(csvArray[0]);
            OrderDate = DateTime.Parse(csvArray[3]);
        }

    }
}
