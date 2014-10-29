using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class MainWindow : Window
    {

        internal IRepository _repo;

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += OnClosing;
            _repo = new Repository();
            //_repo.PropertyChanged += PropertyChanged;
            _repo.NewOrderEvent += OnNewOrderEvent;
            this.DataContext = _repo;
            //Task.Run(() => _repo.Orders);
        }

        private void OnNewOrderEvent(object sender, NewOrderEventArgs newOrderEventArgs)
        {
            MessageBox.Show(this, "New order created\nId: " + newOrderEventArgs.OrderId + ", order date: " + newOrderEventArgs.OrderDate, "New order created", MessageBoxButton.OK);
        }

        private void PropertyChanged(Object observable, PropertyChangedEventArgs args)
        {
            if (args.PropertyName.Equals("Orders"))
            {
                MessageBox.Show(this, "New order created!", "New order created", MessageBoxButton.OK);
            }
        }

        private void CreateOrderClicked(object sender, RoutedEventArgs e)
        {
            CreateOrderWindow createOrderWindow = new CreateOrderWindow();
            createOrderWindow.ButtonCreateClickedEvent += CreateOrder;
            createOrderWindow.Show();
        }

        private void CreateOrder(Object sender, CreateOrderWindow.CreateOrderArgs args)
        {
            OrderDto dto = args.OrderInput;
            _repo.CreateOrder(dto.ShipName, dto.ShipAddress, dto.ShipCity, dto.ShipRegion, dto.ShipPostalCode, dto.ShipCountry);
        }

        private void OnClosing(Object sender, CancelEventArgs args)
        {
            // TODO Save database changes, when closing.
        }
    }
}
