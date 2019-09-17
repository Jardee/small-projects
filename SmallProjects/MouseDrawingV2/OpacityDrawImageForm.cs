using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseDrawingV2
{
    public partial class OpacityDrawImageForm : Form
    {
        double backgroundImageScale = 1.0;
        Imgs _ImageToProcess;

        public OpacityDrawImageForm(Imgs ImageToProcess)
        {
            InitializeComponent();
            TopMost = true;
            _ImageToProcess = ImageToProcess;
            MouseWheel += new MouseEventHandler(this.opacityDrawImageFormMouseWheel);
        }

        private void mouseTracktimer_Tick(object sender, EventArgs e)
        {
            Util.GetCursorPos(out Util.MousePoint dd);
            this.Top = dd.Y - 20;
            this.Left = dd.X - 20;
        }

        private void OpacityDrawImageForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                Draw();
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void DrawNonExperimental()
        {
            Bitmap sd = new Bitmap(BackgroundImage);
            int xx = Left;
            int yy = Top;
            bool actual = true;
            bool previous = false;
            var pixelskip = Properties.Settings.Default.PixelSkip;
            var delay = Properties.Settings.Default.Delay;


            for (int x = 0; x < sd.Width; x += pixelskip)
            {
                for (int y = 0; y < sd.Height; y += pixelskip)
                {
                    short keyState = Util.GetAsyncKeyState(Util.VK_SNAPSHOT);

                    bool exit = ((keyState >> 15) & 0x0001) == 0x0001;

                    if (exit)
                    {
                        Util.Release();
                        return;
                    }

                    var color = sd.GetPixel(x, y);
                    actual = color.R < 10 && color.G < 10 && color.B < 10;

                    if (actual && !previous)
                    {
                        Util.SetCursorPos(xx + x, yy + y);
                        Util.Grab();
                    }
                    else if (!actual && previous) Util.Release();

                    if (actual && previous)
                    {
                        Util.SetCursorPos(xx + x, yy + y);
                        System.Threading.Thread.Sleep(delay);
                    }

                    previous = actual;
                }
            }
        }

        private bool DetermineIfBlack(Color color) => color.R < 10 && color.G < 10 && color.B < 10;

        private void DrawExperimental()
        {
            Bitmap sd = new Bitmap(BackgroundImage);
            int xx = Left;
            int yy = Top;
            bool actual = true;
            bool previous = false;
            var pixelskip = Properties.Settings.Default.PixelSkip;
            var delay = Properties.Settings.Default.Delay;

            List<Util.MousePoint> CoordsList = new List<Util.MousePoint>();

            for (int x = 0; x < sd.Width; x += pixelskip)
            {
                for (int y = 0; y < sd.Height; y += pixelskip)
                {
                    actual = DetermineIfBlack(sd.GetPixel(x, y));
                    bool firstNeighbour = DetermineIfBlack(sd.GetPixel(x - 1, y));
                    bool secondNeighbour = DetermineIfBlack(sd.GetPixel(x + 1, y));
                    bool thirdNeighbour = DetermineIfBlack(sd.GetPixel(x, y - 1));
                    bool fourthNeighbour = DetermineIfBlack(sd.GetPixel(x, y + 1));


                    if (actual && (!firstNeighbour || !secondNeighbour || !thirdNeighbour || !fourthNeighbour))
                    {
                        CoordsList.Add(new Util.MousePoint(x, y));
                    }

                }
            }

            Util.Grab();
            foreach (var item in CoordsList)
            {
                Util.SetCursorPos(xx + item.X, yy + item.Y);
                System.Threading.Thread.Sleep(delay);
                short keyState = Util.GetAsyncKeyState(Util.VK_SNAPSHOT);

                bool exit = ((keyState >> 15) & 0x0001) == 0x0001;

                if (exit)
                {
                    Util.Release();
                    return;
                }
            }
            Util.Release();
            

        }

        private void Draw()
        {
            if (!Properties.Settings.Default.Experimental)
            {
                Task.Run(() =>
                {
                    DrawNonExperimental();
                });
            }
            else
            {
                Task.Run(() =>
                {
                    DrawExperimental();
                });
            }
            

        }

        private void opacityDrawImageFormMouseWheel(object sender, MouseEventArgs e)
        {
            backgroundImageScale += e.Delta / 1000.0;
            if (backgroundImageScale < 0.1) backgroundImageScale = 0.1;
            int newSize = (int)(256 * backgroundImageScale);
            BackgroundImage = Util.resizeImage(Util.BitArrayTo256x256Image(_ImageToProcess.Image), new Size(newSize, newSize));

            this.Height = BackgroundImage.Height;
            this.Width = BackgroundImage.Width;
        }
    }
}
