using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace _2D
{
    public partial class FRMPoligonos : Form
    {
        private DataSet ds;
        private bool desenha;

        public FRMPoligonos()
        {
            InitializeComponent();
            ds = Util.criaTablePontos();

            dgvPontos.DataSource = ds;
            dgvPontos.DataMember = "tbPontos";
            desenha = false;

            tbX.Focus();
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            if (e.KeyChar == 13)
                btAdd_Click(null, null);
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            int x, y;
            bool erro = int.TryParse(tbX.Text, out x);
            erro = erro | int.TryParse(tbY.Text, out y);
            if (!erro)
                return;

            DataRow dr = ds.Tables["tbPontos"].NewRow();
            dr["Ponto"] = new Point(x, y);
            ds.Tables["tbPontos"].Rows.Add(dr);

            tbX.Clear();
            tbX.Focus();
            tbY.Clear();

        }

        private void btRM_Click(object sender, EventArgs e)
        {
            
        }

        private void btDesenhar_Click(object sender, EventArgs e)
        {
            desenha = true;
            Close();
        }

        public bool getDesenha()
        {
            return desenha;
        }

        public List<Point> getPontos()
        {
            List<Point> l = new List<Point>();
            Point p;
            for (int i = 0; i < ds.Tables["tbPontos"].Rows.Count; i++)
                l.Add((Point)ds.Tables["tbPontos"].Rows[i]["Ponto"]);
            return l;
        }
    }
}
