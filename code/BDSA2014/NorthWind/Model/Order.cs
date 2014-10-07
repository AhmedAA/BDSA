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
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public Order(string[] csvArray)
        {
            Id = Int32.Parse(csvArray[0]);
            OrderDate = DateTime.Parse(csvArray[3]);
            ShipName = csvArray[8];
            ShipAddress = csvArray[9];
            ShipCity = csvArray[10];
            ShipRegion = csvArray[11];
            ShipPostalCode = csvArray[12];
            ShipCountry = csvArray[13];

        }
        public Order() { }
    }
}
