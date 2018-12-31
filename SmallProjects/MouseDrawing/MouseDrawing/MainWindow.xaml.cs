using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Clipboard = System.Windows.Clipboard;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.Forms.MessageBox;
using Timer = System.Windows.Forms.Timer;
using Path = System.IO.Path;

namespace MouseDrawing
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        BitmapSource sd;
        ImageSource grap;
        OpacityWindow handle;
        public bool focused = true;
        public Thread reff;
        Dictionary<BitmapImage, string> AllImages = new Dictionary<BitmapImage, string>();
        Dictionary<BitmapImage, string> ActualToView = new Dictionary<BitmapImage, string>();
        public MainWindow()
        {
            //MessageBox.Show(Screen.PrimaryScreen.Bounds.Width.ToString() + this.Width.ToString());
            
            InitializeComponent();
            this.Left = Screen.PrimaryScreen.Bounds.Width - this.Width;
            this.Top = 0;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 40;

            getimages("C:/imgs");

            Timer tm1 = new Timer();
            tm1.Interval = 50;
            tm1.Tick += Tm1_Tick;
            tm1.Start();
        }

        private void Tm1_Tick(object sender, EventArgs e)
        {
            if (focused)
                this.Topmost = true;
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
                        if (".jpg|.jpeg".Contains(item.Extension.ToLower()))
                        {
                            AllImages.Add(addimage(item.FullName), Path.GetFileNameWithoutExtension(item.FullName));
                            //MessageBox.Show(Path.GetFileNameWithoutExtension(item.FullName));
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            ActualToView = new Dictionary<BitmapImage, string>(AllImages);
            updateImages(ActualToView);
        }

        private BitmapImage addimage(string pth)
        {
          

            BitmapImage src = new BitmapImage();

            src.BeginInit();

            src.UriSource = new Uri(pth, UriKind.Absolute);
            
            src.EndInit();

            return src;
        }

        private void updateImages(Dictionary<BitmapImage, string> x)
        {
            childs.Children.Clear();

            foreach (var item in x)
            {
                Image img = new Image();

                img.Source = item.Key;

                img.Stretch = Stretch.Uniform;
                img.Height = Properties.Settings.Default.PictureSize;

                img.MouseDown += Img_MouseDown;
                childs.Children.Add(img);
            }
            
        }

        private void Img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image ctrl = (Image)sender;
            grap = ctrl.Source;
            sd = (BitmapSource)grap;

            int delay = Properties.Settings.Default.Delay;
            int pixelskip = Properties.Settings.Default.pixelSkip;

            OpacityWindow preview = new OpacityWindow(sd, delay, pixelskip, this);
            handle = preview;
            preview.Width = sd.PixelWidth;
            preview.Height = sd.PixelHeight;
            focused = false;

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

        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
        
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (handle != null) handle.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            childs.Width = this.Width;
            xddd.Width = this.Width;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Settings tmp = new Settings();
            tmp.Show();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //update view with only with tags
            //jeżeli puste to prawdopodobnie bedzie ze wczyta wszystko chciaz słabo jak bedzie duzo elementów
            //TO-DO && TagTXT.Text.Length > 3
            if (!String.IsNullOrEmpty(TagTXT.Text) )
            {
                updateImages(AllImages.Where(x => x.Value.Contains(TagTXT.Text)).ToDictionary(t => t.Key, t => t.Value));
            }
            else
            {
                updateImages(AllImages);
            }
        }
    }
}
