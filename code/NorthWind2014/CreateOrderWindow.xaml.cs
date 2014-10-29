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
using NorthWind.Model;

namespace NorthWind
{
    /// <summary>
    /// Interaction logic for CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        public event EventHandler<CreateOrderArgs> ButtonCreateClickedEvent;

        public class CreateOrderArgs
        {
            public OrderDto OrderInput { get; set; }

            public CreateOrderArgs(OrderDto orderInput)
            {
                OrderInput = orderInput;
            }
        }

        public CreateOrderWindow()
        {
            InitializeComponent();
        }

        private OrderDto GetOrderInput()
        {
            return new OrderDto()
            {
                ShipName = InputShipName.Text,
                ShipAddress = InputShipAddress.Text,
                ShipCity = InputShipCity.Text,
                ShipRegion = InputShipRegion.Text,
                ShipPostalCode = InputShipPostalCode.Text,
                ShipCountry = InputShipCountry.Text
            };
        }

        private void ButtonCreateClicked(object sender, RoutedEventArgs e)
        {
            ButtonCreateClickedEvent.Invoke(this, new CreateOrderArgs(GetOrderInput()));
            this.Close();
        }

        private void ButtonCancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
