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
            double raio = Math.Round(Math.Sqrt(Math.Pow((x1-x2), 2) + Math.Pow((y1 - y2), 2)));
            raio = Math.Abs(raio);
            int x = 0, y;
            int k = x1;
           // bool rotaciona = false;
            pintarEquacaoGeral(raio, x1, y1, x2, y2, ptrIni,  k, W, padding, c,x, false);
           // pintarEquacaoGeral(raio, x1, y1, x2, y2, ptrIni,  (int)(k+raio/2) , W, padding, c,(int)(x+raio/2), false);
           // pintarEquacaoGeral(raio, x1, y1, x2, y2, ptrIni, (int)(k+raio), W, padding, c, (int)(x+raio), true);
           // pintarEquacaoGeral(raio, x1, y1, x2, y2, ptrIni, (int)(k + raio), W, padding, c, (int)(x + raio), true);
            //   pintarEquacaoGeral(raio, x1, y1, x2, y2, ptrIni, k, W, padding, c, x, rotaciona);



            img.UnlockBits(bmpData);
        }

        private static unsafe void pintarEquacaoGeral(double raio, int x1, int y1, int x2, int y2, byte* ptrIni,  int k, int W, int padding, Color c, int x, bool rotaciona)
        {

            int y;
            for (int i = 0; i < raio/2; i++)
            {
                
                y = ((x2 - x1) / 2) + Math.Abs(y2 - (Math.Abs(x1 - x2))) + (int)Math.Abs(Math.Sqrt(Math.Pow(raio, 2) - Math.Pow(x, 2)));

                k++;
                x++;
                Util.setPixel(ptrIni, k, (int)y, W, padding, c);

            }
        }

        public unsafe static void trigonometrica(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {

        }
        public unsafe static void pontoMedio(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {

        }
    }
}
