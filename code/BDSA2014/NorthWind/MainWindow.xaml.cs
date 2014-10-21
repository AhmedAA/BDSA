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
using System.Windows.Media.Media3D;
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
        //TODO NewOrderEvent – an event notifying subscribers whenever the above method is called using a NewOrderEventArgs with the order as a property

        private IRepository repo;
     //   private Func<INotifyEvent> 

        /// <summary>
        /// Constructor tager Repo interface som parameter, da dependency injection var en del af opgaven.
        /// </summary>
        /// <param name="repo"></param>
        public MainWindow(IRepository repo)
        {
            this.repo = repo;
            this.repo.NewOrderEvent += repo_NewOrderEvent; // Subscribe to the new order event, to get notified, when a new order is added.
            InitializeComponent();
            ProductGrid.DataContext = Products;
            OrderGrid.DataContext = Orders;
            CategoryGrid.DataContext = Category;
        }

        void repo_NewOrderEvent(object sender, NewOrderEventArgs e)
        {
            var message = "New order with the ID: " + e.OrderId + ", created at: " + e.OrderDate.ToLongDateString();
            MessageBox.Show(this, message, "New Order Created", MessageBoxButton.OK);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrder();
        }

        public void AddOrder()
        {
            //Id skal sættes i Repository
            string name = NameBox.GetLineText(0);
            string address = AddressBox.GetLineText(0);
            string city = CityBox.GetLineText(0);
            string region = RegionBox.GetLineText(0);
            string postalCode = PostalCodeBox.GetLineText(0);
            string country = CountryBox.GetLineText(0);
            repo.CreateOrder(name, address, city, region, postalCode, country);
        }

        public Product[] Products
        {
            get
            {
                try
                {
                    return repo.Products;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error fetching products: " + e.Message);
                    return null;
                }
            }
        }
        

        public Order[] Orders
        {
            get
            {
                try
                {
                    return repo.Orders; 
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error fetching orders: "+ e.Message);
                    return null;
                }
            }
        }

        public Category[] Category
        {
            get
            {
                try
                {
                    return repo.Categories;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error fetching Categories: " + e.Message);
                    return null;
                }
            }
        }
    }
}
