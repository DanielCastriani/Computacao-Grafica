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
        private int opcao;
        private int contMouseDown;
        private int[] coord;
        private bool mouseDown;
        private bool isDesenhaPoligonoMouse;
        private bool moverPoligono;
        private Color cor,fundo;
        private Bitmap imagemBmp;
        private DataSet dsPoligonos;
        private List<Poligono> poligonos;
        private Poligono poligono;

        #region Principal
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
            opcao = -1;
            tsLBpos.Text = "";
            mouseDown = false;
            moverPoligono = false;
            poligonos = new List<Poligono>();
            isDesenhaPoligonoMouse = false;
           // contMouseDown = 0;
            coord = new int[2];

            dsPoligonos = Util.criaTablePoligonos();
            dgvPoligonos.DataSource = dsPoligonos;
            dgvPoligonos.DataMember = "tbPoligonos";
          
            rbOrigem.Checked = true;
            rbTranslacao.Checked = true;
            fundo = Color.White;
            //---------------------------
            Poligono p = new Poligono(cor);
            p.add(new Point(490, 50));
            p.add(new Point(490, 280));
            p.add(new Point(700, 280));
            novoPoligono(p);

            p = new Poligono(cor);
            p.add(new Point(170, 320));
            p.add(new Point(420, 320));
            p.add(new Point(420, 440));
            p.add(new Point(170, 440));
            novoPoligono(p);
            
            p = new Poligono(cor);
            p.add(new Point(240, 40));
            p.add(new Point(95, 130));
            p.add(new Point(150, 280));
            p.add(new Point(330, 280));
            p.add(new Point(380, 130));
            novoPoligono(p);

        }

        public static int getWTela()
        {
            return W;
        }

        public static int getHTela()
        {
            return H;
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ',' && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == ',' && ((TextBox)sender).Text.Contains(","))
                e.Handled = true;

            if (e.KeyChar == '-' && ((TextBox)sender).Text.Contains("-"))
                e.Handled = true;

        }
        #endregion
        #region ToolStripButton
        private void toolStripButtonCor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                cor = colorDialog.Color;
            }
        }

        private void limparToolStripMenuItem_Click(object sender, EventArgs e)
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
                pol.desenha(imagemBmp);
            }
            pictureBox.Image = imagemBmp;
        }

        //--Reta
        private void equaçãoDaRetaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Equação Geral da Reta";
            opcao = 1;
            pictureBox.Cursor = Cursors.Hand;
        }

        private void dDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "DDA";
            opcao = 2;
            pictureBox.Cursor = Cursors.Hand;
        }

        private void pontoMédioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Ponto Medio(Reta)";
            opcao = 3;
            pictureBox.Cursor = Cursors.Hand;
        }
        //--Circulo
        private void equaçãoGeralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Equação Geral do Circulo";
            opcao = 4;
            pictureBox.Cursor = Cursors.Cross;
        }

        private void trigonométricaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Trigonométrica";
            opcao = 5;
            pictureBox.Cursor = Cursors.Cross;
        }

        private void pontoMédioToolStripMenuItemCirculo_Click(object sender, EventArgs e)
        {
            Text = "Ponto Médio(Circulo)";
            opcao = 6;
            pictureBox.Cursor = Cursors.Cross;
        }
        //--Elipse
        private void pontoMédioToolStripMenuItemElipse_Click(object sender, EventArgs e)
        {
            Text = "Ponto Médio(Elipse)";
            opcao = 7;
            pictureBox.Cursor = Cursors.Cross;
        }

        private void toolStripDesenhaPoligono_Click(object sender, EventArgs e)
        {
            poligono2ToolStripMenuItem_Click(null, null);
        }

        private void toolStripButtonEspelhoVertical_Click(object sender, EventArgs e)
        {
            espelho(true);
        }

        private void toolStripButtonEspelhoHorizontal_Click(object sender, EventArgs e)
        {
            espelho(false);
        }

        private void floodFillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.Cursor = Cursors.Hand;
            opcao = 8;
        }

        private void scanlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.Cursor = Cursors.Hand;
            opcao = 9;
        }

        private void espelho(bool vertical)
        {
            Poligono p = getPoligonoSelecionado();
            if (p != null)
            {
                Point pt = p.getCentroAtual();
                p.traslacao(-pt.X, -pt.Y);
                p.espelhamento(vertical);
                p.traslacao(pt.X, pt.Y);
                desenhaPoligonos();
            }
        }
        #endregion
        #region StripMenu
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
            btAddPoligono_Click(null, null);
        }
        private void poligono2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.Cursor = Cursors.Cross;
            poligono = new Poligono(cor);
            isDesenhaPoligonoMouse = true;
            contMouseDown = 0;
            opcao = 7;
        }
        private void moverPoligonoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moverPoligono = true;
        }
        private void pararDeMoverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moverPoligono = false;
        }
        #endregion
        #region Buttons
        private void btAplicar_Click(object sender, EventArgs e)
        {
            Poligono p = getPoligonoSelecionado();
            if (p != null)
            {
                double tx = 0;
                double ty = 0;
                double angulo = 0;

                double.TryParse(tbTranslacaoX.Text, out tx);
                double.TryParse(tbTranslacaoY.Text, out ty);
                double.TryParse(tbRotacao.Text, out angulo);

                if (rbOrigem.Checked)
                {
                    if (rbTranslacao.Checked)
                        p.traslacao(tx, ty);
                    if (rbEscala.Checked)
                        p.escala(tx, ty);
                    if (rbRotacao.Checked)
                        p.rotacao(angulo);
                    if (rbCisalhamento.Checked)
                        p.cisalhamento(tx, ty);
                    if (rbHorizontal.Checked)
                        p.espelhamento(false);
                    if (rbVertical.Checked)
                        p.espelhamento(true);
                }
                else
                {
                    if (rbCentro.Checked)
                    {
                        Point pt = p.getCentroOriginal();
                        p.traslacao(-pt.X, -pt.Y);
                        if (rbTranslacao.Checked)
                            p.traslacao(tx, ty);
                        if (rbEscala.Checked)
                            p.escala(tx, ty);
                        if (rbRotacao.Checked)
                            p.rotacao(angulo);
                        if (rbCisalhamento.Checked)
                            p.cisalhamento(tx, ty);
                        if (rbHorizontal.Checked)
                            p.espelhamento(false);
                        if (rbVertical.Checked)
                            p.espelhamento(true);
                        p.traslacao(pt.X, pt.Y);
                    }

                }
                desenhaPoligonos();
            }
        }
        private void btAddPoligono_Click(object sender, EventArgs e)
        {
            FRMPoligonos frm = new FRMPoligonos();
            frm.ShowDialog();
            if (frm.getDesenha() && frm.getPontos().Count > 3)
            {
                Poligono p = new Poligono(frm.getPontos(), cor);
                novoPoligono(p);
            }
            frm.Dispose();
        }
        private void btRemPoligono_Click(object sender, EventArgs e)
        {

            Poligono p = getPoligonoSelecionado();
            if (p != null)
            {
                DataRow dr = dsPoligonos.Tables["tbPoligonos"].Rows.Find(p.getPosicaoInicial());
                dsPoligonos.Tables["tbPoligonos"].Rows.Remove(dr);
                poligonos.Remove(p);
                desenhaPoligonos();
            }
        }
        #endregion
        #region Picturebox
        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            poligonoClick(e);
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            xi = e.X;
            yi = e.Y;
            moverPoligonoClick(e);

        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            xf = e.X; yf = e.Y;

            if (!moverPoligono && isDesenhaPoligonoMouse)
            {
                if (!isDesenhaPoligonoMouse)
                    desenha(imagemBmp, xf, yf);
                else
                    if (contMouseDown > 1)
                    desenha(imagemBmp, xf, yf);
            }
            else
                desenha(imagemBmp, xf, yf);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                moverPoligonoClick(e);
            }
            tsLBpos.Text = "[" + e.X + "," + e.Y + "]";
        }

        private void dgvPoligonos_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvPoligonos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (poligonos.Count > e.RowIndex)
            {
                DataSet dsPts = Util.criaTablePontos();
                dgvPontos.DataSource = dsPts;
                dgvPontos.DataMember = "tbPontos";
                Poligono p = poligonos[e.RowIndex];
                if (p != null)
                {
                    List<Point> pts = p.getPontos();
                    foreach (Point pt in pts)
                    {
                        DataRow dr = dsPts.Tables["tbPontos"].NewRow();
                        dr["Ponto"] = new Point(pt.X, pt.Y);
                        dsPts.Tables["tbPontos"].Rows.Add(dr);
                    }
                }
            }
        }
        #endregion

        private void novoPoligono(Poligono p)
        {
            if (p.getPontos().Count > 2)
           {
                p.desenha(imagemBmp);
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
            Util.preencher((Bitmap)pictureBox.Image, fundo);

            for (int i = 0; i < poligonos.Count; i++)
            {
                Poligono p = poligonos[i];
                p.desenha(imagemBmp);
                Point centro = p.getCentroAtual();
            }

            pictureBox.Image = imagemBmp;
        }

        private Poligono getPoligonoSelecionado()
        {
            if (dgvPoligonos.CurrentRow != null)
                return poligonos[dgvPoligonos.CurrentRow.Index];
            return null;
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

        private void poligonoClick(MouseEventArgs e)
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
                    opcao = -1;
                    pictureBox.Cursor = Cursors.Arrow;
                    novoPoligono(poligono);
                }
            }
        }       

        private void moverPoligonoClick(MouseEventArgs e)
        {
            if (moverPoligono)
            {
                Poligono p = getPoligonoSelecionado();

                Point pontos = p.getCentroAtual();

                double dy = (double)e.Y - pontos.Y;
                double dx = (double)e.X - pontos.X;

                p.traslacao(dx, dy);
                desenhaPoligonos();
            }
        }
        
        private void desenha(Bitmap bmp, int x,int y)
        {
            xf = x;
            yf = y;

            if (xi < 0 || yi < 0 || xf < 0 || yf < 0 || xi > bmp.Width || xf > bmp.Width || yi > bmp.Height || yf > bmp.Height)
                return;

            switch (opcao)
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
                    Elipse.pontoMedio(xi, yi, xf, yf, bmp, cor);
                    break;
                case 8:
                    Preenchimento.floodFill(xf, yf, bmp, cor);
                    break;
                case 9:
                    if (poligonos.Count > 0)
                    {
                        Poligono click = poligonos[0];
                        foreach (Poligono p in poligonos)
                        {
                            if (p.getDistanciaClick(xf, yf) < click.getDistanciaClick(xf, yf))
                                click = p;
                        }
                        Preenchimento.scanLine(xf, yf, bmp, cor, click);
                    }
                break;

            }

            pictureBox.Image = bmp;
        }
    }
}