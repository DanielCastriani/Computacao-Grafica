using System;
using System.Collections.Generic;
using System.Drawing;

namespace _2D
{
    class Poligono
    {
        private List<Point> pOriginal;
        private List<Point> pAtual;

        private double[,] matAc;

        private void initMatAc()
        {
            matAc = new double[3, 3];
            for (int i = 0; i < 3; i++)
                matAc[i, i] = 1;
        }

        public Poligono()
        {
            pOriginal = new List<Point>();
            pAtual = new List<Point>();
            initMatAc();
        }

        public Poligono(List<Point> p)
        {
            pOriginal = p;
            pAtual = new List<Point>(p);
            initMatAc();
        }

        public Point getPosicaoInicial()
        {
            return pOriginal[0];
        }

        public void add(Point p)
        {
            pOriginal.Add(p);
            pAtual.Add(p);
        }

        public void desenha(Bitmap img, Color c)
        {
            if (pAtual.Count < 3)
                throw new System.ArgumentException("Quantidade de pontos Menor que 3");

            for (int i = 0; i < pAtual.Count - 1; i++)
                Reta.pontoMedio(pAtual[i].X, pAtual[i].Y, pAtual[i + 1].X, pAtual[i + 1].Y, img, c);
            Reta.pontoMedio(pAtual[pAtual.Count - 1].X, pAtual[pAtual.Count - 1].Y, pAtual[0].X, pAtual[0].Y, img, c);

        }
        
        public void novosPontos()
        {
            Point p;

            for (int i = 0; i < pAtual.Count; i++)
            {
                p = pOriginal[i];
                int x = (int)Math.Round(p.X * matAc[0, 0] + p.Y * matAc[0, 1] + matAc[0, 2] * 1);
                int y = (int)Math.Round(p.X * matAc[1, 0] + p.Y * matAc[1, 1] + matAc[1, 2] * 1);
                p.X = x;
                p.Y = y;
                pAtual[i] = p;
            }
        }

        public void traslacao(double x, double y)
        {
            double[,]T = new double[3, 3];
            T[0, 0] = 1;
            T[1, 1] = 1;
            T[2, 2] = 1;
            T[0, 2] = x;
            T[1, 2] = y;
            matAc = multiplicar(T, matAc);
            novosPontos();
        }

        private double[,] multiplicar(double[,] mat, double[,] mat2)
        {
            double [,]matR = new double[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        matR[i, j] += mat[i, k] * mat2[k, j];
            return matR;
        } 

        public void rotacao(int a)
        {
            double[,] R = new double[3, 3];
            R[0, 0] = Math.Cos(a);
            R[0, 1] = -Math.Sin(a);
            R[1, 0] = Math.Sin(a);
            R[1, 1] = Math.Cos(a);
            R[2, 2] = 1;
            matAc = multiplicar(R, matAc);
            novosPontos();
        }

        public void escala(int x, int y)
        {
            double[,] E = new double[3, 3];
            E[0, 0] = x;
            E[1, 1] = y;
            E[2, 2] = 1;
            matAc = multiplicar(E, matAc);
            novosPontos();
        }

        /* 
         * centro : media dos pontos atuais
         * transformação -cx -cy
         * transformação x y
         * transformação cx cy         
         */
    }
}
