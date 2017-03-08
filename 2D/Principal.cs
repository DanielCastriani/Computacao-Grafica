using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace _2D
{
    public partial class Principal : Form
    {
        private int xi, yi, xf, yf;
        private int op;
        private Color c;
        private bool mouseDown;
        private Bitmap img, temp;

        private List<Poligono> poligonos;

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            c = Color.Black;
            pictureBox.Image = img = new Bitmap(1920,1080);
            Util.preencher((Bitmap)pictureBox.Image, Color.White);
            xi = yi = xf = yf = 0;
            op = -1;
            tsLBpos.Text = "";
            mouseDown = false;
            poligonos = new List<Poligono>();


            /*  Poligono p = new Poligono();
                p.add(new Point(20, 200));
                p.add(new Point(200, 500));
                p.add(new Point(500, 20));
                p.desenha(img, Color.Black);
            */
        }

        private void toolStripButtonCor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog.Color;
            }
        }
        //--Reta
        private void equaçãoDaRetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Equação Geral da Reta";
            op = 1;
            pictureBox.Cursor = Cursors.Hand;
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "DDA";
            op = 2;
            pictureBox.Cursor = Cursors.Hand;
        }

        private void pontoMédioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Ponto Medio(Reta)";
            op = 3;
            pictureBox.Cursor = Cursors.Hand;
        }
        //--Circulo
        private void equaçãoGeralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Equação Geral do Circulo";
            op = 4;
            pictureBox.Cursor = Cursors.Cross;
        }

        private void trigonométricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Trigonométrica";
            op = 5;
            pictureBox.Cursor = Cursors.Cross;
        }

        private void pontoMédioToolStripMenuItemCirculo_Click(object sender, EventArgs e)
        {
            Text = "Ponto Médio(Circulo)";
            op = 6;
            pictureBox.Cursor = Cursors.Cross;
        }
        //--Elipse
        private void pontoMédioToolStripMenuItemElipse_Click(object sender, EventArgs e)
        {
            Text = "Ponto Médio(Elipse)";
            op = 7;
            pictureBox.Cursor = Cursors.Cross;
        }

        private void desenharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMCordenadas frm = new FRMCordenadas();
            frm.ShowDialog();
            if (frm.getOk())
            {
                xi = frm.getX1();
                yi = frm.getY1();
                desenha(img, frm.getX2(), frm.getY2());
            }
            frm.Dispose();
        }

        private void toolStripButtonLimpar_Click(object sender, EventArgs e)
        {
            pictureBox.Image = img = new Bitmap(1920, 1080);
            Util.preencher((Bitmap)pictureBox.Image, Color.White);
        }

        //------------------------------------------------------------------
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            xi = e.X;
            yi = e.Y;
            tsLBpos.Text = "[" + xi + "," + yi + "]";
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            desenha(img, e.X, e.Y);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                tsLBpos.Text = "[" + xi + "," + yi + "] " + "[" + e.X + "," + e.Y + "]";
                /*temp = new Bitmap(img);
                desenha(temp,e.X,e.Y);
                temp.Dispose();*/
            }
        }

        //-----------------------------------------------------------------

        private void desenha(Bitmap bmp, int x,int y)
        {
            xf = x;
            yf = y;

            if (xi < 0 || yi < 0 || xf < 0 || yf < 0 || xi > bmp.Width || xf > bmp.Width || yi > bmp.Height || yf > bmp.Height)
                return;

            switch (op)
            {
                case 1:
                    Reta.equacaoGeral(xi, yi, xf, yf, bmp, c);
                    break;
                case 2:
                    Reta.DDA(xi, yi, xf, yf, bmp, c);
                    break;
                case 3:
                    Reta.pontoMedio(xi, yi, xf, yf, bmp, c);
                    break;
                case 4:
                    Circunferencia.equacaoGeral(xi, yi, xf, yf, bmp, c);
                    break;
                case 5:
                    Circunferencia.trigonometrica(xi, yi, xf, yf, bmp, c);
                    break;
                case 6:
                    Circunferencia.pontoMedio(xi, yi, xf, yf, bmp, c);
                    break;
            }

            pictureBox.Image = bmp;
        }
    }
}
