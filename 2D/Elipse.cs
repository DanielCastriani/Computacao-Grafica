using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace _2D
{
    class Elipse
    {
        public unsafe static void pontoMedio(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {
            int H = img.Height;
            int W = img.Width;
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpData.Stride - (W * 3);
            byte* ptrIni = (byte*)bmpData.Scan0.ToPointer();
            //-------------------------------------------------------------------------------------------------------
           
            int dy = Math.Abs(y2 - y1);
            int dx = Math.Abs(x2 - x1);
            double a = dy / 2;
            double b = dx / 2;
            double d1, d2;
            double x = 0;
            double y = b;

            d1 = b * b - a * a * b + a * a / 4.0;

            pintaPontoSimetria(ptrIni, (int)x, (int)y, x1, y1, W, padding, c);

            while (a * a * (y - 0.5) > b * b * (x + 1))
            {
                if (d1 < 0)
                {
                    d1 = d1 + b * b * (2 * x + 3);
                    x++;
                }
                else
                {
                    d1 = d1 + b * b * (2 * x + 3) + a * a * (-2 * y + 2);
                    x++;
                    y--;
                }
                pintaPontoSimetria(ptrIni, (int)x, (int)y, x1, y1, W, padding, c);
            }

            d2 = b * b * (x + 0.5) * (x + 0.5) + a * a * (y - 1) * (y - 1) - a * a * b * b;

            while (y > 0)
            {
                if (d2 < 0)
                {
                    d2 = d2 + b * b * (2 * x + 2) + a * a * (-2 * y + 3);
                    x++;
                    y--;
                }
                else
                {
                    d2 = d2 + a * a * (-2 * y + 3);
                    y--;
                }
                pintaPontoSimetria(ptrIni,(int)x,(int)y,x1,y1,W,padding,c);
            }

            img.UnlockBits(bmpData);
        }

        private unsafe static void pintaPontoSimetria(byte* ptrIni, int X, int Y, int xini, int yini, int W, int padding, Color c)
        {
            Util.setPixel(ptrIni, xini + X, yini + Y, W, padding, c);
            Util.setPixel(ptrIni, xini + X, yini - Y, W, padding, c);
            Util.setPixel(ptrIni, xini - X, yini + Y, W, padding, c);
            Util.setPixel(ptrIni, xini - X, yini - Y, W, padding, c);
        }
    }
}
