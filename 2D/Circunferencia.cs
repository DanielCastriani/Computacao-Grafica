
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
            double raio = Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2))) / 2;
            raio = Math.Abs(raio);
            int x = 0, y;

            for (int i = 0; i < y2 ;i++)
            {
                y = (int)Math.Abs(Math.Sqrt(Math.Pow(raio, 2) - Math.Pow(x, 2)));
                Util.setPixel(ptrIni, x, (int)y, W, padding, c); 
            }

            img.UnlockBits(bmpData);
        }
        public unsafe static void trigonometrica(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {

        }
        public unsafe static void pontoMedio(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {

        }
    }
}
