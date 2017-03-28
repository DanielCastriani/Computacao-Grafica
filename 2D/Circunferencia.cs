using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace _2D
{
    class Circunferencia
    {
        public unsafe static void equacaoGeral(int x1, int y1, int x2, int y2, Bitmap img, Color c)
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
            double raio = Math.Round(Math.Sqrt(Math.Pow((x1-x2), 2) + Math.Pow((y1 - y2), 2)));
            int y;
            for (int x = 0; x < raio; x++)
            {
                y = (int)Math.Sqrt(Math.Pow(raio, 2) - Math.Pow(x, 2));
                pintaPontoCimetria(ptrIni, x, y, x1, y1, W, padding, c);
            }

            img.UnlockBits(bmpData);
        }
               

        public unsafe static void trigonometrica(int x1, int y1, int x2, int y2, Bitmap img, Color c)
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
            double raio = Math.Round(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)));
            int x,y;
            for (double a = 0; a < 90 ; a += 1)
            {
                x = (int)Math.Round(raio * Math.Cos(a * Math.PI / 180));
                y = (int)Math.Round(raio * Math.Sin(a * Math.PI / 180));
                pintaPontoCimetria(ptrIni, x, y, x1, y1, W, padding, c);
            }

            img.UnlockBits(bmpData);
        }
        public unsafe static void pontoMedio(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {
            int H = img.Height;
            int W = img.Width;
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpData.Stride - (W * 3);
            byte* ptrIni = (byte*)bmpData.Scan0.ToPointer();
            //-------------------------------------------------------------------------------------------------------
            if (x1 > x2) {
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
            double d = 1 - raio;
            pintaPontoCimetria(ptrIni, x, y,x1,y1, W, padding, c); 
            while (y > x)
            {
                if (d < 0)
                    d += 2 * x + 3;
                else
                { 
 	                d += 2 * (x - y) +5;
                    y--;
                }
                x++;
                pintaPontoCimetria(ptrIni, x, y, x1, y1, W, padding, c);
            } 

            img.UnlockBits(bmpData);
        }

        private unsafe static void pintaPontoCimetria(byte* ptrIni, int X, int Y,int xini,int yini, int W, int padding, Color c)
        {   
            Util.setPixel(ptrIni, xini + X , yini + Y, W, padding, c);
            Util.setPixel(ptrIni, xini + X, yini - Y, W, padding, c);
            Util.setPixel(ptrIni, xini - X, yini + Y, W, padding, c);
            Util.setPixel(ptrIni, xini - X, yini - Y, W, padding, c);
            Util.setPixel(ptrIni, xini + Y, yini + X, W, padding, c);
            Util.setPixel(ptrIni, xini + Y, yini - X, W, padding, c);
            Util.setPixel(ptrIni, xini - Y, yini + X, W, padding, c);
            Util.setPixel(ptrIni, xini - Y, yini - X, W, padding, c);
        }
    }
}
