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
            matAc = new int[3, 3];
            for (int i = 0; i < 3; i++)
                matAc[i, i] = 1;
        }

        public Poligono(List<Point> p)
        {
            pOriginal = p;
            pAtual = new List<Point>(p);
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
            for (int i = 0; i < mat.Length; i++)
                for (int j = 0; j < mat.Length; j++)
                        matAc[i, j] += mat[i, j];
        }

        private void multiplicar(int[,] mat)
        {
            int[,] nMat = new int[2, 2];
            int ac;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat.Length; j++)
                {
                    ac = 0;
                    for (int k = 0; k < mat.Length; k++)
                    {
                           ac =     
                    }
                }
            }
        }

        public void trasform(int tx, int ty, int angulo, int ex, int ey)
        {
            rotacao(angulo);
            traslacao(tx, ty);
            escala(ex, ey);


            Point p;

            for (int i = 0; i < pAtual.Count; i++)
            {
                p = pOriginal[i];
                p.X += matAc[0, 0];
                p.Y += matAc[0, 1];
                pAtual[i] = p;
            }
        }


        public void traslacao(int x, int y)
        {
            int [,]mat = new int[2, 1];
            mat[0, 0] = x;
            mat[1, 0] = y;
            soma(mat);
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
            
        }
    }
}
