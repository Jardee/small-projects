using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MessageBox = System.Windows.Forms.MessageBox;

namespace MouseDrawing
{
    /// <summary>
    /// Logika interakcji dla klasy OpacityWindow.xaml
    /// </summary>
    
    public partial class OpacityWindow : Window
    {
        BitmapSource glbl;
        BitmapSource Target;
        int pixelskip;
        int delay;
        bool focused = true;
        MainWindow refer;
        double scale = 1.0;

        public OpacityWindow(BitmapSource bd, int dl, int skp, MainWindow tmp)
        {
            InitializeComponent();
            glbl = bd;
            pixelskip = skp;
            delay = dl;
            refer = tmp;
            System.Windows.Forms.Timer tmt = new System.Windows.Forms.Timer();
            tmt.Interval = 50;
            tmt.Tick += Tmt_Tick;
            tmt.Start();
            Target = glbl;
        }

        private void Tmt_Tick(object sender, EventArgs e)
        {
            MousePoint dd;
            GetCursorPos(out dd);
            this.Top = dd.Y - 20;
            this.Left = dd.X - 20;

            //if (!this.IsFocused) this.Close();
        }

        #region Keyboard
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        private const int VK_SNAPSHOT = 0x58; //This is the x key.
        #endregion

        #region Mouse
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

        #endregion

        public static bool GetPixelColor(BitmapSource bitmap, int x, int y)
        {
            //nie działa z przezroczystoscia TO-DO

            var bytesPerPixel = (bitmap.Format.BitsPerPixel + 7) / 8;
            var bytes = new byte[bytesPerPixel];
            var rect = new Int32Rect(x, y, 1, 1);

            bitmap.CopyPixels(rect, bytes, bytesPerPixel, 0);

            return !(bytes[2] > 200 && bytes[1] > 200 && bytes[0] > 200);
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.D)
            {
               
                Thread t = new Thread(new ThreadStart(Draw));
                t.Start();
                refer.focused = true;
                refer.reff = t;
                this.Close();
            }
            if (e.Key == Key.Escape)
            {
               
                this.Close();
            }
        }
        private void Draw()
        {
            this.Dispatcher.Invoke(() =>
            {
                BitmapSource sd = Target;
                int xx = (int)Left;
                int yy = (int)Top;
                bool first = true;
                bool previous = false;

                for (int x = 0; x < sd.PixelWidth; x += pixelskip)
                {
                    for (int y = 0; y < sd.PixelHeight; y += pixelskip)
                    {
                        short keyState = GetAsyncKeyState(VK_SNAPSHOT);

                        bool prntScrnIsPressed = ((keyState >> 15) & 0x0001) == 0x0001;

                        if (prntScrnIsPressed)
                        {
                            Release();
                            return;
                        }

                        first = GetPixelColor(sd, x, y);

                        if (first && !previous)
                        {
                            SetCursorPos(xx + x, yy + y);
                            Grab();

                        }
                        else if (!first && previous) Release();

                        if (first && previous)
                        {
                            SetCursorPos(xx + x, yy + y);
                            System.Threading.Thread.Sleep(delay);
                        }

                        previous = first;
                    }

                }
            });
            
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            if (focused)
            {
                Window window = (Window)sender;
                window.Topmost = true;
            }
            
        }


    }
}
