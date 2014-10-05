using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace NorthWind.Model
{
    public class Product
    {
        [Column("ProductID")]
        public int Id { get; set; }

        [Column("ProductName")]
        public string Name { get; set; }

        public decimal? UnitPrice { get; set; }

        [Column("CategoryID")]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public Product(string[] csvArray)
        {
            Id = Int32.Parse(csvArray[0]);
            Name = csvArray[1];
            UnitPrice = Decimal.Parse(csvArray[5]);
            CategoryId = Int32.Parse(csvArray[3]);
        }

        public Product(){}
    }
}
