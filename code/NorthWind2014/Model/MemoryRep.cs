using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Model
{
    public class MemoryRep : IRepository
    {
        private ICollection<Product> _products;
        private ICollection<Order> _orders;
        private ICollection<Order_Detail> _orderDetails;
        private ICollection<Employee> _employees;
        private ICollection<Category> _categories;

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<NewOrderEventArgs> NewOrderEvent;

        public MemoryRep()
        {
            _categories = new ObservableCollection<Category>(new Category[]
            {
                new Category() {CategoryID = 1, CategoryName = "Cakes", Description = "The cake is a lie!"},
                new Category() {CategoryID = 2, CategoryName = "Yoghourt", Description = "Y-y-y-yoghourt"},
                new Category() {CategoryID = 3, CategoryName = "Waldos Wizardries", Description = "You don't want to know..."},
            });

            _products = new ObservableCollection<Product>(new Product[]
            {
                new Product() {CategoryID = 1, ProductID = 1, ProductName = "Cheese Cake", UnitPrice = 10, Category = _categories.First(x => x.CategoryID == 1)},
                new Product() {CategoryID = 1, ProductID = 2, ProductName = "Strawberry Cake", UnitPrice = 15, Category = _categories.First(x => x.CategoryID == 1)},
                new Product() {CategoryID = 2, ProductID = 3, ProductName = "Yoyo Yoghourt", UnitPrice = 8, Category = _categories.First(x => x.CategoryID == 2)}
            });

            _orderDetails = new ObservableCollection<Order_Detail>(new Order_Detail[]
            {
                new Order_Detail() {OrderID = 1, ProductID = 1, UnitPrice = 10, Quantity = 10, Discount = 10, Product = _products.First(x => x.ProductID == 1)},
                new Order_Detail() {OrderID = 1, ProductID = 2, UnitPrice = 15, Quantity = 20, Discount = 20, Product = _products.First(x => x.ProductID == 2)},
                new Order_Detail() {OrderID = 2, ProductID = 1, UnitPrice = 10, Quantity = 25, Discount = 50, Product = _products.First(x => x.ProductID == 1)},
                new Order_Detail() {OrderID = 2, ProductID = 2, UnitPrice = 15, Quantity = 25, Discount = 50, Product = _products.First(x => x.ProductID == 2)},
                new Order_Detail() {OrderID = 2, ProductID = 3, UnitPrice = 8, Quantity = 48, Discount = 50, Product = _products.First(x => x.ProductID == 3)},
                new Order_Detail() {OrderID = 3, ProductID = 1, UnitPrice = 10, Quantity = 100, Discount = 200, Product = _products.First(x => x.ProductID == 1)},
                new Order_Detail() {OrderID = 3, ProductID = 3, UnitPrice = 8, Quantity = 100, Discount = 100, Product = _products.First(x => x.ProductID == 3)},
                new Order_Detail() {OrderID = 4, ProductID = 2, UnitPrice = 15, Quantity = 15, Discount = 15, Product = _products.First(x => x.ProductID == 2)},
                new Order_Detail() {OrderID = 5, ProductID = 3, UnitPrice = 8, Quantity = 10, Discount = 0, Product = _products.First(x => x.ProductID == 3)},
            });

            var order1OrderDetails = _orderDetails.Where(x => x.OrderID == 1);
            var order2OrderDetails = _orderDetails.Where(x => x.OrderID == 2);
            var order3OrderDetails = _orderDetails.Where(x => x.OrderID == 3);
            var order4OrderDetails = _orderDetails.Where(x => x.OrderID == 4);
            var order5OrderDetails = _orderDetails.Where(x => x.OrderID == 5);

            _orders = new ObservableCollection<Order>(new Order[]
            {
                new Order() {OrderID = 1, Order_Details = order1OrderDetails.ToList(),CustomerID = "ITU", EmployeeID = 1, OrderDate = DateTime.Today, ShipAddress = "Rued Langaardsvej 7", ShipCity = "Copenhagen", ShipCountry = "Denmark"},
                new Order() {OrderID = 2, Order_Details = order2OrderDetails.ToList(), CustomerID = "ITU", EmployeeID = 1, OrderDate = DateTime.Today, ShipAddress = "Rued Langaardsvej 7", ShipCity = "Copenhagen", ShipCountry = "Denmark"},
                new Order() {OrderID = 3, Order_Details = order3OrderDetails.ToList(), CustomerID = "ITU", EmployeeID = 2, OrderDate = DateTime.Today, ShipAddress = "Rued Langaardsvej 7", ShipCity = "Copenhagen", ShipCountry = "Denmark"},
                new Order() {OrderID = 4, Order_Details = order4OrderDetails.ToList(), CustomerID = "ITU", EmployeeID = 3, OrderDate = DateTime.Today, ShipAddress = "Rued Langaardsvej 7", ShipCity = "Copenhagen", ShipCountry = "Denmark"},
                new Order() {OrderID = 5, Order_Details = order5OrderDetails.ToList(), CustomerID = "ITU", EmployeeID = 4, OrderDate = DateTime.Today, ShipAddress = "Rued Langaardsvej 7", ShipCity = "Copenhagen", ShipCountry = "Denmark"},
            });

            // Add order objects to the order details.
            _orderDetails.ToList().ForEach(x => x.Order = _orders.First(y => y.OrderID == x.OrderID));

            _employees = new ObservableCollection<Employee>(new Employee[]
            {
                new Employee() {EmployeeID = 1, FirstName = "John", LastName = "Smith", ReportsTo = null, },
                new Employee() {EmployeeID = 2, FirstName = "Marie", LastName = "Curie", ReportsTo = 1, },
                new Employee() {EmployeeID = 3, FirstName = "Albert", LastName = "mc2=E(instein)", ReportsTo = 1, },
                new Employee() {EmployeeID = 4, FirstName = "Robert", LastName = "De Bruce", ReportsTo = 2, },
            });

            _orders.ToList().ForEach(x => x.Employee = _employees.First(y => y.EmployeeID == x.EmployeeID));
        }

        public ICollection<Product> Products
        {
            get { return _products; }
        }

        public ICollection<Order> Orders
        {
            get { return _orders; }
        }

        public ICollection<Order_Detail> OrderDetails
        {
            get { return _orderDetails; }
        }

        public ICollection<Employee> Employees
        {
            get { return _employees; }
        }

        public ICollection<Category> Categories
        {
            get { return _categories; }
        }

        public void CreateOrder(string name, string address, string city, string region, string postalCode, string country)
        {
            var newestOrder = (from o in Orders
                               orderby o.OrderID descending
                               select o).First();

            var newOrder = new Order()
            {
                OrderID = newestOrder.OrderID + 1,
                ShipName = name,
                ShipAddress = address,
                ShipCity = city,
                ShipRegion = region,
                ShipPostalCode = postalCode,
                ShipCountry = country,
                OrderDate = DateTime.Today
            };
            _orders.Add(newOrder);
            NewOrderEvent(this, new NewOrderEventArgs() { OrderId = newOrder.OrderID, OrderDate = newOrder.OrderDate ?? DateTime.Today });
        }
    }
}
