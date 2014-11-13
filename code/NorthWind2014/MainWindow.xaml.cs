using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
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
            _repo = new MemoryRep();
            _reporter = new Reporter(new MemoryRep());
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

        private void ButtonReportTopOrdersTotalPriceClicked(object sender, RoutedEventArgs e)
        {
            InputNumberWindow inputNumberWindow = new InputNumberWindow();
            inputNumberWindow.OkClickedEvent += DisplayReportTopOrdersTotalPrice;
            inputNumberWindow.SetText("Top orders by total price", "Number of orders to display");
            inputNumberWindow.Show();
        }

        private void DisplayReportTopOrdersTotalPrice(object sender, InputNumberWindow.NumberInputArgs e)
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
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.SetReportData("Top orders by total price", "TopOrdersByTotalPriceTemplate", new[] { new { Data = report.Data } });
            reportWindow.Show();
        }

        private void DisplayReportTopProductsBySale(object sender, InputNumberWindow.NumberInputArgs e)
        {
            int displayCount = e.Input;
            Report<IList<ProductsBySaleDto>, ReportError> report = _reporter.TopProductsBySale(displayCount);
            // Display error message and return, if error occured.
            if (report.Error != null)
            {
                var mes = report.Error.Message;
                MessageBox.Show(this, "An error generating the report happened. See error message:\n" + mes,
                    "Report error");
                return;
            }

            // If no error occured, display report.
            ReportWindow reportWindow = new ReportWindow();
            var list = new List<dynamic>();
            foreach (var dtos in report.Data)
            {
                list.Add(new {ProductName = dtos.ProductName, ProductId = dtos.ProductId, Data = dtos.UnitsSoldByMonth});
            }
            reportWindow.SetReportData("Top products by sale", "TopProductsBySaleTemplate", list);
            reportWindow.Show();
        }

        private void DisplayReportEmployeeSale(object sender, InputNumberWindow.NumberInputArgs e)
        {
            int employeeId = e.Input;
            Report<EmployeeSaleDto, ReportError> report = _reporter.EmployeeSale(employeeId);
            // Display error message and return, if error occured.
            if (report.Error != null)
            {
                var mes = report.Error.Message;
                MessageBox.Show(this, "An error generating the report happened. See error message:\n" + mes,
                    "Report error");
                return;
            }
            ReportWindow reportWindow = new ReportWindow();
            reportWindow.SetReportData("Employee sales", "EmployeeSaleTemplate", new [] { report.Data });
            reportWindow.Show();
        }

        private void ButtonReportTopProductsBySaleClicked(object sender, RoutedEventArgs e)
        {
            InputNumberWindow inputNumberWindow = new InputNumberWindow();
            inputNumberWindow.OkClickedEvent += DisplayReportTopProductsBySale;
            inputNumberWindow.SetText("Top products by sale", "Number of products to display");
            inputNumberWindow.Show();
        }

        private void ButtonReportEmployeeSaleClicked(object sender, RoutedEventArgs e)
        {
            InputNumberWindow inputNumberWindow = new InputNumberWindow();
            inputNumberWindow.OkClickedEvent += DisplayReportEmployeeSale;
            inputNumberWindow.SetText("Employee sales", "Id of the employee");
            inputNumberWindow.Show();
        }
    }
}
