using System;
using System.Windows.Forms;

namespace _2D
{
    public partial class FRMCordenadas : Form
    {
        private int x1, x2, y1, y2;
        private bool ok;
        public FRMCordenadas()
        {
            InitializeComponent();
            x1 = x2 = y1 = y2 = 0;
            ok = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btOk_Click(null, null);
        }

        private void btCancelar_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        
        private void btOk_Click(object sender, System.EventArgs e)
        {
            ok = int.TryParse(tbX1.Text, out x1) & int.TryParse(tbX2.Text, out x2) & int.TryParse(tbY1.Text, out y1) & int.TryParse(tbY2.Text, out y2);
            Console.WriteLine(ok);
            Close();
        }

        public int getX1() { return x1; }
        public int getX2() { return x2; }

        private void FRMCordenadas_Load(object sender, EventArgs e)
        {

        }

        public int getY1() { return y1; }
        public int getY2() { return y2; }
        public bool getOk() { return ok; }
    }
}
