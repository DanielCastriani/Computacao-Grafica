using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace _2D
{
    public partial class Principal : Form
    {
        private int xi, yi, xf, yf;
        private int opicao;
        private Color cor;
        private bool mouseDown;
        private Bitmap imagemBmp, temp;
        private int W,H;
        private DataSet dsPoligonos;
        private List<Poligono> poligonos;
        private bool poligono2;
        private int contMouseDown;
        private int[] coord;
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            cor = Color.Black;
            W = 1920;
            H = 1080;
            pictureBox.Image = imagemBmp = new Bitmap(W,H);
            Util.preencher((Bitmap)pictureBox.Image, Color.White);
            xi = yi = xf = yf = 0;
            opicao = -1;
            tsLBpos.Text = "";
            mouseDown = false;
            poligonos = new List<Poligono>();
            poligono2 = false;
           // contMouseDown = 0;
            coord = new int[2];

            dsPoligonos = Util.criaTablePoligonos();
            dgvPoligonos.DataSource = dsPoligonos;
            dgvPoligonos.DataMember = "tbPoligonos";
          
            rbOrigem.Checked = true;

            //---------------------------
            Poligono p = new Poligono();
            p.add(new Point(150, 200));
            p.add(new Point(200, 300));
            p.add(new Point(300, 90));
            novoPoligono(p);

            p = new Poligono();
            p.add(new Point(50, 50));
            p.add(new Point(150, 50));
            p.add(new Point(150, 100));
            p.add(new Point(50, 100));
            novoPoligono(p);

            p = new Poligono();
            p.add(new Point(760, 130));
            p.add(new Point(870, 200));
            p.add(new Point(830, 340));
            p.add(new Point(700, 340));
            p.add(new Point(650, 214));
            novoPoligono(p);

        }

        private void toolStripButtonCor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                cor = colorDialog.Color;
            }
        }
        //--Reta
        private void equaçãoDaRetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Equação Geral da Reta";
            opicao = 1;
            pictureBox.Cursor = Cursors.Hand;
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "DDA";
            opicao = 2;
            pictureBox.Cursor = Cursors.Hand;
        }

        private void pontoMédioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Ponto Medio(Reta)";
            opicao = 3;
            pictureBox.Cursor = Cursors.Hand;
        }
        //--Circulo
        private void equaçãoGeralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Equação Geral do Circulo";
            opicao = 4;
            pictureBox.Cursor = Cursors.Cross;
        }

        private void trigonométricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Trigonométrica";
            opicao = 5;
            pictureBox.Cursor = Cursors.Cross;
        }

        private void pontoMédioToolStripMenuItemCirculo_Click(object sender, EventArgs e)
        {
            Text = "Ponto Médio(Circulo)";
            opicao = 6;
            pictureBox.Cursor = Cursors.Cross;
        }
        //--Elipse
        private void pontoMédioToolStripMenuItemElipse_Click(object sender, EventArgs e)
        {
            Text = "Ponto Médio(Elipse)";
            opicao = 7;
            pictureBox.Cursor = Cursors.Cross;
        }

        private void desenharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripButtonLimpar_Click(object sender, EventArgs e)
        {
            pictureBox.Image = imagemBmp = new Bitmap(W, H);
            Util.preencher((Bitmap)pictureBox.Image, Color.White);
        }

        private void novoPoligono(Poligono p)
        {
            p.desenha(imagemBmp, cor);
            poligonos.Add(p);
            pictureBox.Image = imagemBmp;
            DataRow dr = dsPoligonos.Tables["tbPoligonos"].NewRow();
            dr["Poligono"] = p;
            dr["PosicaoInicial"] = p.getPosicaoInicial();
            dsPoligonos.Tables["tbPoligonos"].Rows.Add(dr);
        }

        private void desenhaPoligonos()
        {
            pictureBox.Image = imagemBmp = new Bitmap(W, H);
            Util.preencher((Bitmap)pictureBox.Image, Color.White);
            
            for (int i = 0; i < poligonos.Count; i++)
                poligonos[i].desenha(imagemBmp,cor);

            pictureBox.Image = imagemBmp;
        }

        private void btAddPoligono_Click(object sender, EventArgs e)
        {
            FRMPoligonos frm = new FRMPoligonos();
            frm.ShowDialog();
            if (frm.getDesenha())
            {
                Poligono p = new Poligono(frm.getPontos());                
                novoPoligono(p);
            }
            frm.Dispose();
        }

        private void btAplicar_Click(object sender, EventArgs e)
        {
            Poligono p = poligonos[dgvPoligonos.CurrentRow.Index];

            int tx = 0;
            int ty = 0;
            int ex = 0;
            int ey = 0;
            int angulo = 0;

            int.TryParse(tbTranslacaoX.Text,out tx);
            int.TryParse(tbTranslacaoY.Text, out ty);
            int.TryParse(tbRotacao.Text, out angulo);
            int.TryParse(tbEscalaX.Text, out ex);
            int.TryParse(tbEscalaY.Text, out ey);

            


            p.trasform(tx, ty,angulo,ex,ey);
            desenhaPoligonos();
        }

        private void retaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMCordenadas frm = new FRMCordenadas();
            frm.ShowDialog();
            if (frm.getOk())
            {
                xi = frm.getX1();
                yi = frm.getY1();
                desenha(imagemBmp, frm.getX2(), frm.getY2());
            }
            frm.Dispose();
        }

        private void poligonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btAddPoligono_Click(null,null);
        }

        private void poligono2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            poligono2 = true;
            contMouseDown = 0;
            opicao = 7;
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == '-' && ((TextBox)sender).Text.Length > 0)
                e.Handled = true;

        }

        //------------------------------------------------------------------
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            contMouseDown++;
            xi = e.X;
            yi = e.Y;

            // tsLBpos.Text = "[" + xi + "," + yi + "]";
            tsLBpos.Text = contMouseDown.ToString();
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            coord[0] = xf; coord[1] = yf;
            desenha(imagemBmp, e.X, e.Y);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                tsLBpos.Text = contMouseDown.ToString();
                //  tsLBpos.Text = "[" + xi + "," + yi + "] " + "[" + e.X + "," + e.Y + "]";
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

            switch (opicao)
            {
                case 1:
                    Reta.equacaoGeral(xi, yi, xf, yf, bmp, cor);
                    break;
                case 2:
                    Reta.DDA(xi, yi, xf, yf, bmp, cor);
                    break;
                case 3:
                    Reta.pontoMedio(xi, yi, xf, yf, bmp, cor);
                    break;
                case 4:
                    Circunferencia.equacaoGeral(xi, yi, xf, yf, bmp, cor);
                    break;
                case 5:
                    Circunferencia.trigonometrica(xi, yi, xf, yf, bmp, cor);
                    break;
                case 6:
                    Circunferencia.pontoMedio(xi, yi, xf, yf, bmp, cor);
                    break;
                case 7:
                    if(contMouseDown>1)
                        
                    Reta.poligono(xi, yi, xf, yf, bmp, cor);
                    break;
            }

            pictureBox.Image = bmp;
        }
    }
}
