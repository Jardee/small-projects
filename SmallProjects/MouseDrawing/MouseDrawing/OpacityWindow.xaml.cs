using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MouseDrawing
{
    /// <summary>
    /// Logika interakcji dla klasy OpacityWindow.xaml
    /// </summary>
    public partial class OpacityWindow : Window
    {
        BitmapSource glbl;
        int pixelskip;
        int delay;

        public OpacityWindow(BitmapSource bd, int dl, int skp)
        {
            InitializeComponent();
            glbl = bd;
            pixelskip = skp;
            delay = dl;
            Timer tmt = new Timer();
            tmt.Interval = 50;
            tmt.Tick += Tmt_Tick;
            tmt.Start();
        }

        private void Tmt_Tick(object sender, EventArgs e)
        {
            MousePoint dd;
            GetCursorPos(out dd);
            this.Top = dd.Y;
            this.Left = dd.X;
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

        public static bool GetPixelColor(BitmapSource bitmap, int x, int y)
        {
            Color color;
            var bytesPerPixel = (bitmap.Format.BitsPerPixel + 7) / 8;
            var bytes = new byte[bytesPerPixel];
            var rect = new Int32Rect(x, y, 1, 1);

            bitmap.CopyPixels(rect, bytes, bytesPerPixel, 0);

            if (bytes[2] > 200 && bytes[1] > 200 && bytes[0] > 200) return false;
            else return true;

        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            this.Hide();

            if (e.Key == Key.D)
            {

                BitmapSource sd = glbl;
                MousePoint dd;
                GetCursorPos(out dd);
                bool first = true;
                bool previous = false;

                for (int x = 0; x < sd.PixelWidth; x += pixelskip)
                {
                    for (int y = 0; y < sd.PixelHeight; y += pixelskip)
                    {
                        first = GetPixelColor(sd, x, y);

                        if (first && !previous)
                        { 
                            SetCursorPos(dd.X + x, dd.Y + y);
                            Grab();

                        }
                        else if (!first && previous) Release();

                        if (first && previous)
                        {
                            SetCursorPos(dd.X + x, dd.Y + y);
                            System.Threading.Thread.Sleep(delay);
                        }

                        previous = first;
                    }

                }

                this.Close();
            }
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }
    }
}
