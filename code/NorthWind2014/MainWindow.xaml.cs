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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NorthWind.Model;
using NorthWind.Reporting;
using NorthWind.Reporting.DTOs;
using NorthWind.Reporting.Errors;
using MessageBox = System.Windows.MessageBox;

namespace NorthWind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IRepository _repo;
        private IReporter _reporter;

        public MainWindow()
        {
            InitializeComponent();
            this.Closing += OnClosing;
            _repo = new Repository();
            _reporter = new Reporter();
            _repo.NewOrderEvent += OnNewOrderEvent;
            this.DataContext = _repo;
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

        private void ButtonReportTopOrdersTotalPriceClicked(object sender, RoutedEventArgs e)
        {
            InputNumberWindow inputNumberWindow = new InputNumberWindow();
            inputNumberWindow.OkClickedEvent += DisplayReportTopOrdersTotalPrice;
            inputNumberWindow.SetText("Top orders by total price", "Number of orders to display");
            inputNumberWindow.Show();
        }

        private void DisplayReportTopOrdersTotalPrice(Object sender, InputNumberWindow.NumberInputArgs e)
        {
            int displayCount = e.Input;
            Report<IList<OrdersByTotalPriceDto>, ReportError> report = _reporter.TopOrdersByTotalPrice(displayCount);
            // Display error message and return, if error occured.
            if (report.Error != null)
            {
                var mes = report.Error.Message;
                MessageBox.Show(this, "An error generating the report happened. See error message:\n" + mes,
                    "Report error");
                return;
            }
            
            // If no error occured, display report.
            ReportTopOrdersTotalPriceWindow reportWindow = new ReportTopOrdersTotalPriceWindow();
            reportWindow.SetReportData(report.Data);
            reportWindow.Show();
        }
    }
}
