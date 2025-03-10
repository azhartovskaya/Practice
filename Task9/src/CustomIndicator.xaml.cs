using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace src
{
    public partial class CustomIndicator : UserControl
    {
        public CustomIndicator()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IsOnProperty =
            DependencyProperty.Register("IsOn", typeof(bool), typeof(CustomIndicator),
                new PropertyMetadata(false, OnIsOnChanged));

        public bool IsOn
        {
            get { return (bool)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        private static void OnIsOnChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var indicator = d as CustomIndicator;
            if (indicator != null)
            {
                indicator.UpdateIndicator();
            }
        }

        private void UpdateIndicator()
        {
            IndicatorEllipse.Fill = IsOn ? Brushes.Green : Brushes.Red;
        }
    }
}