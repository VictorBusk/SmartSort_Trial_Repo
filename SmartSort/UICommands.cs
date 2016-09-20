using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SmartSort
{
    static class UICommands
    {
        private static BrushConverter bc = new BrushConverter();
        private static Brush brush;
        public static void exit()
        {
            Environment.Exit(0);
        }
        public static void minimize(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }
        public static void setButtonColor(Button[] elements, String colorCode)
        {
            brush = (Brush)bc.ConvertFrom(colorCode);
            foreach(Button element in elements)
            {
                element.Background = brush;
            }
        }
    }
}
