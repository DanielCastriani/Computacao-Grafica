using System;
using System.Drawing;

namespace _2D
{
    class Aresta : IComparable<Aresta>
    {
        private Point p1, p2;
        private double Ymax, Xmin, IncX;
        public Aresta(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            Ymax = Math.Max(p1.Y, p2.Y);
            Xmin = Math.Min(p1.X, p2.X);
            if ((p2.Y - p1.Y) != 0)
                IncX = (p2.X - p1.X) / (p2.Y - p1.Y);
            else
                IncX = 0;
        }
        public int getYmin()
        {
            return Math.Min(p1.Y, p2.Y);
        }
        public Point getP1() { return p1; }
        public Point getP2() { return p2; }
        public double getYmax() { return Ymax; }
        public double getXmin() { return Xmin; }
        public double getIncX() { return IncX; }

        public void setXmin(double x) { Xmin = x; }

        public int CompareTo(Aresta other)
        {
            if (Xmin < other.getXmin())
                return 0;
            else
                return 1;
        }

    }
}
