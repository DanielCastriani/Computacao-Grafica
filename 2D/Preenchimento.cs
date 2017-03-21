﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace _2D
{
    class Preenchimento
    {
        public static unsafe void floodFill(int x, int y, Bitmap img, Color c)
        {
            int H = img.Height;
            int W = img.Width;
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int padding = bmpData.Stride - (W * 3);
            byte* ptrIni = (byte*)bmpData.Scan0.ToPointer();

            Point ptClick = new Point(x, y);
            Stack<Point> pts = new Stack<Point>();
            Color fundo = Util.getPixel(ptrIni, x, y, W, padding);

            pts.Push(ptClick);
            Point pt;
            while (pts.Count > 0)
            {
                pt = pts.Pop();

                if (Util.getPixel(ptrIni, pt.X, pt.Y, W, padding).Equals(fundo))
                    Util.setPixel(ptrIni, pt.X, pt.Y, W, padding, c);

                if (Util.getPixel(ptrIni, pt.X - 1, pt.Y, W, padding).Equals(fundo))
                    pts.Push(new Point(pt.X - 1 , pt.Y));
                if (Util.getPixel(ptrIni, pt.X + 1, pt.Y, W, padding).Equals(fundo))
                    pts.Push(new Point(pt.X + 1, pt.Y));
                if (Util.getPixel(ptrIni, pt.X, pt.Y - 1, W, padding).Equals(fundo))
                    pts.Push(new Point(pt.X, pt.Y - 1));
                if (Util.getPixel(ptrIni, pt.X, pt.Y + 1, W, padding).Equals(fundo))
                    pts.Push(new Point(pt.X, pt.Y + 1));
            }
            img.UnlockBits(bmpData);
        }
    }
}