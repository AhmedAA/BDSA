using System;
using System.Windows;

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
