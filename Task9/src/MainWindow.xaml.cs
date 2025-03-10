using System.Windows;

namespace src
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Indicator.IsOn = !Indicator.IsOn;
        }
    }
}