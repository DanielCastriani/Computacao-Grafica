using System;
using System.Collections.Generic;
using System.Drawing;

namespace _2D
{
    class Poligono
    {
        private List<Point> pOriginal;
        private List<Point> pAtual;

        private int[,] matAc;

        public Poligono()
        {
            pOriginal = new List<Point>();
            pAtual = new List<Point>();
            matAc = new int[2, 2];
            for (int i = 0; i < 2; i++)
                matAc[i, i] = 1;
        }

        public Poligono(List<Point> p)
        {
            pOriginal = p;
            pAtual = new List<Point>(p);
            matAc = new int[2, 2];
            for (int i = 0; i < 2; i++)
                matAc[i, i] = 1;
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

        private void soma(int[,] mat)
        {            
           for()
        }

        private int [,] multiplicar(int[,] mat,int[,] mat2)
        {
            int[,] nMat = new int[2, 2];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        nMat[i, j] += mat[i, k] * mat2[k, j];    
                    }
                }
            }
            return nMat;
        }

        public void trasform(int tx, int ty, int angulo, int ex, int ey)
        {
            rotacao(angulo);
            traslacao(tx, ty);
            //escala(ex, ey);


            Point p;

            for (int i = 0; i < pAtual.Count; i++)
            {
                p = pOriginal[i];
                p.X = p.X * matAc[0, 0] + p.Y * matAc[0, 1];
                p.Y = p.X * matAc[1, 0] + p.Y * matAc[1, 1];
                pAtual[i] = p;
            }
        }


        public void traslacao(int x, int y)
        {
            
        }

        public void rotacao(int rad)
        {

        }

        public void escala(int ex, int ey)
        {
            int[,] matEscala = new int[2, 2];
            matEscala[0, 0] = ex;
            matEscala[0, 1] = 0;
            matEscala[1, 0] = 0;
            matEscala[1, 1] = ey;
            matAc = multiplicar(matEscala, matAc);
        }
    }
}
