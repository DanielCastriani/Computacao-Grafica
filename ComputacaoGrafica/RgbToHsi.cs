using System;

namespace ComputacaoGrafica
{
    class RgbToHsi
    {
        private static double normalizacao(int valor,int R, int G, int B)
        {
            if ((R + G + B) != 0)
                return (double)valor / (R + G + B);
            return 0;
        }

        public static void convert(int r, int g, int b, out int h, out int s, out int i)
        {
            h = (int)matiz(r, g, b);
            s = (int)saturacao(r, g, b);
            i = (int)intensidade(r, g, b);
        }

        public static double matiz(int R, int G, int B)
        {
            double h = 0;
            double r = normalizacao(R, R, G, B);
            double g = normalizacao(G, R, G, B);
            double b = normalizacao(B, R, G, B);

            double x = 0.5 * ((r - g) + (r - b));
            double y = Math.Pow((Math.Pow(r - g, 2)) + (r - b) * (g - b), 0.5);
            if (y == 0)
                return 0;
            if (b <= g)
                h = Math.Acos(x / y);
            else
                h = 2 * Math.PI - Math.Acos(x / y);

            return Math.Round(h * 180 / Math.PI);
        }

        public static double saturacao(int R, int G, int B)
        {
            double r = normalizacao(R, R, G, B);
            double g = normalizacao(G, R, G, B);
            double b = normalizacao(B, R, G, B);

            double min = Math.Min(Math.Min(r, g),b);
            double s = (double)(1 - 3 * min);
            return Math.Round(s * 100);
        }

        public static double intensidade(int R, int G, int B)
        {
            double i = (double)(R + G + B) / (3 * 255);
            return Math.Round(i * 255);
        }
    }
}
