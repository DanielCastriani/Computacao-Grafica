using System;
using System.Drawing;
using System.Windows.Forms;

namespace _2D
{
    public partial class Principal : Form
    {
        private int xi, yi, xf, yf;
        private int op;
        private Color c;
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            c = Color.Green;
            pictureBox.Image = new Bitmap(800,600);
            Util.preencher((Bitmap)pictureBox.Image, 0, 0, 0);
            xi = yi = xf = yf = 0;
            op = -1;
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



        //------------------------------------------------------------------
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            xi = e.X;
            yi = e.Y;
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {            
            xf = e.X;
            yf = e.Y;

            Bitmap bmp = new Bitmap(pictureBox.Image);

            if (xi < 0 || yi < 0 || xf < 0 || yf < 0 ||
                xi > bmp.Width || xf > bmp.Width || yi > bmp.Height || yf > bmp.Height)
                return;

            switch (op)
            {
                case 1:
                    Reta.equacaoGeral(xi, yi, xf, yf, bmp, c);
                break;
                case 2:
                    Reta.DDA(xi, yi, xf, yf, bmp, c);
                break;
            }
            pictureBox.Image = bmp;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {

        }

        //-----------------------------------------------------------------
    }
}
