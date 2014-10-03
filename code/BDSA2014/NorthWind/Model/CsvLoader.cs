using System;
using System.IO;

namespace NorthWind.Model
{
    class CsvLoader
    {

        public Product[] Products { get; private set; }

        public Order[] Orders { get; private set; }

        public Category[] Categories { get; private set; }

        public CsvLoader()
        {
            LoadProducts("products.csv");
            LoadOrders("orders.csv");
            LoadCategories("categories.csv");
        }

        private void LoadProducts(string filePath)
        {
            string[] csvArrays = File.ReadAllLines(filePath);
            Product[] orders = new Product[csvArrays.Length - 1];
            for (int i = 1; i < csvArrays.Length; i++)
            {
                string[] csvArray = csvArrays[i].Split(';');
                orders[i-1] = new Product(csvArray);
            }
        }
        private void LoadOrders(string filePath)
        {
            string[] csvArrays = File.ReadAllLines(filePath);
            Order[] orders = new Order[csvArrays.Length - 1];
            for (int i = 1; i < csvArrays.Length; i++)
            {
                string[] csvArray = csvArrays[i].Split(';');
                orders[i - 1] = new Order(csvArray);
            }
        }
        private void LoadCategories(string filePath)
        {
            string[] csvArrays = File.ReadAllLines(filePath);
            Category[] orders = new Category[csvArrays.Length - 1];
            for (int i = 1; i < csvArrays.Length; i++)
            {
                string[] csvArray = csvArrays[i].Split(';');
                orders[i - 1] = new Category(csvArray);
            }
        }
    }
}
