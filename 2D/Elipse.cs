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
            if (x1 > x2)
            {
                int aux = x1;
                x1 = x2;
                x2 = aux;
            }
            if (y1 > y2)
            {
                int aux = y1;
                y1 = y2;
                y2 = aux;
            }
            
            int raio = (int)Math.Round(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)));

            int x = 0;
            int y = raio;
            double d = y1 * y1 - x1 * x1 * y1 + x1 * x1 / 4;
            pintaPontoCimetria(ptrIni, x, y, x1, y1, W, padding, c);
            while (x1 * x1 * (y - 0.5) > y1 * y1 * (x + 1))
            {
                while (x1 * x1 * (y - 0.5) > y1 * y1 * (x + 1))
                {
                    if (d < 0)
                    {
                        d = d + y1 * y1 * (2 * x + 3);
                        x++;
                    }
                    else
                    {
                        d = d + y1 * y1 * (2 * x + 3) + x1 * x1 * (-2 * y + 2);
                        x++;
                        y--;
                    }
                    pintaPontoCimetria(ptrIni, x, y, x1, y1, W, padding, c);
                }
            }
            d = y1 * y1 * (x + 0.5) * (x + 0.5) + x1 * x1 * (y - 1) * (y - 1) - x1 * x1 * y1 * y1;

            while (y > 0)
            {
                if (d < 0)
                {
                    d = d + y1 * y1 * (2 * x + 2) + x1 * x1 * (-2 * y + 3);
                    x++;
                    y--;
                }
                else
                {
                    d = d + x1 * x1 * (-2 * y + 3);
                    y--;
                }
                pintaPontoCimetria(ptrIni, x, y, x1, y1, W, padding, c);
            }

            img.UnlockBits(bmpData);
        }

        private unsafe static void pintaPontoCimetria(byte* ptrIni, int X, int Y, int xini, int yini, int W, int padding, Color c)
        {
            Util.setPixel(ptrIni, xini + X, yini + Y, W, padding, c);
            Util.setPixel(ptrIni, xini + X, yini - Y, W, padding, c);
            Util.setPixel(ptrIni, xini - X, yini + Y, W, padding, c);
            Util.setPixel(ptrIni, xini - X, yini - Y, W, padding, c);
        }
    }
}
