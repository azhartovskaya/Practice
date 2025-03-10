using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace src
{
    public partial class CustomButton : UserControl
    {
        public CustomButton()
        {
            InitializeComponent();
            this.PreviewMouseDown += CustomButton_PreviewMouseDown;
            this.PreviewMouseUp += CustomButton_PreviewMouseUp;
        }

        private void CustomButton_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AnimateButton(true);
        }

        private void CustomButton_PreviewMouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            AnimateButton(false);
        }

        private void AnimateButton(bool isPressed)
        {
            if (ButtonEllipse.Fill.IsFrozen)
            {
                ButtonEllipse.Fill = new SolidColorBrush(Colors.Gray);
            }

            DoubleAnimation scaleAnimation = new DoubleAnimation
            {
                To = isPressed ? 0.9 : 1,
                Duration = TimeSpan.FromMilliseconds(100),
                FillBehavior = FillBehavior.Stop
            };

            ColorAnimation colorAnimation = new ColorAnimation
            {
                To = isPressed ? Colors.DarkGray : Colors.Gray,
                Duration = TimeSpan.FromMilliseconds(100),
                FillBehavior = FillBehavior.Stop
            };

            ButtonEllipse.BeginAnimation(Ellipse.WidthProperty, scaleAnimation);
            ButtonEllipse.BeginAnimation(Ellipse.HeightProperty, scaleAnimation);

            ButtonEllipse.Fill.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
        }
    }
}