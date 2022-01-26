using System.Windows.Media;

namespace WPF_Task_17
{
    internal class RoutedPropertyChangedEventHandler
    {
        private ColorPicker colorPicker;
        private Color color;

        public RoutedPropertyChangedEventHandler(ColorPicker colorPicker, Color color)
        {
            this.colorPicker = colorPicker;
            this.color = color;
        }
    }
}