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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Task_17
{
    /// <summary>
    /// Логика взаимодействия для colorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public static readonly DependencyProperty ColorProperty;
        public static readonly DependencyProperty RedProperty;
        public static readonly DependencyProperty GreenProperty;
        public static readonly DependencyProperty BlueProperty;
        public static RoutedEvent ColorChangedEvent;

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public byte Red
        {
            get => (byte)GetValue(RedProperty);
            set => SetValue(RedProperty, value);
        }

        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value);
        }

        public byte Blue
        {
            get => (byte)GetValue(BlueProperty);
            set => SetValue(BlueProperty, value);
        }

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        static ColorPicker()
        {
            ColorProperty =
                DependencyProperty.Register(
                    nameof(Color),
                    typeof(Color),
                    typeof(ColorPicker),
                    new FrameworkPropertyMetadata(
                        Colors.Black,
                        new PropertyChangedCallback(OnColorChanged)));

            RedProperty =
                DependencyProperty.Register(
                    nameof(Red),
                    typeof(byte),
                    typeof(ColorPicker),
                    new FrameworkPropertyMetadata(
                        new PropertyChangedCallback(OnColorRGBChanged)));

            GreenProperty =
                DependencyProperty.Register(
                    nameof(Green),
                    typeof(byte),
                    typeof(ColorPicker),
                    new FrameworkPropertyMetadata(
                        new PropertyChangedCallback(OnColorRGBChanged)));

            BlueProperty =
                DependencyProperty.Register(
                    nameof(Blue),
                    typeof(byte),
                    typeof(ColorPicker),
                    new FrameworkPropertyMetadata(
                        new PropertyChangedCallback(OnColorRGBChanged)));

            ColorChangedEvent =
                EventManager.RegisterRoutedEvent("ColorChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedPropertyChangedEventHandler<Color>),
                typeof(ColorPicker));
        }

        private static void OnColorRGBChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ColorPicker colorPicker = sender as ColorPicker;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }

        private static void OnColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Color color = (Color)e.NewValue;
            ColorPicker colorPicker = sender as ColorPicker;
            colorPicker.Red = color.R;
            colorPicker.Green = color.G;
            colorPicker.Blue = color.B;
        }

        public ColorPicker()
        {
            InitializeComponent();
        }
    }
}
