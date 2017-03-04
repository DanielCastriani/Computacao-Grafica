using System.Drawing;
using System.Drawing.Imaging;

namespace _2D
{
    class Util
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

        public unsafe static byte* getPos(byte* pIni, int TX, int TY, int W, int padding)
        {
            byte* pos = pIni;
            pos += (W * 3 + padding) * TY + (TX * 3);
            return pos;
        }
        public unsafe static void setPixel(byte* pIni, int TX, int TY, int W, int padding,Color c)
        {
            byte* ptr = pIni;
            ptr += (W * 3 + padding) * TY + (TX * 3);
            *(ptr++) = c.B;
            *(ptr++) = c.G;
            *(ptr++) = c.R;
        }

        public unsafe static BitmapData LockBits(Bitmap image)
        {
            BitmapData bmpData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            return bmpData;
        }
    }
}
