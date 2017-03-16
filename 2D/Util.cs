using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace _2D
{
    class Util
    {
        public unsafe static void preencher(Bitmap img, Color c)
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
                    *(ptr++) = (byte)c.B;
                    *(ptr++) = (byte)c.G;
                    *(ptr++) = (byte)c.R;
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
            if (TX < 0 || TY < 0 || TX >= Principal.getWTela() || TY >= Principal.getHTela())
              return;
            
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

        public static DataSet criaTablePontos()
        {
            DataSet ds = new DataSet("Dataset Pontos");
            DataTable dt = new DataTable("tbPontos");
            ds.Tables.Add(dt);
            DataColumn c = new DataColumn("Ponto", typeof(Point));
            c.AllowDBNull = false;
            dt.Columns.Add(c);
            return ds;
        }
        public static DataSet criaTablePoligonos()
        {
            DataSet ds = new DataSet("Dataset Poligonos");
            DataTable dt = new DataTable("tbPoligonos");
            ds.Tables.Add(dt);
            DataColumn c = new DataColumn("Poligono", typeof(Poligono));
            c.AllowDBNull = false;
            dt.Columns.Add(c);
            c = new DataColumn("PosicaoInicial", typeof(Point));
            c.AllowDBNull = false;
            dt.Columns.Add(c);
            return ds;
        }
    }
}