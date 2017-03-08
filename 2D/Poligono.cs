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
            matAc = new int[3,3];
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

        public void desenha(Bitmap img,Color c)
        {
            if(pAtual.Count < 3)
                throw new System.ArgumentException("Quantidade de pontos Menor que 3");

            for (int i = 0; i < pAtual.Count - 1; i++)
                Reta.pontoMedio(pAtual[i].X, pAtual[i].Y, pAtual[i + 1].X, pAtual[i + 1].Y ,img,c);
            Reta.pontoMedio(pAtual[pAtual.Count-1].X, pAtual[pAtual.Count - 1].Y, pAtual[0].X, pAtual[0].Y, img, c);

        }
    }
}
