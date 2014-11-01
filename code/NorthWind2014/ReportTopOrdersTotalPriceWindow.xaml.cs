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
using System.Windows.Shapes;
using NorthWind.Reporting.DTOs;

namespace NorthWind
{
    /// <summary>
    /// Interaction logic for ReportTopOrdersTotalPriceWindow.xaml
    /// </summary>
    public partial class ReportTopOrdersTotalPriceWindow : Window
    {
        public ReportTopOrdersTotalPriceWindow()
        {
            InitializeComponent();
        }

        public void SetReportData(IList<OrdersByTotalPriceDto> data)
        {
            ReportDataGrid.ItemsSource = data;
        }

        private void CloseClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
