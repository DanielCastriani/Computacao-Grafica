using System.Drawing;
using System.Drawing.Imaging;
using System;
using System.Collections.Generic;

namespace _2D
{
    class Preenchimento
    {
        public unsafe static void floodFill(int x, int y, Bitmap img, Color c)
        {
           Stack<byte> pontos = new Stack<byte>();
            int H = img.Height;
            int W = img.Width;
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpData.Stride - (W * 3);
            byte* ptrIni = (byte*)bmpData.Scan0.ToPointer();


            // Util.getPos(ptrIni, x, y, W, padding);
             pontos.Push(*Util.getPos(ptrIni, x, y, W, padding));
            pontos.Push(*ptrIni);

            byte* aux;

            while(pontos.Count > 0)
            {
               
             
                Util.setPixel(ptrIni, x,y, W,padding, c);

            }
          

            img.UnlockBits(bmpData);
        }


    }
}
