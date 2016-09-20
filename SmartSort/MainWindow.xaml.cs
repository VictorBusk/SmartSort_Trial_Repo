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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mouse_Click(object sender, MouseButtonEventArgs e)
        {
            switch (((FrameworkElement)sender).Name.ToString())
            {
                case "image_minimize":
                    UICommands.minimize(this);
                    break;
                case "image_exit":
                    UICommands.exit();
                    break;
            }
        }

        private void button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button[] btn;
            btn = new Button[] { button };
            UICommands.setButtonColor(btn, "#808000	");
        }

        private void button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button[] btn;
            btn = new Button[] { button };
            UICommands.setButtonColor(btn, "#FF2E4053");
        }


        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                try
                {
                    this.DragMove();
                }
                catch (Exception) { }
        }

    }
}
