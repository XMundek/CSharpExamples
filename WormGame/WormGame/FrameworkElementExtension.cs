using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WormGame
{
    public static class FrameworkElementExtension
    {
        public static void SetBinding(this FrameworkElement shape, DependencyProperty prop,
            object source, string path, BindingMode mode = BindingMode.Default)
        {
            var binding = new Binding(path)
            {
                Source = source,
                Mode = mode,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            shape.SetBinding(prop, binding);
        }
        public static void SetBinding(this FrameworkElement shape, GameObject source,
            BindingMode mode = BindingMode.Default)
        {
            shape.SetBinding(FrameworkElement.WidthProperty, source, nameof(source.Width), mode);
            shape.SetBinding(FrameworkElement.HeightProperty, source, nameof(source.Height), mode);
            shape.SetBinding(Canvas.TopProperty, source, nameof(source.Y), mode);
            shape.SetBinding(Canvas.LeftProperty, source, nameof(source.X), mode);
        }
    }
}
