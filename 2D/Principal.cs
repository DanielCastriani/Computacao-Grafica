using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace _2D
{
    public partial class Principal : Form
    {
        private static int W, H;

        private int xi, yi, xf, yf;
        private int opicao;
        private int contMouseDown;
        private int[] coord;
        private bool mouseDown;
        private bool isDesenhaPoligonoMouse;
        private Color cor;
        private Bitmap imagemBmp;
        private DataSet dsPoligonos;
        private List<Poligono> poligonos;
        private Poligono poligono;
        private int k1 = 0 , k2= 0;
        public Principal()
        {
            InitializeComponent();
        }

        public static int getWTela()
        {
            return W;
        }

        public static int getHTela()
        {
            return H;
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
            isDesenhaPoligonoMouse = false;
           // contMouseDown = 0;
            coord = new int[2];

            dsPoligonos = Util.criaTablePoligonos();
            dgvPoligonos.DataSource = dsPoligonos;
            dgvPoligonos.DataMember = "tbPoligonos";
          
            rbPonto.Checked = true;
            rbTranslacao.Checked = true;
            //---------------------------
            Poligono p = new Poligono();
            p.add(new Point(490, 50));
            p.add(new Point(490, 280));
            p.add(new Point(700, 280));
            novoPoligono(p);

            p = new Poligono();
            p.add(new Point(170, 320));
            p.add(new Point(420, 320));
            p.add(new Point(420, 440));
            p.add(new Point(170, 440));
            novoPoligono(p);
            
            p = new Poligono();
            p.add(new Point(240, 40));
            p.add(new Point(95, 130));
            p.add(new Point(150, 280));
            p.add(new Point(330, 280));
            p.add(new Point(380, 130));
            novoPoligono(p);

        }

        //-------------------------Botões---------------------------------------
        
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
        
        private void toolStripButtonLimpar_Click(object sender, EventArgs e)
        {
            pictureBox.Image = imagemBmp = new Bitmap(W, H);
            Util.preencher((Bitmap)pictureBox.Image, Color.White);
        }

        private void novoPoligono(Poligono p)
        {
            if (p.getPontos().Count > 2)
           {
                p.desenha(imagemBmp, cor);
                poligonos.Add(p);
                pictureBox.Image = imagemBmp;
                DataRow dr = dsPoligonos.Tables["tbPoligonos"].NewRow();
                dr["Poligono"] = p;
                dr["PosicaoInicial"] = p.getPosicaoInicial();
                dsPoligonos.Tables["tbPoligonos"].Rows.Add(dr);
           }
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
            if (frm.getDesenha() && frm.getPontos().Count > 3)
            {
                Poligono p = new Poligono(frm.getPontos());                
                novoPoligono(p);
            }
            frm.Dispose();
        }

        private void btAplicar_Click(object sender, EventArgs e)
        {
            Poligono p = poligonos[dgvPoligonos.CurrentRow.Index];

            double tx = 0;
            double ty = 0;
            double angulo = 0;

            double.TryParse(tbTranslacaoX.Text,out tx);
            double.TryParse(tbTranslacaoY.Text, out ty);
            double.TryParse(tbRotacao.Text, out angulo);

            if (rbPonto.Checked)
            {
                if(rbTranslacao.Checked)
                    p.traslacao(tx, ty);
                if(rbEscala.Checked)
                    p.escala(tx, ty);
                if(rbRotacao.Checked)
                    p.rotacao(angulo);
                if (rbCisalhamento.Checked)
                    p.cisalhamento(tx, ty);
            }
            else
            {
                if (rbCentro.Checked)
                {
                    Point pt = p.getCentro();
                    if (rbTranslacao.Checked)
                    {
                        p.traslacao(-pt.X,-pt.Y);
                        p.traslacao(tx, ty);
                        p.traslacao(pt.X, pt.Y);
                    }
                    if (rbEscala.Checked)
                    {
                        p.traslacao(-pt.X, -pt.Y);
                        p.escala(tx, ty);
                        p.traslacao(pt.X, pt.Y);
                    }
                    if (rbRotacao.Checked)
                    {
                        p.traslacao(-pt.X, -pt.Y);
                        p.rotacao(angulo);
                        p.traslacao(pt.X, pt.Y);
                    }
                    if (rbCisalhamento.Checked)
                    {
                        p.traslacao(-pt.X, -pt.Y);
                        p.cisalhamento(tx, ty);
                        p.traslacao(pt.X, pt.Y);
                    }

                }
                else
                {
                    p.origem();
                    if (rbTranslacao.Checked)
                        p.traslacao(tx, ty);
                    if (rbEscala.Checked)
                        p.escala(tx, ty);
                    if (rbRotacao.Checked)
                        p.rotacao(angulo);
                    if (rbCisalhamento.Checked)
                        p.cisalhamento(tx, ty);
                }

            }
            desenhaPoligonos();
        }
        #region 
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
        #endregion
        private void poligonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btAddPoligono_Click(null,null);
        }

        private void poligono2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.Cursor = Cursors.Cross;
            poligono = new Poligono();
            isDesenhaPoligonoMouse = true;
            contMouseDown = 0;
            opicao = 7;
        }

        private void espelho(bool vertical)
        {
            Poligono p = poligonos[dgvPoligonos.CurrentRow.Index];
            Point pt = p.getCentro();
            p.traslacao(-pt.X, -pt.Y);
            p.espelhamento(vertical);
            p.traslacao(pt.X, pt.Y);
            desenhaPoligonos();
        }

        private void toolStripButtonEspelhoVertical_Click(object sender, EventArgs e)
        {
            espelho(true);   
        }

        private void toolStripButtonEspelhoHorizontal_Click(object sender, EventArgs e)
        {
            espelho(false);
        }

        private void toolStripDesenhaPoligono_Click(object sender, EventArgs e)
        {
            poligono2ToolStripMenuItem_Click(null,null);
        }

        private void limparToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonLimpar_ButtonClick(null, null);
        }

        private void toolStripButtonLimpar_ButtonClick(object sender, EventArgs e)
        {
            pictureBox.Image = imagemBmp = new Bitmap(W, H);
            Util.preencher((Bitmap)pictureBox.Image, Color.White);
        }

        private void resetPoligonosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imagemBmp = new Bitmap(W, H);
            Util.preencher(imagemBmp, Color.White);
            foreach (Poligono pol in poligonos)
            {
                pol.reset();
                pol.desenha(imagemBmp, cor);
            }
            pictureBox.Image = imagemBmp;
        }
        
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == '.' && (((TextBox)sender).Text.Trim('-').Contains(".") || ((TextBox)sender).Text.Trim('-').Length == 0))
                e.Handled = true;

            if (e.KeyChar == '-' && ((TextBox)sender).Text.Length > 0)
                e.Handled = true;

        }

        //------------------------------------------------------------------

        
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            xi = e.X;
            yi = e.Y;
        }
        private void desenhoClick()
        {
            contMouseDown++;
            if (contMouseDown > 1)
            {
                xi = xf;
                yi = yf;
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (isDesenhaPoligonoMouse)
            {
                if (e.Button == MouseButtons.Left)
                {
                    desenhoClick();
                    poligono.add(new Point(e.X, e.Y));
                }
                else
                {
                    isDesenhaPoligonoMouse = false;
                    opicao = -1;
                    pictureBox.Cursor = Cursors.Arrow;
                    novoPoligono(poligono);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            xf = e.X; yf = e.Y;
            
            if(!isDesenhaPoligonoMouse)
                desenha(imagemBmp, xf, yf);
            else
                if(contMouseDown>1)
                    desenha(imagemBmp,xf,yf);
        }

       

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                tsLBpos.Text = contMouseDown.ToString();
                //  tsLBpos.Text = "[" + xi + "," + yi + "] " + "[" + e.X + "," + e.Y + "]";
                //temp = new Bitmap(imagemBmp);
                //desenha(temp,e.X,e.Y);
                //temp.Dispose();
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
                    Reta.pontoMedio(xi, yi, xf, yf, bmp, cor);
                    break;
                case 8:
                    break;
            }

            pictureBox.Image = bmp;
        }
    }
}