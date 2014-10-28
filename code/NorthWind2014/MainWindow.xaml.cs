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
            _repo = new Repository();
            _repo.PropertyChanged += PropertyChanged;
            this.DataContext = _repo;
            Task.Run(() => _repo.Orders);
        }

        private void PropertyChanged(Object observable, PropertyChangedEventArgs args)
        {
            if (args.PropertyName.Equals("Orders"))
            {
                
            }
        }

        private void CreateOrderClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
