﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace _2D
{
    class Poligono
    {
        private List<Point> pOriginal;
        private List<Point> pAtual;
        private double[,] matAc;
        private Color borda, fundo;

        private void initMatAc()
        {
            matAc = new double[3, 3];
            for (int i = 0; i < 3; i++)
                matAc[i, i] = 1;
        }

        public Poligono(Color borda)
        {
            pOriginal = new List<Point>();
            pAtual = new List<Point>();
            initMatAc();
            this.borda = borda;
            fundo = Color.White;
        }

        public Poligono(List<Point> p, Color borda)
        {
            pOriginal = p;
            pAtual = new List<Point>(p);
            initMatAc();
            this.borda = borda;
            fundo = Color.White;
        }
        public Color getFundo()
        {
            return fundo;
        }
        public void setFundo(Color c)
        {
            fundo = c;
        }
        public Color getBorda()
        {
            return borda;
        }
        public void reset()
        {
            initMatAc();
            pAtual = new List<Point>(pOriginal);
        }
        public double getDistanciaClick(int x, int y) {
            Point c = getCentroAtual();
            return Math.Sqrt(Math.Pow(c.X - x , 2) + Math.Pow(c.Y - y, 2));
        }
        public void origem()
        {
            pAtual = new List<Point>(pOriginal);
        }

        public Point getPosicaoInicial()
        {
            return pOriginal[0];
        }

        public Point getCentroOriginal()
        {
            int x = 0;
            int y = 0;

            foreach (Point pts in pOriginal)
            {
                x += pts.X;
                y += pts.Y;    
            }

            Point p = new Point();
            p.X = x / pOriginal.Count;
            p.Y = y / pOriginal.Count;

            return p;
        }

        public Point getCentroAtual()
        {
            int x = 0;
            int y = 0;

            foreach (Point pts in pAtual)
            {
                x += pts.X;
                y += pts.Y;
            }

            Point p = new Point();
            p.X = x / pAtual.Count;
            p.Y = y / pAtual.Count;

            return p;
        }

        public void add(Point p)
        {
            pOriginal.Add(p);
            pAtual.Add(p);
        }

        public void desenha(Bitmap img)
        {
            if (pAtual.Count > 1)
            {
                for (int i = 0; i < pAtual.Count - 1; i++)
                    Reta.pontoMedio(pAtual[i].X, pAtual[i].Y, pAtual[i + 1].X, pAtual[i + 1].Y, img, borda);
                Reta.pontoMedio(pAtual[pAtual.Count - 1].X, pAtual[pAtual.Count - 1].Y, pAtual[0].X, pAtual[0].Y, img, borda);
                Point c = getCentroAtual();
                //Preenchimento.scanLine(c.X,c.Y,img,fundo,this);
            }
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

        public List<Point> getPontos()
        {
            return pAtual;
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

        public void rotacao(double a)
        {
            a = a * Math.PI / 180;
            double[,] R = new double[3, 3];
            R[0, 0] = Math.Cos(a);
            R[0, 1] = -Math.Sin(a);
            R[1, 0] = Math.Sin(a);
            R[1, 1] = Math.Cos(a);
            R[2, 2] = 1;
            matAc = multiplicar(R, matAc);
            novosPontos();
        }

        public void escala(double x, double y)
        {
            double[,] E = new double[3, 3];
            E[0, 0] = x;
            E[1, 1] = y;
            E[2, 2] = 1;
            matAc = multiplicar(E, matAc);
            novosPontos();
        }

        public void espelhamento(bool vertical)
        {

            double[,] E = new double[3, 3];
            if(vertical)
            {
                E[0, 0] = -1;
                E[1, 1] = 1;
                E[2, 2] = 1;
            }
            else
            {
                E[0, 0] = 1;
                E[1, 1] = -1;
                E[2, 2] = 1;
            }
            matAc = multiplicar(E, matAc);
            novosPontos();
        }

        public void cisalhamento(double x, double y)
        {
            double[,] C = new double[3, 3];
            C[0, 0] = 1;
            C[1, 1] = 1;
            C[2, 2] = 1;

            C[0, 1] = y;
            C[1, 0] = x;
            
            matAc = multiplicar(C, matAc);
            novosPontos();
        }
        
    }
}
