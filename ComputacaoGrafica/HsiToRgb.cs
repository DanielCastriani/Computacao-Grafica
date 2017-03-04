using System;

namespace ComputacaoGrafica
{
    class HsiToRgb
    {
        private static void xyz(double h, double s, double i, out double x, out double y, out double z)
        {
            double j = s * Math.Cos(h);
            double k = Math.Cos(Math.PI / 3 - h);
            double div = 0;
            if (k != 0)
                div = j / k;

            x = i * (1 - s);
            y = i * (1 + div);
            z = 3 * i - (x + y);
        }

        public static void convert(int H, int S, int I ,out int r, out int g, out int b)
        {
            
            if (H > 360) H = 360;
            if (H < 0) H = 0;
            if (S > 100) S = 100;
            if (S < 0) S = 0;
            if (I > 255) I = 255;
            if (I < 0) I = 0;
            
            r = g = b = 0;

            double h = H * Math.PI/180;
            double s = (double)S / 100;
            double i = (double)I / 255;
            double x = 0, y = 0 , z = 0;
            if (h < 2 * Math.PI / 3)
            {
                xyz(h, s, i, out x, out y, out z);
                b = (int)Math.Round(x * 255);
                r = (int)Math.Round(y * 255);
                g = (int)Math.Round(z * 255);
            }
            else
            {
                if (2 * Math.PI / 3 <= h && h < 4 * Math.PI / 3)
                {
                    h = h - 2 * Math.PI / 3;
                    xyz(h, s, i, out x, out y, out z);
                    r = (int)Math.Round(x * 255);
                    g = (int)Math.Round(y *  255);
                    b = (int)Math.Round(z * 255);
                }
                else
                {
                    if (4 * Math.PI / 3 <= h && h <= 2 * Math.PI)
                    {
                        h = h - 4 * Math.PI / 3;
                        xyz(h, s, i, out x, out y, out z);
                        g = (int)Math.Round(x * 255);
                        b = (int)Math.Round(y * 255);
                        r = (int)Math.Round(z * 255);
                    }
                    else
                    {
                        throw new System.ArgumentException("Erro: H > 2 * pi  h = " + h);
                    }
                }
                if (r > 255) r = 255;
                if (r < 0) r = 0;
                if (g > 255) g = 255;
                if (g < 0) g = 0;
                if (b > 255) b = 255;
                if (b < 0) b = 0;
            }
        }
    }
}
