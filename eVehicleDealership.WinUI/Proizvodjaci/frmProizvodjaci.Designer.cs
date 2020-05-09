namespace eVehicleDealership.WinUI.Proizvodjaci
{
    partial class frmProizvodjaci
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
            this.pbProizvodjac = new System.Windows.Forms.PictureBox();
            this.lblNazivProizvodjaca = new System.Windows.Forms.Label();
            this.txtNazivProizvodjaca = new System.Windows.Forms.TextBox();
            this.lblDrzavaProizvodjaca = new System.Windows.Forms.Label();
            this.cmbDrzavaProizvodjaca = new System.Windows.Forms.ComboBox();
            this.btnUcitajLogoProizvodjaca = new System.Windows.Forms.Button();
            this.btnSacuvajProizvodjaca = new System.Windows.Forms.Button();
            this.dgvProizvodjaci = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblInfo = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Logo = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pbProizvodjac)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodjaci)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pbProizvodjac
            // 
            this.pbProizvodjac.Image = global::eVehicleDealership.WinUI.Properties.Resources.imgPlaceholder;
            this.pbProizvodjac.Location = new System.Drawing.Point(265, 200);
            this.pbProizvodjac.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbProizvodjac.MinimumSize = new System.Drawing.Size(100, 100);
            this.pbProizvodjac.Name = "pbProizvodjac";
            this.pbProizvodjac.Size = new System.Drawing.Size(100, 100);
            this.pbProizvodjac.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProizvodjac.TabIndex = 148;
            this.pbProizvodjac.TabStop = false;
            // 
            // lblNazivProizvodjaca
            // 
            this.lblNazivProizvodjaca.AutoSize = true;
            this.lblNazivProizvodjaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNazivProizvodjaca.Location = new System.Drawing.Point(194, 22);
            this.lblNazivProizvodjaca.Name = "lblNazivProizvodjaca";
            this.lblNazivProizvodjaca.Size = new System.Drawing.Size(134, 18);
            this.lblNazivProizvodjaca.TabIndex = 149;
            this.lblNazivProizvodjaca.Text = "Naziv proizvođača:";
            // 
            // txtNazivProizvodjaca
            // 
            this.txtNazivProizvodjaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNazivProizvodjaca.Location = new System.Drawing.Point(197, 52);
            this.txtNazivProizvodjaca.Name = "txtNazivProizvodjaca";
            this.txtNazivProizvodjaca.Size = new System.Drawing.Size(245, 24);
            this.txtNazivProizvodjaca.TabIndex = 150;
            this.txtNazivProizvodjaca.Validating += new System.ComponentModel.CancelEventHandler(this.txtNazivProizvodjaca_Validating);
            // 
            // lblDrzavaProizvodjaca
            // 
            this.lblDrzavaProizvodjaca.AutoSize = true;
            this.lblDrzavaProizvodjaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDrzavaProizvodjaca.Location = new System.Drawing.Point(194, 107);
            this.lblDrzavaProizvodjaca.Name = "lblDrzavaProizvodjaca";
            this.lblDrzavaProizvodjaca.Size = new System.Drawing.Size(59, 18);
            this.lblDrzavaProizvodjaca.TabIndex = 151;
            this.lblDrzavaProizvodjaca.Text = "Država:";
            // 
            // cmbDrzavaProizvodjaca
            // 
            this.cmbDrzavaProizvodjaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDrzavaProizvodjaca.FormattingEnabled = true;
            this.cmbDrzavaProizvodjaca.Location = new System.Drawing.Point(197, 137);
            this.cmbDrzavaProizvodjaca.Name = "cmbDrzavaProizvodjaca";
            this.cmbDrzavaProizvodjaca.Size = new System.Drawing.Size(245, 26);
            this.cmbDrzavaProizvodjaca.TabIndex = 152;
            this.cmbDrzavaProizvodjaca.SelectedIndexChanged += new System.EventHandler(this.cmbDrzavaProizvodjaca_SelectedIndexChanged);
            this.cmbDrzavaProizvodjaca.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDrzavaProizvodjaca_Validating);
            // 
            // btnUcitajLogoProizvodjaca
            // 
            this.btnUcitajLogoProizvodjaca.Location = new System.Drawing.Point(248, 305);
            this.btnUcitajLogoProizvodjaca.Name = "btnUcitajLogoProizvodjaca";
            this.btnUcitajLogoProizvodjaca.Size = new System.Drawing.Size(133, 31);
            this.btnUcitajLogoProizvodjaca.TabIndex = 153;
            this.btnUcitajLogoProizvodjaca.Text = "Upload logo";
            this.btnUcitajLogoProizvodjaca.UseVisualStyleBackColor = true;
            this.btnUcitajLogoProizvodjaca.Click += new System.EventHandler(this.btnUcitajLogoProizvodjaca_Click);
            // 
            // btnSacuvajProizvodjaca
            // 
            this.btnSacuvajProizvodjaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSacuvajProizvodjaca.Location = new System.Drawing.Point(197, 369);
            this.btnSacuvajProizvodjaca.Name = "btnSacuvajProizvodjaca";
            this.btnSacuvajProizvodjaca.Size = new System.Drawing.Size(245, 52);
            this.btnSacuvajProizvodjaca.TabIndex = 154;
            this.btnSacuvajProizvodjaca.Text = "Sačuvaj";
            this.btnSacuvajProizvodjaca.UseVisualStyleBackColor = true;
            this.btnSacuvajProizvodjaca.Click += new System.EventHandler(this.btnSacuvajProizvodjaca_Click);
            // 
            // dgvProizvodjaci
            // 
            this.dgvProizvodjaci.AllowUserToAddRows = false;
            this.dgvProizvodjaci.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvProizvodjaci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProizvodjaci.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Naziv,
            this.Logo});
            this.dgvProizvodjaci.Location = new System.Drawing.Point(0, 452);
            this.dgvProizvodjaci.Name = "dgvProizvodjaci";
            this.dgvProizvodjaci.RowHeadersWidth = 51;
            this.dgvProizvodjaci.RowTemplate.Height = 100;
            this.dgvProizvodjaci.Size = new System.Drawing.Size(634, 269);
            this.dgvProizvodjaci.TabIndex = 155;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(26, 166);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(569, 18);
            this.lblInfo.TabIndex = 156;
            this.lblInfo.Text = "* Za pregled proizvođača iz specifične države, odabrati tu državu u padajućem men" +
    "iju.";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.MinimumWidth = 6;
            this.Naziv.Name = "Naziv";
            this.Naziv.Width = 282;
            // 
            // Logo
            // 
            this.Logo.DataPropertyName = "Logo";
            this.Logo.HeaderText = "Logo";
            this.Logo.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Logo.MinimumWidth = 6;
            this.Logo.Name = "Logo";
            this.Logo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Logo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Logo.Width = 282;
            // 
            // frmProizvodjaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 721);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.dgvProizvodjaci);
            this.Controls.Add(this.btnSacuvajProizvodjaca);
            this.Controls.Add(this.btnUcitajLogoProizvodjaca);
            this.Controls.Add(this.cmbDrzavaProizvodjaca);
            this.Controls.Add(this.lblDrzavaProizvodjaca);
            this.Controls.Add(this.txtNazivProizvodjaca);
            this.Controls.Add(this.lblNazivProizvodjaca);
            this.Controls.Add(this.pbProizvodjac);
            this.Name = "frmProizvodjaci";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proizvođači";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProizvodjaci_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbProizvodjac)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodjaci)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbProizvodjac;
        private System.Windows.Forms.Label lblNazivProizvodjaca;
        private System.Windows.Forms.TextBox txtNazivProizvodjaca;
        private System.Windows.Forms.Label lblDrzavaProizvodjaca;
        private System.Windows.Forms.ComboBox cmbDrzavaProizvodjaca;
        private System.Windows.Forms.Button btnUcitajLogoProizvodjaca;
        private System.Windows.Forms.Button btnSacuvajProizvodjaca;
        private System.Windows.Forms.DataGridView dgvProizvodjaci;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewImageColumn Logo;
    }
}