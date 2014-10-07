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
        
        private IRepository repo = new Repository();
     //   private Func<INotifyEvent> 
        public MainWindow()
        {
            
            InitializeComponent();
            ProductGrid.DataContext = Products;
            OrderGrid.DataContext = Orders;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddOrder();
        }

        public void AddOrder()
        {
           // int id = repo.Orders.LastOrDefault().Id; //skal gøres i repo
            //set { repo.
            string name = NameBox.GetLineText(0);
            string address = AddressBox.GetLineText(0);
            Console.WriteLine(name + "  " + address);
           // repo.CreateOrder();
            //TODO NewOrderEvent – an event notifying subscribers whenever the above method is called using a NewOrderEventArgs with the order as a property
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

/*        public void Notify(NotifyEvent ne)
        {
            
        }*/
    }
}
