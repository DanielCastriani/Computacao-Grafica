using System.Drawing;
using System.Drawing.Imaging;
using System;
namespace _2D
{
    class Reta
    {
        public unsafe static void equacaoGeral(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {
            int H = img.Height;
            int W = img.Width;
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpData.Stride - (W * 3);
            byte* ptrIni = (byte*)bmpData.Scan0.ToPointer();

            double dy = y2 - y1;
            double dx = x2 - x1;
            double m = dy / dx;
            double y, x;
            int aux;

            dy = Math.Abs(dy);
            dx = Math.Abs(dx);

            int xi = x1;
            int yi = y1;
            if (x2 > x1)// 1, 2, 7, 8
            {
                if(y2 <= y1)// 7 e 8
                {
                    aux = y1;
                    y1 = y2;
                    y2 = aux;
                }
            }
            else //3 4 5 6
            {
                if (y2 > y1)// 3 , 4
                {
                    aux = x1;
                    x1 = x2;
                    x2 = aux;
                }
                else// 5, 6
                {
                    aux = x1;
                    x1 = x2;
                    x2 = aux;
                    aux = y1;
                    y1 = y2;
                    y2 = aux;
                }
            }

            if (dx > dy)
            {
                for (x = x1; x <= x2; x++)
                {
                    y = yi + m * (x - xi);
                    Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                }
            }
            else
            {
                for (y = y1; y <= y2; y++)
                {
                    x = xi + (y - yi) / m;
                    Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                }
            }

            img.UnlockBits(bmpData);
        }


        public unsafe static void DDA(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {
            int H = img.Height;
            int W = img.Width;
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpData.Stride - (W * 3);
            byte* ptrIni = (byte*)bmpData.Scan0.ToPointer();
            //----------------------------------------------------------------------------------------------------------------
            int length = Math.Abs(x2 - x1);
            if (Math.Abs(y2 - y1) > length)
                length = Math.Abs(y2 - y1);

            double xInc = (double)(x2 - x1) / length;
            double yInc = (double)(y2 - y1) / length;

            double x = x1;
            double y = y1;

            if (x < x2)
            {
                while (x < x2)
                {
                    Util.setPixel(ptrIni, (int)Math.Round(x), (int)Math.Round(y), W, padding, c);
                    x += xInc;
                    y += yInc;
                }
            }
            else
            {
                if (x > x2)
                {
                    while (x > x2)
                    {
                        Util.setPixel(ptrIni, (int)Math.Round(x), (int)Math.Round(y), W, padding, c);
                        x += xInc;
                        y += yInc;
                    }
                }
                else
                {
                    if (y > y2)
                    {
                        while (y > y2)
                        {
                            Util.setPixel(ptrIni, (int)Math.Round(x), (int)Math.Round(y), W, padding, c);
                            x += xInc;
                            y += yInc;
                        }
                    }
                    else
                    {
                        while (y < y2)
                        {
                            Util.setPixel(ptrIni, (int)Math.Round(x), (int)Math.Round(y), W, padding, c);
                            x += xInc;
                            y += yInc;
                        }
                    }
                }
            }

            img.UnlockBits(bmpData);
        }

        public unsafe static void pontoMedio(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {
                        
            if (x2 < x1)
            {
                pontoMedio(x2,y2,x1,y1,img,c);
                return;
            }

            if (y2 < y1)
            {
                y1 *= -1;
                y2 *= -1;
            }

            int dx = x2 - x1;
            int dy = y2 - y1;
            
            int declive = 1;
            int incE = 2 * dy;
            int incNE = 2 * dy - 2 * dx;
            int d = 2 * dy - dx;
            
            int H = img.Height;
            int W = img.Width;
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpData.Stride - (W * 3);
            byte* ptrIni = (byte*)bmpData.Scan0.ToPointer();
            int x, y;

            if (Math.Abs(dy) < Math.Abs(dx))
            {
                if (dy < 0)
                    declive = -1;

                y = y1;
                for (x = x1; x < x2; x++)
                {
                    Util.setPixel(ptrIni, x, y, W, padding, c);
                    if (d <= 0)
                        d += incE;
                    else
                    {
                        d += incNE;
                        y += declive;
                    }
                }
            }
            else
            {
                if (dx < 0)
                    declive = -1;

                x = x1;
                for (y = y1; y < y2; y++)
                {
                    Util.setPixel(ptrIni, x, y, W, padding, c);
                    if (d <= 0)
                        d += incE;
                    else
                    {
                        d += incNE;
                        x += declive;
                    }
                }
            }
            img.UnlockBits(bmpData);
        }
        public unsafe static void equacaoGeral2(int x1, int y1, int x2, int y2, Bitmap img, Color c)
        {
            int H = img.Height;
            int W = img.Width;
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpData.Stride - (W * 3);
            byte* ptrIni = (byte*)bmpData.Scan0.ToPointer();

            double dy = y2 - y1;
            double dx = x2 - x1;
            double m = dy / dx;
            double y, x;

            dy = Math.Abs(dy);
            dx = Math.Abs(dx);

            if (x2 > x1)// 1, 2, 7, 8
            {
                if (y2 > y1)// 1 e 2
                {
                    if (dx > dy)//1
                    {
                        for (x = x1; x <= x2; x++)
                        {
                            y = y1 + m * (x - x1);
                            Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                        }
                    }
                    else//2
                    {
                        for (y = y1; y <= y2; y++)
                        {
                            x = x1 + (y - y1) / m;
                            Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                        }
                    }
                }
                else// 7 e 8
                {
                    if (dx > dy)//8
                    {
                        for (x = x1; x <= x2; x++)
                        {
                            y = y1 + m * (x - x1);
                            Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                        }
                    }
                    else//7
                    {
                        for (y = y2; y <= y1; y++)
                        {
                            x = x1 + (y - y1) / m;
                            Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                        }
                    }
                }
            }
            else //3 4 5 6
            {
                if (y2 > y1)// 3 , 4
                {
                    if (dx > dy)//4
                    {
                        for (x = x2; x <= x1; x++)
                        {
                            y = y1 + m * (x - x1);
                            Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                        }
                    }
                    else//3
                    {
                        for (y = y1; y <= y2; y++)
                        {
                            x = x1 + (y - y1) / m;
                            Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                        }
                    }
                }
                else// 5, 6
                {
                    if (dx > dy)//5
                    {
                        for (x = x2; x <= x1; x++)
                        {
                            y = y1 + m * (x - x1);
                            Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                        }
                    }
                    else//6
                    {
                        for (y = y2; y <= y1; y++)
                        {
                            x = x1 + (y - y1) / m;
                            Util.setPixel(ptrIni, (int)x, (int)Math.Round(y), W, padding, c);
                        }
                    }
                }
            }

            img.UnlockBits(bmpData);
        }
    }
}