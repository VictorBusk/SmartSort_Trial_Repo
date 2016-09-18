using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SmartSort
{
    static class UICommands
    {
        public static void exit()
        {
            Environment.Exit(0);
        }
        public static void minimize(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }
    }
}
