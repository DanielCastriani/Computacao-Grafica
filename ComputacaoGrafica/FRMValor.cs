using System;
using System.Windows.Forms;

namespace ComputacaoGrafica
{
    public partial class FRMValor : Form
    {
        private bool ok;
        public FRMValor(String nome,int min, int max)
        {
            ok = false;
            InitializeComponent();
            lbTxt.Text = nome;
            this.Text = nome;
            tbValor.Minimum = min;
            tbValor.Maximum = max;
            tbValor.Value = 0;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            lbValor.Text = tbValor.Value.ToString();
        }

        private void FRMValor_Load(object sender, EventArgs e)
        {

        }

        private void btAplicar_Click(object sender, EventArgs e)
        {
            ok = true;
            this.Close();
        }
        public bool getAplicar()
        {
            return ok;

        }
        public int getValor()
        {
            return tbValor.Value;
        }
    }
}
