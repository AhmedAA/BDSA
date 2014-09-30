using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind
{
    class CsvRepository : IRepository
    {

        public Product[] Products { get; private set; }

        public Order[] Orders { get; private set; }

        public Category[] Categories { get; private set; }

        public CsvRepository()
        {
            LoadOrders("orders.csv");
        }

        public void CreateOrder()
        {
            throw new NotImplementedException();
        }

        private void LoadOrders(string filePath)
        {
            string[] csvArrays = File.ReadAllLines(filePath);
            Order[] orders = new Order[csvArrays.Length - 1];
            for (int i = 1; i < csvArrays.Length; i++)
            {
                string[] csvArray = csvArrays[i].Split(';');
                orders[i-1] = new Order(csvArray);
            }
        }
    }
}
