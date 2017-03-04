namespace ComputacaoGrafica
{
    partial class Principal
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.arquivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trasformaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luminânciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brilhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.corToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miniaturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBGrayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.todosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lbTSPos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivosToolStripMenuItem,
            this.trasformaçõesToolStripMenuItem,
            this.corToolStripMenuItem,
            this.miniaturasToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(692, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // arquivosToolStripMenuItem
            // 
            this.arquivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.arquivosToolStripMenuItem.Name = "arquivosToolStripMenuItem";
            this.arquivosToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.arquivosToolStripMenuItem.Text = "Arquivos";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // trasformaçõesToolStripMenuItem
            // 
            this.trasformaçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.luminânciaToolStripMenuItem,
            this.brilhoToolStripMenuItem,
            this.matizToolStripMenuItem});
            this.trasformaçõesToolStripMenuItem.Name = "trasformaçõesToolStripMenuItem";
            this.trasformaçõesToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.trasformaçõesToolStripMenuItem.Text = "Trasformações";
            // 
            // luminânciaToolStripMenuItem
            // 
            this.luminânciaToolStripMenuItem.Name = "luminânciaToolStripMenuItem";
            this.luminânciaToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.luminânciaToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.luminânciaToolStripMenuItem.Text = "Luminância";
            this.luminânciaToolStripMenuItem.Click += new System.EventHandler(this.luminânciaToolStripMenuItem_Click);
            // 
            // brilhoToolStripMenuItem
            // 
            this.brilhoToolStripMenuItem.Name = "brilhoToolStripMenuItem";
            this.brilhoToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.brilhoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.brilhoToolStripMenuItem.Text = "Brilho";
            this.brilhoToolStripMenuItem.Click += new System.EventHandler(this.brilhoToolStripMenuItem_Click);
            // 
            // matizToolStripMenuItem
            // 
            this.matizToolStripMenuItem.Name = "matizToolStripMenuItem";
            this.matizToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.matizToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.matizToolStripMenuItem.Text = "Matiz";
            this.matizToolStripMenuItem.Click += new System.EventHandler(this.matizToolStripMenuItem_Click);
            // 
            // corToolStripMenuItem
            // 
            this.corToolStripMenuItem.Name = "corToolStripMenuItem";
            this.corToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.corToolStripMenuItem.Text = "Cor";
            this.corToolStripMenuItem.Click += new System.EventHandler(this.corToolStripMenuItem_Click);
            // 
            // miniaturasToolStripMenuItem
            // 
            this.miniaturasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hSIToolStripMenuItem,
            this.rGBToolStripMenuItem,
            this.rGBGrayScaleToolStripMenuItem,
            this.todosToolStripMenuItem});
            this.miniaturasToolStripMenuItem.Name = "miniaturasToolStripMenuItem";
            this.miniaturasToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.miniaturasToolStripMenuItem.Text = "Miniaturas";
            // 
            // hSIToolStripMenuItem
            // 
            this.hSIToolStripMenuItem.Name = "hSIToolStripMenuItem";
            this.hSIToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.hSIToolStripMenuItem.Text = "HSI";
            this.hSIToolStripMenuItem.Click += new System.EventHandler(this.hSIToolStripMenuItem_Click);
            // 
            // rGBToolStripMenuItem
            // 
            this.rGBToolStripMenuItem.Name = "rGBToolStripMenuItem";
            this.rGBToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.rGBToolStripMenuItem.Text = "RGB";
            this.rGBToolStripMenuItem.Click += new System.EventHandler(this.rGBToolStripMenuItem_Click);
            // 
            // rGBGrayScaleToolStripMenuItem
            // 
            this.rGBGrayScaleToolStripMenuItem.Name = "rGBGrayScaleToolStripMenuItem";
            this.rGBGrayScaleToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.rGBGrayScaleToolStripMenuItem.Text = "RGB Gray Scale";
            this.rGBGrayScaleToolStripMenuItem.Click += new System.EventHandler(this.rGBGrayScaleToolStripMenuItem_Click);
            // 
            // todosToolStripMenuItem
            // 
            this.todosToolStripMenuItem.Name = "todosToolStripMenuItem";
            this.todosToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.todosToolStripMenuItem.Text = "RGB/HSI";
            this.todosToolStripMenuItem.Click += new System.EventHandler(this.todosToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "Abrir";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbTSPos,
            this.lbInfo});
            this.statusStrip.Location = new System.Drawing.Point(0, 464);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(692, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip";
            // 
            // lbTSPos
            // 
            this.lbTSPos.Name = "lbTSPos";
            this.lbTSPos.Size = new System.Drawing.Size(66, 17);
            this.lbTSPos.Text = "[0000,0000]";
            // 
            // lbInfo
            // 
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(283, 17);
            this.lbInfo.Text = "RGB[000,000,000] CMY[000,000,000] HSI[000,000,000]";
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 24);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(692, 440);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 486);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Principal";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem arquivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lbInfo;
        private System.Windows.Forms.ToolStripStatusLabel lbTSPos;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ToolStripMenuItem trasformaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luminânciaToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripMenuItem corToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miniaturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rGBGrayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem todosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brilhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matizToolStripMenuItem;
    }
}

