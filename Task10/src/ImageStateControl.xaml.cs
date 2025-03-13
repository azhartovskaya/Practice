using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace src
{
    public partial class ImageStateControl : UserControl
    {
        public static readonly DependencyProperty ImagesProperty =
            DependencyProperty.Register("Images", typeof(List<BitmapImage>), typeof(ImageStateControl), new PropertyMetadata(new List<BitmapImage>(), OnImagesChanged));

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(ImageStateControl), new PropertyMetadata(0, OnValueChanged));

        public List<BitmapImage> Images
        {
            get => (List<BitmapImage>)GetValue(ImagesProperty);
            set => SetValue(ImagesProperty, value);
        }

        public int Value
        {
            get => (int)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public ImageStateControl()
        {
            InitializeComponent();
        }

        private static void OnImagesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ImageStateControl;
            control.UpdateImage();
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ImageStateControl;
            control.UpdateImage();
        }

        private void UpdateImage()
        {
            if (Images == null || Images.Count == 0)
            {
                StateImage.Source = null;
                return;
            }

            if (Value >= 0 && Value < Images.Count)
            {
                StateImage.Source = Images[Value];
            }
            else
            {
                StateImage.Source = new BitmapImage(new Uri("pack://application:,,,/src;component/Properties/1.png"));
            }
        }
    }
}