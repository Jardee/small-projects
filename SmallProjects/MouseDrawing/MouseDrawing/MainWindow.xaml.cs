using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Clipboard = System.Windows.Clipboard;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MouseDrawing
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapSource sd;
        ImageSource grap;
        public MainWindow()
        {
            //MessageBox.Show(Screen.PrimaryScreen.Bounds.Width.ToString() + this.Width.ToString());
            
            InitializeComponent();
            delaytxt.Text = "20";
            pixskiptxt.Text = "2";
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
            this.Top = 0;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 40;
            getimages(@"C:\imgs");
        }

        private void getimages(string folderpath)
        {
            if (folderpath == "") return;
            //MessageBox.Show("1");
            try
            {
                DirectoryInfo dir = new DirectoryInfo(folderpath);

                if (dir.Exists)
                {
                    foreach (var item in dir.GetFiles())
                    {
                        if (".jpg|.jpeg|.gif|.png".Contains(item.Extension.ToLower()))
                        {
                            addimage(item.FullName);
                            //MessageBox.Show("No witam");
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

        }

        private void addimage(string pth)
        {
            Image img = new Image();

            BitmapImage src = new BitmapImage();

            src.BeginInit();

            src.UriSource = new Uri(pth, UriKind.Absolute);

            src.EndInit();

            img.Source = src;

            img.Stretch = Stretch.Uniform;
            img.Height = 25;

            img.MouseDown += Img_MouseDown;
            childs.Children.Add(img);

        }

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image ctrl = (Image)sender;
            grap = ctrl.Source;
            sd = (BitmapSource)grap;

            int delay = 20;
            if (int.TryParse(delaytxt.Text, out int ddx)) delay = ddx;
            int pixelskip = 2;
            if (int.TryParse(pixskiptxt.Text, out int ps)) pixelskip = ps;

            OpacityWindow preview = new OpacityWindow(sd, delay, pixelskip);
            preview.Width = sd.PixelWidth;
            preview.Height = sd.PixelHeight;

            ImageBrush myBrush = new ImageBrush();
            myBrush.ImageSource = ctrl.Source;
            preview.Background = myBrush;

            preview.Show();
        }

        private void Image_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            
        }



        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            
        }



        private void Imagebox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            
        }

        private void Lbll_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            delaytxt.IsEnabled = true;
            pixskiptxt.IsEnabled = true;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            //Window window = (Window)sender;
           // window.Topmost = true;
        }
    }
}
