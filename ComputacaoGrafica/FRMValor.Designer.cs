namespace ComputacaoGrafica
{
    partial class FRMValor
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
            this.tbValor = new System.Windows.Forms.TrackBar();
            this.lbTxt = new System.Windows.Forms.Label();
            this.lbValor = new System.Windows.Forms.Label();
            this.btAplicar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbValor)).BeginInit();
            this.SuspendLayout();
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(53, 9);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(175, 45);
            this.tbValor.TabIndex = 0;
            this.tbValor.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lbTxt
            // 
            this.lbTxt.AutoSize = true;
            this.lbTxt.Location = new System.Drawing.Point(12, 9);
            this.lbTxt.Name = "lbTxt";
            this.lbTxt.Size = new System.Drawing.Size(35, 13);
            this.lbTxt.TabIndex = 1;
            this.lbTxt.Text = "label1";
            // 
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValor.Location = new System.Drawing.Point(234, 9);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(15, 16);
            this.lbValor.TabIndex = 2;
            this.lbValor.Text = "0";
            // 
            // btAplicar
            // 
            this.btAplicar.Location = new System.Drawing.Point(91, 60);
            this.btAplicar.Name = "btAplicar";
            this.btAplicar.Size = new System.Drawing.Size(75, 23);
            this.btAplicar.TabIndex = 3;
            this.btAplicar.Text = "Aplicar";
            this.btAplicar.UseVisualStyleBackColor = true;
            this.btAplicar.Click += new System.EventHandler(this.btAplicar_Click);
            // 
            // FRMValor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 97);
            this.Controls.Add(this.btAplicar);
            this.Controls.Add(this.lbValor);
            this.Controls.Add(this.lbTxt);
            this.Controls.Add(this.tbValor);
            this.Name = "FRMValor";
            this.Text = "FRMValor";
            this.Load += new System.EventHandler(this.FRMValor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbValor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbValor;
        private System.Windows.Forms.Label lbTxt;
        private System.Windows.Forms.Label lbValor;
        private System.Windows.Forms.Button btAplicar;
    }
}