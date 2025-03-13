using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace src
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ImageControl.Images = new List<BitmapImage>
            {
                new BitmapImage(new Uri("pack://application:,,,/src;component/Properties/1.png")),
                new BitmapImage(new Uri("pack://application:,,,/src;component/Properties/2.png")),
                new BitmapImage(new Uri("pack://application:,,,/src;component/Properties/3.png"))
            };
        }

        private void NextImageButton_Click(object sender, RoutedEventArgs e)
        {
            ImageControl.Value = (ImageControl.Value + 1) % ImageControl.Images.Count;
        }
    }
}