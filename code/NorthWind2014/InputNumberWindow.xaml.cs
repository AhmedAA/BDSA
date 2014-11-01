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

namespace NorthWind
{
    /// <summary>
    /// Interaction logic for InputNumberWindow.xaml
    /// </summary>
    public partial class InputNumberWindow : Window
    {
        public event EventHandler<NumberInputArgs> OkClickedEvent;
        public class NumberInputArgs
        {
            public int Input { get; set; }
        }

        public void SetText(string title, string numberBoxLabel)
        {
            LabelInputNumberTitle.Content = title;
            LabelInputNumberBoxLabel.Content = numberBoxLabel;
        }

        public InputNumberWindow()
        {
            InitializeComponent();
        }

        private void OkClicked(object sender, RoutedEventArgs e)
        {
            OkClickedEvent.Invoke(this, new NumberInputArgs() { Input = Int32.Parse(InputNumberBox.Text) });
            this.Close();
        }

        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
