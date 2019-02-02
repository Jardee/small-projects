using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseDrawingV2
{
    public struct Imgs
    {
        public BitArray Image;
        public string Tags;
    }

    public static class Util
    {
        public static BitArray Image256x256ToBitArray(Image imageToConvert)
        {
            Bitmap BitmapFromImage = new Bitmap(imageToConvert);
            BitArray processedBitArray = new BitArray(BitmapFromImage.Width * BitmapFromImage.Height);
            int BitArrayIterator = 0;

            for (int x = 0; x < BitmapFromImage.Width; x++)
            {
                for (int y = 0; y < BitmapFromImage.Height; y++)
                {
                    Color pixel = BitmapFromImage.GetPixel(x, y);

                    if (pixel.R > 250 && pixel.G > 250 && pixel.B > 250) processedBitArray[BitArrayIterator] = true; //white
                    else if ((pixel.R < 6 && pixel.G < 6 && pixel.B < 6)) processedBitArray[BitArrayIterator] = false; //black

                    BitArrayIterator++;
                }
            }

            return processedBitArray;
        }

        public static Bitmap BitArrayTo256x256Image(BitArray BitArrayToProcess)
        {
            Bitmap BitmapFromBitArray = new Bitmap(256, 256);
            Color black = Color.FromArgb(0, 0, 0);
            Color White = Color.FromArgb(255, 255, 255);
            int iter = 0;

            for (int x = 0; x < BitmapFromBitArray.Width; x++)
            {
                for (int y = 0; y < BitmapFromBitArray.Height; y++)
                {
                    BitmapFromBitArray.SetPixel(x, y, BitArrayToProcess[iter] ? Color.FromArgb(255, 255, 255) : Color.FromArgb(0, 0, 0));
                    iter++;
                }
            }

            return BitmapFromBitArray;
        }

        //extension method to BitArray
        public static byte[] ToByteArray(this BitArray bits)
        {

            const int BYTE = 8;
            int length = (bits.Count / BYTE) + ((bits.Count % BYTE == 0) ? 0 : 1);
            var bytes = new byte[length];

            for (int i = 0; i < bits.Length; i++)
            {

                int bitIndex = i % BYTE;
                int byteIndex = i / BYTE;

                int mask = (bits[i] ? 1 : 0) << bitIndex;
                bytes[byteIndex] |= (byte)mask;

            }

            return bytes;

        }

        //extension method to byte array
        public static BitArray ToBitArray(this byte[] bytes) => new BitArray(bytes);

        public static Image resizeImage(Image imgToResize, Size size) => new Bitmap(imgToResize, size);

        #region Keyboard
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public const int VK_SNAPSHOT = 0x58; //This is the x key.
        #endregion

        #region Mouse
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out MousePoint lpMousePoint);

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


        public static void DoMouseClick()
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
    }
}
