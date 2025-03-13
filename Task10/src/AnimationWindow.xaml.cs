using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace src
{
    public partial class AnimationWindow : Window
    {
        private DispatcherTimer _timer;
        private bool _isRunning;

        public AnimationWindow()
        {
            InitializeComponent();

            FanControl.Images = new List<BitmapImage>
            {
                new BitmapImage(new Uri("pack://application:,,,/src;component/Properties/1.png")),
                new BitmapImage(new Uri("pack://application:,,,/src;component/Properties/2.png")),
                new BitmapImage(new Uri("pack://application:,,,/src;component/Properties/3.png"))
            };

            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(IntervalTextBox.Text, out int interval))
            {
                _timer.Interval = TimeSpan.FromMilliseconds(interval);
            }
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning)
            {
                _timer.Stop();
                StartStopButton.Content = "Старт";
            }
            else
            {
                _timer.Start();
                StartStopButton.Content = "Стоп";
            }
            _isRunning = !_isRunning;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            FanControl.Value = (FanControl.Value + 1) % FanControl.Images.Count;
        }
    }
}