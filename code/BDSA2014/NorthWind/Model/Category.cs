using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NorthWind.Model
{
    public class Category
    {
        [Column("CategoryID")]
        public int Id { get; set; }

        [Column("CategoryName")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Category(string[] csvArray)
        {
            Id = Int32.Parse(csvArray[0]);
            Name = csvArray[1];
        }
        public Category() { }
    }
}
