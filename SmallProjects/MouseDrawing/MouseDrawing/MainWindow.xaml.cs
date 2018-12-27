using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
            InitializeComponent();
            delaytxt.Text = "50";
            pixskiptxt.Text = "4";
        }


        private void Image_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                BitmapSource tmp = Clipboard.GetImage();
                this.imagebox.SetCurrentValue(Image.SourceProperty, tmp);
                lbll.Content = tmp.PixelHeight + " x " + tmp.PixelWidth;
                //DoMouseClick();
            }

            if (e.Key == Key.D)
            {
                delaytxt.IsEnabled = false;
                pixskiptxt.IsEnabled = false;
                if (imagebox.Source != null)
                {
                    //SetCursorPos(0, 0);
                    int delay = 50;
                    if (int.TryParse(delaytxt.Text, out int ddx)) delay = ddx;
                    int pixelskip = 4;
                    if (int.TryParse(pixskiptxt.Text, out int ps)) pixelskip = ps;
                    grap = imagebox.Source;
                    sd = (BitmapSource)grap;
                    MousePoint dd;
                    GetCursorPos(out dd);
                    bool first = true;
                    bool previous = false;
                    //long ix = 0;
                    //long max = sd.PixelHeight * sd.PixelWidth;
                    
                    for (int x = 0;x < sd.PixelWidth; x += pixelskip)
                    {
                        for (int y = 0;y < sd.PixelHeight; y += pixelskip)
                        {
                            first = GetPixelColor(sd, x, y);
                            
                            if (first && !previous)
                            {
                                
                                SetCursorPos(dd.X + x, dd.Y + y);
                                Grab();
                                    
                                
                                //ix++;
                                //lbll.Content = ix.ToString() + " / " + max.ToString();
                                //this.UpdateLayout();
                                
                            }
                            else if (!first && previous)
                            {
                                Release();
                                
                            }

                            if (first && previous)
                            {
                                SetCursorPos(dd.X + x, dd.Y + y);
                                Thread.Sleep(delay);
                            }
                            previous = first;
                        }
                        
                    }
                    
                    //MessageBox.Show(GetPixelColor(sd, 10, 10).ToString());
                }
                else
                {
                    MessageBox.Show("wklej grafike!");
                }
                }
        }

        public static bool GetPixelColor(BitmapSource bitmap, int x, int y)
        {
            Color color;
            var bytesPerPixel = (bitmap.Format.BitsPerPixel + 7) / 8;
            var bytes = new byte[bytesPerPixel];
            var rect = new Int32Rect(x, y, 1, 1);

            bitmap.CopyPixels(rect, bytes, bytesPerPixel, 0);

                if (bytes[2] > 200 && bytes[1] > 200 && bytes[0] > 200)
                {
                    //MessageBox.Show("> 240");
                    return false;

                }
                else
                {
                    //MessageBox.Show("<240");
                    return true;
                }

            
            //MessageBox.Show("Nic");
            return false;
        }

        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            
        }

        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void Grab()
        {
            MousePoint x;
            GetCursorPos(out x);
            uint X = (uint)x.X;
            uint Y = (uint)x.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, X, Y, 0, 0);
        }

        public static void Release()
        {
            MousePoint x;
            GetCursorPos(out x);
            uint X = (uint)x.X;
            uint Y = (uint)x.Y;
            mouse_event(MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }


        public void DoMouseClick()
        {
            //Call the imported function with the cursor's current position
            MousePoint x;
            GetCursorPos(out x);
            uint X = (uint)x.X;
            uint Y = (uint)x.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        private void Imagebox_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            
        }

        private void Lbll_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            delaytxt.IsEnabled = true;
            pixskiptxt.IsEnabled = true;
        }
    }
}
