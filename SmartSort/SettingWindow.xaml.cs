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

namespace SmartSort
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : UserControl
    {
        public SettingWindow()
        {
            InitializeComponent();
        }

        private void image_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage starGlow = new BitmapImage();
            starGlow.UriSource = new Uri(@"C:\Users\Mikkel\Documents\GitHub\SmartSort\SmartSort\Image\stars_yellow.png");
            switch (((FrameworkElement)sender).Name.ToString())
            {
                case "image_start1":
                    image_start1.Source = starGlow;
                    break;
            }
        }


        private void image_MouseLeave(object sender, MouseEventArgs e)
        {

        }
    }
}
