using System.Windows;

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

        //save
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(delaytxt.Text, out int result)) Properties.Settings.Default.Delay = result;

            if (int.TryParse(pixskiptxt.Text, out int result2)) Properties.Settings.Default.pixelSkip = result2;

            if (int.TryParse(Icon_Sizetxt.Text, out int result3)) Properties.Settings.Default.PictureSize = result3;

            Properties.Settings.Default.Experimental = chck.IsChecked ?? false;

            Properties.Settings.Default.Save();
        }

        //add new img
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddNewImg tmp = new AddNewImg();
            tmp.Show();
        }
    }
}
