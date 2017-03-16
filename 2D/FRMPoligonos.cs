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
        private int pos;
        public FRMPoligonos()
        {
            InitializeComponent();
           
        }

        private void FRMPoligonos_Load(object sender, EventArgs e)
        {
            ds = Util.criaTablePontos();

            dgvPontos.DataSource = ds;
            dgvPontos.DataMember = "tbPontos";            

            desenha = false;
            tbX.Focus();
            pos = -1;
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

            pos = dgvPontos.Rows.Count - 1;
            dgvPontos.CurrentCell = dgvPontos.Rows[dgvPontos.Rows.Count - 1].Cells[0];

        }

        private void btRM_Click(object sender, EventArgs e)
        {
            if (pos > 0)
            {
                ds.Tables["Pontos"].Rows.RemoveAt(pos);
                dgvPontos.Refresh();
            }
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
            for (int i = 0; i < ds.Tables["tbPontos"].Rows.Count; i++)
                l.Add((Point)ds.Tables["tbPontos"].Rows[i]["Ponto"]);
            return l;
        }

      

    }
}
