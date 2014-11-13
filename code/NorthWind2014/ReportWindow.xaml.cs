using System.Collections;
using System.Windows;

namespace NorthWind
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
        }

        public void SetReportData(string reportTitle, string reportTemplate, IEnumerable data)
        {
            LabelReportTitle.Content = reportTitle;
            ItemsControl.ItemTemplate = (DataTemplate)Resources[reportTemplate];
            ItemsControl.ItemsSource = data;
        }

        private void CloseClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
