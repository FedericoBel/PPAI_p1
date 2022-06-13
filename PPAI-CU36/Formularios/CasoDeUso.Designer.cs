namespace PPAI_CU36.Formularios
{
    partial class CasoDeUso
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
            this.gdrRecursos = new System.Windows.Forms.DataGridView();
            this.tipoRecurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gdrTurnos = new System.Windows.Forms.DataGridView();
            this.Cientifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtFechaFin = new System.Windows.Forms.MaskedTextBox();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRazon = new System.Windows.Forms.TextBox();
            this.lblRazon = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblNotificacion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdWhatsApp = new System.Windows.Forms.RadioButton();
            this.rdMail = new System.Windows.Forms.RadioButton();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnLimpiarCampos = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdrRecursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdrTurnos)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.titleBar.Size = new System.Drawing.Size(928, 36);
            this.titleBar.TabIndex = 13;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            this.titleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseMove);
            this.titleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseUp);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximize.Image = global::PPAI_CU36.Properties.Resources._8726465_window_maximize_icon;
            this.btnMaximize.Location = new System.Drawing.Point(878, 12);
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
            this.btnMinimize.Location = new System.Drawing.Point(856, 12);
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
            this.btnClosed.Location = new System.Drawing.Point(900, 12);
            this.btnClosed.Name = "btnClosed";
            this.btnClosed.Size = new System.Drawing.Size(16, 16);
            this.btnClosed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnClosed.TabIndex = 12;
            this.btnClosed.TabStop = false;
            this.btnClosed.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gdrRecursos
            // 
            this.gdrRecursos.AllowUserToAddRows = false;
            this.gdrRecursos.AllowUserToDeleteRows = false;
            this.gdrRecursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdrRecursos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tipoRecurso,
            this.numero,
            this.marca,
            this.modelo});
            this.gdrRecursos.Location = new System.Drawing.Point(481, 131);
            this.gdrRecursos.Name = "gdrRecursos";
            this.gdrRecursos.ReadOnly = true;
            this.gdrRecursos.Size = new System.Drawing.Size(413, 192);
            this.gdrRecursos.TabIndex = 15;
            this.gdrRecursos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdrRecursos_CellClick);
            // 
            // tipoRecurso
            // 
            this.tipoRecurso.HeaderText = "Tipo de recurso";
            this.tipoRecurso.Name = "tipoRecurso";
            this.tipoRecurso.ReadOnly = true;
            // 
            // numero
            // 
            this.numero.HeaderText = "NumeroRT";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Width = 70;
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            this.marca.ReadOnly = true;
            // 
            // modelo
            // 
            this.modelo.HeaderText = "Modelo";
            this.modelo.Name = "modelo";
            this.modelo.ReadOnly = true;
            // 
            // gdrTurnos
            // 
            this.gdrTurnos.AllowUserToAddRows = false;
            this.gdrTurnos.AllowUserToDeleteRows = false;
            this.gdrTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdrTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cientifico,
            this.Fecha});
            this.gdrTurnos.Location = new System.Drawing.Point(601, 338);
            this.gdrTurnos.Name = "gdrTurnos";
            this.gdrTurnos.ReadOnly = true;
            this.gdrTurnos.Size = new System.Drawing.Size(293, 192);
            this.gdrTurnos.TabIndex = 16;
            // 
            // Cientifico
            // 
            this.Cientifico.HeaderText = "Cientifico";
            this.Cientifico.Name = "Cientifico";
            this.Cientifico.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "FechayHoraInicio";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 150;
            // 
            // txtFechaFin
            // 
            this.txtFechaFin.Location = new System.Drawing.Point(234, 133);
            this.txtFechaFin.Mask = "00/00/0000";
            this.txtFechaFin.Name = "txtFechaFin";
            this.txtFechaFin.Size = new System.Drawing.Size(100, 20);
            this.txtFechaFin.TabIndex = 17;
            this.txtFechaFin.ValidatingType = typeof(System.DateTime);
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblFechaFin.Location = new System.Drawing.Point(56, 133);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(169, 18);
            this.lblFechaFin.TabIndex = 18;
            this.lblFechaFin.Text = "Fecha de fin prevista:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(253, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(399, 25);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ingreso a Manteniemiento Correctivo";
            // 
            // txtRazon
            // 
            this.txtRazon.Location = new System.Drawing.Point(234, 211);
            this.txtRazon.Multiline = true;
            this.txtRazon.Name = "txtRazon";
            this.txtRazon.Size = new System.Drawing.Size(158, 86);
            this.txtRazon.TabIndex = 20;
            // 
            // lblRazon
            // 
            this.lblRazon.AutoSize = true;
            this.lblRazon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRazon.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblRazon.Location = new System.Drawing.Point(25, 210);
            this.lblRazon.Name = "lblRazon";
            this.lblRazon.Size = new System.Drawing.Size(200, 18);
            this.lblRazon.TabIndex = 21;
            this.lblRazon.Text = "Razon de mantenimiento:";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIngresar.Location = new System.Drawing.Point(352, 131);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 22;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblNotificacion
            // 
            this.lblNotificacion.AutoSize = true;
            this.lblNotificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotificacion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNotificacion.Location = new System.Drawing.Point(64, 338);
            this.lblNotificacion.Name = "lblNotificacion";
            this.lblNotificacion.Size = new System.Drawing.Size(161, 18);
            this.lblNotificacion.TabIndex = 23;
            this.lblNotificacion.Text = "Tipo de notificacion:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdWhatsApp);
            this.panel1.Controls.Add(this.rdMail);
            this.panel1.Location = new System.Drawing.Point(234, 338);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 76);
            this.panel1.TabIndex = 24;
            // 
            // rdWhatsApp
            // 
            this.rdWhatsApp.AutoSize = true;
            this.rdWhatsApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdWhatsApp.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rdWhatsApp.Location = new System.Drawing.Point(24, 41);
            this.rdWhatsApp.Name = "rdWhatsApp";
            this.rdWhatsApp.Size = new System.Drawing.Size(96, 20);
            this.rdWhatsApp.TabIndex = 1;
            this.rdWhatsApp.TabStop = true;
            this.rdWhatsApp.Text = "WhatsApp";
            this.rdWhatsApp.UseVisualStyleBackColor = true;
            // 
            // rdMail
            // 
            this.rdMail.AutoSize = true;
            this.rdMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMail.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.rdMail.Location = new System.Drawing.Point(24, 15);
            this.rdMail.Name = "rdMail";
            this.rdMail.Size = new System.Drawing.Size(54, 20);
            this.rdMail.TabIndex = 0;
            this.rdMail.TabStop = true;
            this.rdMail.Text = "Mail";
            this.rdMail.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConfirmar.Location = new System.Drawing.Point(314, 455);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(120, 57);
            this.btnConfirmar.TabIndex = 25;
            this.btnConfirmar.Text = "Confirmar Registro";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnLimpiarCampos
            // 
            this.btnLimpiarCampos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarCampos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLimpiarCampos.Location = new System.Drawing.Point(107, 455);
            this.btnLimpiarCampos.Name = "btnLimpiarCampos";
            this.btnLimpiarCampos.Size = new System.Drawing.Size(118, 57);
            this.btnLimpiarCampos.TabIndex = 26;
            this.btnLimpiarCampos.Text = "Limpiar Campos";
            this.btnLimpiarCampos.UseVisualStyleBackColor = true;
            this.btnLimpiarCampos.Click += new System.EventHandler(this.btnLimpiarCampos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PPAI_CU36.Properties.Resources.logoMain1;
            this.pictureBox1.Location = new System.Drawing.Point(794, 55);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // CasoDeUso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(59)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(928, 581);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLimpiarCampos);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNotificacion);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lblRazon);
            this.Controls.Add(this.txtRazon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.txtFechaFin);
            this.Controls.Add(this.gdrTurnos);
            this.Controls.Add(this.gdrRecursos);
            this.Controls.Add(this.titleBar);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CasoDeUso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CasoDeUso";
            this.Load += new System.EventHandler(this.CasoDeUso_Load);
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClosed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdrRecursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdrTurnos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.PictureBox btnMaximize;
        private System.Windows.Forms.PictureBox btnMinimize;
        private System.Windows.Forms.PictureBox btnClosed;
        private System.Windows.Forms.DataGridView gdrRecursos;
        private System.Windows.Forms.DataGridView gdrTurnos;
        private System.Windows.Forms.MaskedTextBox txtFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRazon;
        private System.Windows.Forms.Label lblRazon;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblNotificacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdWhatsApp;
        private System.Windows.Forms.RadioButton rdMail;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnLimpiarCampos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoRecurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn modelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cientifico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    }
}