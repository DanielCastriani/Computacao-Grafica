using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ComputacaoGrafica
{
    class DMA
    {
        public unsafe static void preencher(Bitmap img, int r, int g, int b)
        {
            int W = img.Width;
            int H = img.Height;
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte* ptr = (byte*)bmpData.Scan0.ToPointer();
            int padding = bmpData.Stride - (W * 3);

            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    *(ptr++) = (byte)b;
                    *(ptr++) = (byte)g;
                    *(ptr++) = (byte)r;
                }
                ptr += padding;
            }

            img.UnlockBits(bmpData);
        }

        public unsafe static byte *getPos(byte* pIni, int TX, int TY,int W, int padding)
        {
            byte* pos = pIni;
            pos += (W * 3 + padding) * TY + (TX * 3);
            return pos;
        }

        public unsafe static void bmpToHsi(Bitmap src, int [,,]dest) 
        {
            int W = src.Width;
            int H = src.Height;
            BitmapData bmpData = src.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte* ptr = (byte*)bmpData.Scan0.ToPointer();
            int padding = bmpData.Stride - (W * 3);

            int b, g, r,h,s,i;
            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    b = *(ptr++);
                    g = *(ptr++);
                    r = *(ptr++);
                    RgbToHsi.convert(r, g, b,out dest[x,y,0], out dest[x, y, 1], out dest[x, y, 2]);

                }
                ptr += padding;
            }
            src.UnlockBits(bmpData);
        }

        public unsafe static void hsiToBmp(int [,,]src,Bitmap dst) 
        {
            int W = dst.Width;
            int H = dst.Height;
            BitmapData bmpData = dst.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte* ptr = (byte*)bmpData.Scan0.ToPointer();
            int padding = bmpData.Stride - (W * 3);

            int r, g, b;

            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    HsiToRgb.convert(src[x, y, 0], src[x, y, 1], src[x, y, 2], out r, out g, out b);
                    *(ptr++) = (byte)b;
                    *(ptr++) = (byte)g;
                    *(ptr++) = (byte)r;
                }
                ptr += padding;
            }

            dst.UnlockBits(bmpData);
        }

        public static void Luminancia(int[,,] src,int H , int W)
        {
            int r, g, b,gs;
            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    HsiToRgb.convert(src[x,y,0], src[x, y, 1], src[x, y, 2], out r, out g , out b);
                    gs = (int)(r * 0.2990 + g * 0.5870 + b * 0.1140);
                    RgbToHsi.convert(gs, gs, gs, out src[x, y, 0], out src[x, y, 1],out src[x, y, 2]);
                }
            }
        }

        public static void brilho(int[,,] mat,int [,,]matOriginal, int H, int W, int valor)
        {
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                    mat[x, y, 2] = mat[x, y, 2] + matOriginal[x, y, 2] / 100 * valor;
        }

        public  static void matiz(int [,,]mat,int H , int W, int valor)
        {
            for (int y = 0; y < H; y++)
                for (int x = 0; x < W; x++)
                    mat[x, y, 0] = (mat[x, y, 0] + valor) % 361;
             
        }

        public unsafe static string getInfo(Bitmap img, int X, int Y)
        {

            int W = img.Width;
            int H = img.Height;
            BitmapData bmpDataImg = img.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int padding = bmpDataImg.Stride - (W * 3);
            byte* pos = (byte*)bmpDataImg.Scan0.ToPointer();
            pos = getPos(pos, X, Y, W, padding);
            int b = *(pos++);
            int g = *(pos++);
            int r = *(pos++);
            img.UnlockBits(bmpDataImg);

            //RGB
            string info = "RGB[";
            info += r.ToString("D" + 3) + " , ";
            info += g.ToString("D" + 3) + " , ";
            info += b.ToString("D" + 3) + "] ";

            //CMY
            info += "CMY[";
            info += (255 - r).ToString("D" + 3) + " , ";
            info += (255 - g).ToString("D" + 3) + " , ";
            info += (255 - b).ToString("D" + 3) + "] ";

            //HSI
            info += "HSI[";
            info += (int)RgbToHsi.matiz(r, g, b) + " , ";
            info += (int)RgbToHsi.saturacao(r, g, b) + " , ";
            info += (int)RgbToHsi.intensidade(r, g, b) + "] ";

            return info;
        }

        public unsafe static void miniaturaHSI(Bitmap src, Bitmap h, Bitmap s, Bitmap i)
        {
            int W = src.Width;
            int H = src.Height;
            BitmapData bmpDataSrc = src.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            BitmapData bmpDataH = h.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataS = s.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataI = i.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpDataSrc.Stride - (W * 3);
            int r, g, b;
            byte* psrc = (byte*)bmpDataSrc.Scan0.ToPointer();
            byte* ph = (byte*)bmpDataH.Scan0.ToPointer();
            byte* ps = (byte*)bmpDataS.Scan0.ToPointer();
            byte* pi = (byte*)bmpDataI.Scan0.ToPointer();
            double v;

            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    b = *(psrc++);
                    g = *(psrc++);
                    r = *(psrc++);
                    v = RgbToHsi.matiz(r, g, b);
                    *(ph++) = (byte)v;
                    *(ph++) = (byte)v;
                    *(ph++) = (byte)v;

                    v = RgbToHsi.saturacao(r, g, b);
                    *(ps++) = (byte)v;
                    *(ps++) = (byte)v;
                    *(ps++) = (byte)v;

                    v = RgbToHsi.intensidade(r, g, b);
                    *(pi++) = (byte)v;
                    *(pi++) = (byte)v;
                    *(pi++) = (byte)v;
                }
                psrc += padding;
                ph += padding;
                ps += padding;
                pi += padding;
            }
            src.UnlockBits(bmpDataSrc);
            h.UnlockBits(bmpDataH);
            s.UnlockBits(bmpDataS);
            i.UnlockBits(bmpDataI);
        }

        public unsafe static void miniaturaRGBGrayScale(Bitmap src, Bitmap R, Bitmap G, Bitmap B)
        {
            int W = src.Width;
            int H = src.Height;
            BitmapData bmpDataSrc = src.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            BitmapData bmpDataR = R.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataG = G.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataB = B.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpDataSrc.Stride - (W * 3);
            int r, g, b;
            byte* psrc = (byte*)bmpDataSrc.Scan0.ToPointer();
            byte* pr = (byte*)bmpDataR.Scan0.ToPointer();
            byte* pg = (byte*)bmpDataG.Scan0.ToPointer();
            byte* pb = (byte*)bmpDataB.Scan0.ToPointer();

            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    b = *(psrc++);
                    g = *(psrc++);
                    r = *(psrc++);

                    *(pr++) = (byte)r;
                    *(pr++) = (byte)r;
                    *(pr++) = (byte)r;

                    *(pg++) = (byte)g;
                    *(pg++) = (byte)g;
                    *(pg++) = (byte)g;

                    *(pb++) = (byte)b;
                    *(pb++) = (byte)b;
                    *(pb++) = (byte)b;
                }
                psrc += padding;
                pr += padding;
                pg += padding;
                pb += padding;
            }
            src.UnlockBits(bmpDataSrc);
            R.UnlockBits(bmpDataR);
            G.UnlockBits(bmpDataG);
            B.UnlockBits(bmpDataB);
        }

        public unsafe static void miniaturaRGB(Bitmap src, Bitmap R, Bitmap G, Bitmap B)
        {
            int W = src.Width;
            int H = src.Height;
            BitmapData bmpDataSrc = src.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            BitmapData bmpDataR = R.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataG = G.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataB = B.LockBits(new Rectangle(0, 0, W, H), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int padding = bmpDataSrc.Stride - (W * 3);
            int r, g, b;
            byte* psrc = (byte*)bmpDataSrc.Scan0.ToPointer();
            byte* pr = (byte*)bmpDataR.Scan0.ToPointer();
            byte* pg = (byte*)bmpDataG.Scan0.ToPointer();
            byte* pb = (byte*)bmpDataB.Scan0.ToPointer();

            for (int y = 0; y < H; y++)
            {
                for (int x = 0; x < W; x++)
                {
                    b = *(psrc++);
                    g = *(psrc++);
                    r = *(psrc++);

                    *(pr++) = 0;
                    *(pr++) = 0;
                    *(pr++) = (byte)r;

                    *(pg++) = 0;
                    *(pg++) = (byte)g;
                    *(pg++) = 0;

                    *(pb++) = (byte)b;
                    *(pb++) = 0;
                    *(pb++) = 0;
                }
                psrc += padding;
                pr += padding;
                pg += padding;
                pb += padding;
            }
            src.UnlockBits(bmpDataSrc);
            R.UnlockBits(bmpDataR);
            G.UnlockBits(bmpDataG);
            B.UnlockBits(bmpDataB);
        }

    }
}