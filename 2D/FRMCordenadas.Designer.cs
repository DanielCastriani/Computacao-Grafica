namespace _2D
{
    partial class FRMCordenadas
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbX1 = new System.Windows.Forms.TextBox();
            this.tbX2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbY1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbY2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X1";
            // 
            // tbX1
            // 
            this.tbX1.Location = new System.Drawing.Point(39, 10);
            this.tbX1.Name = "tbX1";
            this.tbX1.Size = new System.Drawing.Size(60, 20);
            this.tbX1.TabIndex = 1;
            this.tbX1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tbX2
            // 
            this.tbX2.Location = new System.Drawing.Point(39, 36);
            this.tbX2.Name = "tbX2";
            this.tbX2.Size = new System.Drawing.Size(60, 20);
            this.tbX2.TabIndex = 3;
            this.tbX2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "X2";
            // 
            // tbY1
            // 
            this.tbY1.Location = new System.Drawing.Point(128, 10);
            this.tbY1.Name = "tbY1";
            this.tbY1.Size = new System.Drawing.Size(60, 20);
            this.tbY1.TabIndex = 2;
            this.tbY1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(102, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y1";
            // 
            // tbY2
            // 
            this.tbY2.Location = new System.Drawing.Point(128, 36);
            this.tbY2.Name = "tbY2";
            this.tbY2.Size = new System.Drawing.Size(60, 20);
            this.tbY2.TabIndex = 4;
            this.tbY2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Y2";
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(25, 76);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 5;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(113, 76);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 9;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // FRMCordenadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 111);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.tbY2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbY1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbX2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbX1);
            this.Controls.Add(this.label1);
            this.Name = "FRMCordenadas";
            this.Text = "FRMCordenadas";
            this.Load += new System.EventHandler(this.FRMCordenadas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbX1;
        private System.Windows.Forms.TextBox tbX2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbY1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbY2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancelar;
    }
}