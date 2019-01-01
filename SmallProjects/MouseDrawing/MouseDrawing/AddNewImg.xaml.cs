using MouseDrawing.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logika interakcji dla klasy AddNewImg.xaml
    /// </summary>
    public partial class AddNewImg : Window
    {

        BitmapSource ImageToAdd;

        public AddNewImg()
        {
            InitializeComponent();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                ImageToAdd = Clipboard.GetImage();
                img.Source = ImageToAdd;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new DB().SendImg(new Imgs(ImageToAdd, tags.Text));
        }

        private BitmapImage ToBitmapImage(BitmapSource x)
        {
            BitmapSource bitmapSource = x;

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            MemoryStream memoryStream = new MemoryStream();
            BitmapImage bImg = new BitmapImage();

            encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
            encoder.Save(memoryStream);

            memoryStream.Position = 0;
            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(memoryStream.ToArray());
            bImg.EndInit();

            memoryStream.Close();

            return bImg;
        }
    }
}
