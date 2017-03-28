using System;
using System.Drawing;

namespace _2D
{
    class Aresta : IComparable<Aresta>
    {
        private Point p1, p2;
        private double Ymax;
        private double Xmin; // x do y min
        private int Ymin;
        private double IncX;
        public Aresta(Point p1, Point p2)
        {
            int Xmax;
            Ymin = Math.Min(p1.Y, p2.Y);
            this.p1 = p1;
            this.p2 = p2;
            if (p1.Y < p2.Y)
            {
                Xmin = p1.X;
                Xmax = p2.X;
            }
            else
            {
                Xmin = p2.X;
                Xmax = p1.X;
            }
            Ymax = Math.Max(p1.Y, p2.Y);


            if (Ymax - Math.Min(p1.Y, p2.Y) != 0)
                IncX = (Xmax - Xmin )/ (Ymax - Ymin);
            else
                IncX = 0;
        }
        public int getYmin()
        {
            return Ymin;
        }
        public Point getP1() { return p1; }
        public Point getP2() { return p2; }
        public double getYmax() { return Ymax; }
        public double getXmin() { return Xmin; }
        public double getIncX() { return IncX; }

        public void setXmin(double x) { Xmin = x; }

        public int CompareTo(Aresta other)
        {
            if (Xmin <= other.getXmin())
                return 0;
            else
                return 1;
        }
    }
}
