using System;
using System.Windows;

namespace ACVPN.Core
{
    class Extensions
    {
        public static readonly DependencyProperty Icon = 
            DependencyProperty.RegisterAttached("icon", typeof(String), typeof(Extensions),new PropertyMetadata(default(string)));

        public static void SetIcon(UIElement element, string value)
        {
            element.SetValue(Icon, value);
        }
        public static String GetIcon(UIElement element)
        {
            return (String)element.GetValue(Icon);
        }
    }
}
