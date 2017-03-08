using System;
using System.Collections.Generic;
using System.Drawing;

namespace _2D
{
    class Poligono
    {
        private List<Point> pontos;

        public Poligono()
        {
            pontos = new List<Point>();
        }

        public Poligono(List<Point> p)
        {
            pontos = p;
        }

        public void add(Point p)
        {
            pontos.Add(p);
        }

        public void desenha(Bitmap img,Color c)
        {
            if(pontos.Count < 3)
                throw new System.ArgumentException("Quantidade de pontos Menor que 3");

            for (int i = 0; i < pontos.Count - 1; i++)
                Reta.pontoMedio(pontos[i].X, pontos[i].Y, pontos[i + 1].X, pontos[i + 1].Y ,img,c);
            Reta.pontoMedio(pontos[pontos.Count-1].X, pontos[pontos.Count - 1].Y, pontos[0].X, pontos[0].Y, img, c);

        }
    }
}
