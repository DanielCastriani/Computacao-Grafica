namespace _2D
{
    partial class FRMPoligonos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPontos = new System.Windows.Forms.DataGridView();
            this.tbX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbY = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRM = new System.Windows.Forms.Button();
            this.Ponto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btDesenhar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPontos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPontos
            // 
            this.dgvPontos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPontos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ponto});
            this.dgvPontos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPontos.Location = new System.Drawing.Point(13, 13);
            this.dgvPontos.Name = "dgvPontos";
            this.dgvPontos.ReadOnly = true;
            this.dgvPontos.Size = new System.Drawing.Size(250, 150);
            this.dgvPontos.TabIndex = 0;
            // 
            // tbX
            // 
            this.tbX.Location = new System.Drawing.Point(33, 167);
            this.tbX.Name = "tbX";
            this.tbX.Size = new System.Drawing.Size(100, 20);
            this.tbX.TabIndex = 1;
            this.tbX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            // 
            // tbY
            // 
            this.tbY.Location = new System.Drawing.Point(163, 167);
            this.tbY.Name = "tbY";
            this.tbY.Size = new System.Drawing.Size(100, 20);
            this.tbY.TabIndex = 3;
            this.tbY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(269, 60);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(32, 23);
            this.btAdd.TabIndex = 5;
            this.btAdd.Text = "+";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btRM
            // 
            this.btRM.Location = new System.Drawing.Point(269, 89);
            this.btRM.Name = "btRM";
            this.btRM.Size = new System.Drawing.Size(32, 23);
            this.btRM.TabIndex = 6;
            this.btRM.Text = "-";
            this.btRM.UseVisualStyleBackColor = true;
            this.btRM.Click += new System.EventHandler(this.btRM_Click);
            // 
            // Ponto
            // 
            this.Ponto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ponto.DataPropertyName = "Ponto";
            this.Ponto.HeaderText = "Ponto";
            this.Ponto.Name = "Ponto";
            this.Ponto.ReadOnly = true;
            // 
            // btDesenhar
            // 
            this.btDesenhar.Location = new System.Drawing.Point(107, 193);
            this.btDesenhar.Name = "btDesenhar";
            this.btDesenhar.Size = new System.Drawing.Size(75, 23);
            this.btDesenhar.TabIndex = 7;
            this.btDesenhar.Text = "Desenhar";
            this.btDesenhar.UseVisualStyleBackColor = true;
            this.btDesenhar.Click += new System.EventHandler(this.btDesenhar_Click);
            // 
            // FRMPoligonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 225);
            this.Controls.Add(this.btDesenhar);
            this.Controls.Add(this.btRM);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbX);
            this.Controls.Add(this.dgvPontos);
            this.Name = "FRMPoligonos";
            this.Text = "FRMPoligonos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPontos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPontos;
        private System.Windows.Forms.TextBox tbX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbY;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ponto;
        private System.Windows.Forms.Button btDesenhar;
    }
}