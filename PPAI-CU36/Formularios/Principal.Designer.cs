namespace PPAI_CU36.Formularios
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
            this.titleBar = new System.Windows.Forms.Panel();
            this.btnMaximize = new System.Windows.Forms.PictureBox();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnClosed = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosed)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(43)))), ((int)(((byte)(73)))));
            this.titleBar.Controls.Add(this.btnMaximize);
            this.titleBar.Controls.Add(this.btnMinimize);
            this.titleBar.Controls.Add(this.btnClosed);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(912, 36);
            this.titleBar.TabIndex = 12;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseUp);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Image = global::PPAI_CU36.Properties.Resources._8726465_window_maximize_icon;
            this.btnMaximize.Location = new System.Drawing.Point(862, 12);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(16, 16);
            this.btnMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMaximize.TabIndex = 14;
            this.btnMaximize.TabStop = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = global::PPAI_CU36.Properties.Resources.Minimize_Icon;
            this.btnMinimize.Location = new System.Drawing.Point(840, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(16, 16);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimize.TabIndex = 13;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClosed
            // 
            this.btnClosed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClosed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClosed.Image = global::PPAI_CU36.Properties.Resources.Close_Icon;
            this.btnClosed.Location = new System.Drawing.Point(884, 12);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(16, 16);
            this.btnClosed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClosed.TabIndex = 12;
            this.btnClosed.TabStop = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(103)))), ((int)(((byte)(242)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.informToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 40);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(377, 28);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.DodgerBlue;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 24);
            this.toolStripMenuItem1.Text = "Casos de Uso";
            // 
            // registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem
            // 
            this.registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem.Name = "registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem";
            this.registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem.Size = new System.Drawing.Size(516, 24);
            this.registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem.Text = "Registrar Ingreso de RT en manteniemiento preventivo";
            this.registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem.Click += new System.EventHandler(this.registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem_Click);
            // 
            // informToolStripMenuItem
            // 
            this.informToolStripMenuItem.BackColor = System.Drawing.Color.DodgerBlue;
            this.informToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.informToolStripMenuItem.Name = "informToolStripMenuItem";
            this.informToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.informToolStripMenuItem.Text = "Información";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PPAI_CU36.Properties.Resources.Logo_UTN_FRC;
            this.pictureBox1.Location = new System.Drawing.Point(539, 412);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(361, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(59)))), ((int)(((byte)(104)))));
            this.BackgroundImage = global::PPAI_CU36.Properties.Resources._10623965_919817228097553_8556447570984807974_o;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(912, 568);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosed)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.PictureBox btnClosed;
        private System.Windows.Forms.PictureBox btnMaximize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem registrarIngresoDeRTEnManteniemientoPreventivoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem informToolStripMenuItem;
    }
}