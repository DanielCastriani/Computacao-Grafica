using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputacaoGrafica
{
    public partial class FRMImage : Form
    {
        public FRMImage()
        {
            InitializeComponent();
        }

        private void FRMImage_Load(object sender, EventArgs e)
        {

        }

        public void setImage(String nomeJanela,Image h,Image s, Image i)
        {
            this.Text = nomeJanela;
            pbMatiz.Image = h;
            pbSaturacao.Image = s;
            pbIntencidade.Image = i;
        }
    }
}
