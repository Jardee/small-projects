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
using System.Windows.Shapes;

namespace MouseDrawing
{
    /// <summary>
    /// Logika interakcji dla klasy Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();

            delaytxt.Text = Properties.Settings.Default.Delay.ToString();

            pixskiptxt.Text = Properties.Settings.Default.pixelSkip.ToString();

            Icon_Sizetxt.Text = Properties.Settings.Default.PictureSize.ToString();

            chck.IsChecked = Properties.Settings.Default.Experimental;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(delaytxt.Text, out int result)) Properties.Settings.Default.Delay = result;

            if (int.TryParse(pixskiptxt.Text, out int result2)) Properties.Settings.Default.pixelSkip = result2;

            if (int.TryParse(Icon_Sizetxt.Text, out int result3)) Properties.Settings.Default.PictureSize = result3;

            Properties.Settings.Default.Experimental = chck.IsChecked ?? false;

            Properties.Settings.Default.Save();
        }
    }
}
