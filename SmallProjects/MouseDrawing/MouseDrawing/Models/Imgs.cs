using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MouseDrawing.Models
{
    public class Imgs
    {
        public string base64Image;
        public string tags;
        public BitmapImage img;

        public Imgs(string base64img, string tag)
        {
            this.base64Image = base64img;
            this.tags = tag;

            img = Base64StringToBitmap(base64Image);
        }

        public Imgs(BitmapSource imggg, string tages)
        {
            this.base64Image = BitmapToBase64String(imggg);
            this.tags = tages;

            img = Base64StringToBitmap(base64Image);
        }

        private BitmapImage Base64StringToBitmap(string base64String)
        {
            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);
            memoryStream.Position = 0;

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bitmapImage;
        }

        private string BitmapToBase64String(BitmapSource imag)
        {
            var encoder = new PngBitmapEncoder();
            var frame = BitmapFrame.Create(imag);
            encoder.Frames.Add(frame);
            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
