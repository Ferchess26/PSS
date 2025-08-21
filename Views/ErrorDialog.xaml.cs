using System.Windows;

namespace PV_app.Views
{
    public partial class ErrorDialog : Window
    {
        public ErrorDialog(string message)
        {
            InitializeComponent();
            MessageTextBlock.Text = message;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
