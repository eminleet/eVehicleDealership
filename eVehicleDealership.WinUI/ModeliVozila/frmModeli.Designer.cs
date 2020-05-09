namespace eVehicleDealership.WinUI.ModeliVozila
{
    partial class frmModeli
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
            this.components = new System.ComponentModel.Container();
            this.lblInfo = new System.Windows.Forms.Label();
            this.cmbProizvodjaci = new System.Windows.Forms.ComboBox();
            this.lblProizvodjac = new System.Windows.Forms.Label();
            this.txtNazivModela = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.dgvModeli = new System.Windows.Forms.DataGridView();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proizvodjac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModeli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(149, 94);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(615, 18);
            this.lblInfo.TabIndex = 161;
            this.lblInfo.Text = "* Za pregled svih modela određenog proizvođača, odabrati proizvođača u padajućem " +
    "meniju.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbProizvodjaci
            // 
            this.cmbProizvodjaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProizvodjaci.FormattingEnabled = true;
            this.cmbProizvodjaci.Location = new System.Drawing.Point(290, 54);
            this.cmbProizvodjaci.Name = "cmbProizvodjaci";
            this.cmbProizvodjaci.Size = new System.Drawing.Size(245, 26);
            this.cmbProizvodjaci.TabIndex = 160;
            this.cmbProizvodjaci.SelectedIndexChanged += new System.EventHandler(this.cmbProizvodjaci_SelectedIndexChanged);
            this.cmbProizvodjaci.Validating += new System.ComponentModel.CancelEventHandler(this.cmbProizvodjaci_Validating);
            // 
            // lblProizvodjac
            // 
            this.lblProizvodjac.AutoSize = true;
            this.lblProizvodjac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProizvodjac.Location = new System.Drawing.Point(287, 24);
            this.lblProizvodjac.Name = "lblProizvodjac";
            this.lblProizvodjac.Size = new System.Drawing.Size(87, 18);
            this.lblProizvodjac.TabIndex = 159;
            this.lblProizvodjac.Text = "Proizvođač:";
            // 
            // txtNazivModela
            // 
            this.txtNazivModela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNazivModela.Location = new System.Drawing.Point(290, 171);
            this.txtNazivModela.Name = "txtNazivModela";
            this.txtNazivModela.Size = new System.Drawing.Size(245, 24);
            this.txtNazivModela.TabIndex = 158;
            this.txtNazivModela.Validating += new System.ComponentModel.CancelEventHandler(this.txtNazivModela_Validating);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Location = new System.Drawing.Point(287, 141);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(102, 18);
            this.lblModel.TabIndex = 157;
            this.lblModel.Text = "Naziv modela:";
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvaj.Location = new System.Drawing.Point(339, 224);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(143, 33);
            this.btnSacuvaj.TabIndex = 162;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // dgvModeli
            // 
            this.dgvModeli.AllowUserToAddRows = false;
            this.dgvModeli.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvModeli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModeli.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Proizvodjac});
            this.dgvModeli.Location = new System.Drawing.Point(225, 275);
            this.dgvModeli.Name = "dgvModeli";
            this.dgvModeli.RowHeadersWidth = 51;
            this.dgvModeli.RowTemplate.Height = 24;
            this.dgvModeli.Size = new System.Drawing.Size(371, 413);
            this.dgvModeli.TabIndex = 163;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.Width = 150;
            // 
            // Proizvodjac
            // 
            this.Proizvodjac.DataPropertyName = "Proizvodjac";
            this.Proizvodjac.HeaderText = "Proizvođač";
            this.Proizvodjac.MinimumWidth = 6;
            this.Proizvodjac.Name = "Proizvodjac";
            this.Proizvodjac.Width = 150;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmModeli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.dgvModeli);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.cmbProizvodjaci);
            this.Controls.Add(this.lblProizvodjac);
            this.Controls.Add(this.txtNazivModela);
            this.Controls.Add(this.lblModel);
            this.Name = "frmModeli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modeli vozila";
            this.Load += new System.EventHandler(this.frmModeli_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModeli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ComboBox cmbProizvodjaci;
        private System.Windows.Forms.Label lblProizvodjac;
        private System.Windows.Forms.TextBox txtNazivModela;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.DataGridView dgvModeli;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proizvodjac;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}