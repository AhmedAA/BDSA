using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NorthWind.Model;

namespace NorthWind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INorthWind
    {
        private IRepository repo = new FakeRepo();

        public MainWindow()
        {
            
            InitializeComponent();
            ProductGrid.DataContext = Products;
            OrderGrid.DataContext = Orders;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(Products[0].Name);
        }

        public void AddOrder()//int id, DateTime orderDate)
        {
            repo.CreateOrder();
        }

        public Product[] Products
        {
            get { return repo.Products; }
        }

        public Order[] Orders
        {
            get { return repo.Orders; }
        }
    }
}
