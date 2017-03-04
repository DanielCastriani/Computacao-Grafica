namespace ComputacaoGrafica
{
    partial class FRMImage
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbMatiz = new System.Windows.Forms.PictureBox();
            this.pbSaturacao = new System.Windows.Forms.PictureBox();
            this.pbIntencidade = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMatiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaturacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIntencidade)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.pbMatiz, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbSaturacao, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.pbIntencidade, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 227);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pbMatiz
            // 
            this.pbMatiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMatiz.Location = new System.Drawing.Point(3, 3);
            this.pbMatiz.Name = "pbMatiz";
            this.pbMatiz.Size = new System.Drawing.Size(195, 221);
            this.pbMatiz.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMatiz.TabIndex = 0;
            this.pbMatiz.TabStop = false;
            // 
            // pbSaturacao
            // 
            this.pbSaturacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSaturacao.Location = new System.Drawing.Point(204, 3);
            this.pbSaturacao.Name = "pbSaturacao";
            this.pbSaturacao.Size = new System.Drawing.Size(195, 221);
            this.pbSaturacao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSaturacao.TabIndex = 1;
            this.pbSaturacao.TabStop = false;
            // 
            // pbIntencidade
            // 
            this.pbIntencidade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbIntencidade.Location = new System.Drawing.Point(405, 3);
            this.pbIntencidade.Name = "pbIntencidade";
            this.pbIntencidade.Size = new System.Drawing.Size(197, 221);
            this.pbIntencidade.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIntencidade.TabIndex = 2;
            this.pbIntencidade.TabStop = false;
            // 
            // FRMImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 227);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FRMImage";
            this.Text = "FRMImage";
            this.Load += new System.EventHandler(this.FRMImage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbMatiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSaturacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIntencidade)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pbMatiz;
        private System.Windows.Forms.PictureBox pbSaturacao;
        private System.Windows.Forms.PictureBox pbIntencidade;
    }
}