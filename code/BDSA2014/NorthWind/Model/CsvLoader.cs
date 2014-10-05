using System;
using System.IO;
using System.Linq;

namespace NorthWind.Model
{
    public static class CsvLoader
    {

        public static void Main(string[] args)
        {
            LoadFromCsvIntoDb();
        }

        public static Product[] Products { get; set; }

        public static Order[] Orders { get; set; }

        public static Category[] Categories { get; set; }

        static void LoadFromCsvIntoDb()
        {
            LoadProducts("products.csv");
            LoadOrders("orders.csv");
            LoadCategories("categories.csv");

            using (var repo = new NorthWindContext())
            {
                repo.Products.AddRange(Products);
                repo.Orders.AddRange(Orders);
                repo.Categories.AddRange(Categories);
                repo.SaveChanges();
            }
        }

        private static void LoadProducts(string filePath)
        {
            string[] csvArrays = File.ReadAllLines(filePath);
            Product[] products = new Product[csvArrays.Length - 1];
            for (int i = 1; i < csvArrays.Length; i++)
            {
                string[] csvArray = csvArrays[i].Split(';');
                products[i-1] = new Product(csvArray);
            }
            Products = products;
        }
        private static void LoadOrders(string filePath)
        {
            string[] csvArrays = File.ReadAllLines(filePath);
            Order[] orders = new Order[csvArrays.Length - 1];
            for (int i = 1; i < csvArrays.Length; i++)
            {
                string[] csvArray = csvArrays[i].Split(';');
                orders[i - 1] = new Order(csvArray);
            }
            Orders = orders;
        }
        private static void LoadCategories(string filePath)
        {
            string[] csvArrays = File.ReadAllLines(filePath);
            Category[] categories = new Category[csvArrays.Length - 1];
            for (int i = 1; i < csvArrays.Length; i++)
            {
                string[] csvArray = csvArrays[i].Split(';');
                categories[i - 1] = new Category(csvArray);
            }
            Categories = categories;
        }
    }
}
