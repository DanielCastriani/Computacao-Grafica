using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputacaoGrafica
{
    public partial class Principal : Form
    {
        private Image image;
        private int [,,]matHsiOriginal;
        private int[,,] matHsi;

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.FileName = "";
            openFileDialog.Filter = "Arquivos de Imagem (*.jpg;*.gif;*.bmp;*.png)|*.jpg;*.gif;*.bmp;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                if (image != null)
                {   
                    pictureBox.Image = image;
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;

                    matHsiOriginal = new int[image.Width, image.Height, 3];
                    matHsi = new int[image.Width, image.Height, 3];

                    DMA.bmpToHsi((Bitmap)image, matHsiOriginal);
                    DMA.bmpToHsi((Bitmap)image, matHsi);

                }
            }
        }

        private void corToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(800, 600);
                Color c = colorDialog.Color;
                DMA.preencher((Bitmap)image, c.R, c.G, c.B);
                pictureBox.Image = image;

                matHsiOriginal = new int[image.Width, image.Height, 3];
                matHsi = new int[image.Width, image.Height, 3];

                DMA.bmpToHsi((Bitmap)image, matHsi);
                DMA.bmpToHsi((Bitmap)image, matHsiOriginal);
            }
        }

        private void brilhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                FRMValor frm = new FRMValor("Brilho", -100, 100);
                frm.ShowDialog();
                if (frm.getAplicar())
                {
                    DMA.brilho(matHsi,matHsiOriginal, image.Height, image.Width, frm.getValor());
                    DMA.hsiToBmp(matHsi, (Bitmap)image);
                    pictureBox.Image = image;
                }
                frm.Dispose();
            }
            else
                MessageBox.Show("Abra uma Imagem");
        }

        private void matizToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                FRMValor frm = new FRMValor("Matiz", 0, 360);
                frm.ShowDialog();
                if (frm.getAplicar())
                {
                    DMA.matiz(matHsi,image.Height, image.Width, frm.getValor());
                    DMA.hsiToBmp(matHsi, (Bitmap)image);
                    pictureBox.Image = image;
                }
                frm.Dispose();
            }
            else
                MessageBox.Show("Abra uma Imagem");
        }

        private void luminânciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                DMA.Luminancia(matHsi,image.Height,image.Width);
                DMA.hsiToBmp(matHsi, (Bitmap)image);
                pictureBox.Image = image;
            }
            else
                MessageBox.Show("Abra uma Imagem");
        }
        
        private void btHSV_Click(object sender, EventArgs e)
        {
            colorDialog.ShowDialog();
            Color c = colorDialog.Color;

        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            lbTSPos.Text = "[" + e.X + "," + e.Y + "]";
            if (image != null && e.X < image.Width && e.Y < image.Height)
            {
                lbInfo.Text = DMA.getInfo((Bitmap)image, e.X, e.Y);
            }
        }

        private void hSIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap bmpH = new Bitmap(image);
                Bitmap bmpS = new Bitmap(image);
                Bitmap bmpI = new Bitmap(image);

                DMA.miniaturaHSI((Bitmap)image, bmpH, bmpS, bmpI);

                FRMImage frm = new FRMImage();
                frm.setImage("HSI",bmpH, bmpS, bmpI);
                frm.Show();

            }
            else
                MessageBox.Show("Abra uma Imagem");
        }

        private void rGBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap bmpR = new Bitmap(image);
                Bitmap bmpG = new Bitmap(image);
                Bitmap bmpB = new Bitmap(image);

                DMA.miniaturaRGB((Bitmap)image, bmpR, bmpG, bmpB);
                FRMImage frm = new FRMImage();
                frm.setImage("RGB",bmpR, bmpG, bmpB);
                frm.Show();

            }
            else
                MessageBox.Show("Abra uma Imagem");
        }

        private void rGBGrayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                Bitmap bmpR = new Bitmap(image);
                Bitmap bmpG = new Bitmap(image);
                Bitmap bmpB = new Bitmap(image);
                
                DMA.miniaturaRGBGrayScale((Bitmap)image, bmpR, bmpG, bmpB);
                FRMImage frm = new FRMImage();
                frm.setImage("RGB Gray Scale",bmpR, bmpG, bmpB);
                frm.Show();

            }
            else
                MessageBox.Show("Abra uma Imagem");
        }

        private void todosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                hSIToolStripMenuItem_Click(sender, e);
                rGBToolStripMenuItem_Click(sender, e);
                rGBGrayScaleToolStripMenuItem_Click(sender, e);
            }
            else
                MessageBox.Show("Abra uma Imagem");
        }
    }
}