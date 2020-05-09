namespace eVehicleDealership.WinUI.Oglasi
{
    partial class frmOglasi
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
            this.lblPretragaOglasa = new System.Windows.Forms.Label();
            this.txtKategorijaPretraga = new System.Windows.Forms.TextBox();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.dgvOglasi = new System.Windows.Forms.DataGridView();
            this.LblPretragaKategorija = new System.Windows.Forms.Label();
            this.LblPretragaKorisnik = new System.Windows.Forms.Label();
            this.txtKorisnikPretraga = new System.Windows.Forms.TextBox();
            this.LblProizvodjacPretraga = new System.Windows.Forms.Label();
            this.txtProizvodjacPretraga = new System.Windows.Forms.TextBox();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.txtNaslovPretraga = new System.Windows.Forms.TextBox();
            this.VoziloId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naslov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kategorija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proizvodjac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumPostavljanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Korisnik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lokacija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Istaknut = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOglasi)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPretragaOglasa
            // 
            this.lblPretragaOglasa.AutoSize = true;
            this.lblPretragaOglasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPretragaOglasa.Location = new System.Drawing.Point(601, 9);
            this.lblPretragaOglasa.Name = "lblPretragaOglasa";
            this.lblPretragaOglasa.Size = new System.Drawing.Size(140, 24);
            this.lblPretragaOglasa.TabIndex = 6;
            this.lblPretragaOglasa.Text = "Pretraga oglasa";
            // 
            // txtKategorijaPretraga
            // 
            this.txtKategorijaPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKategorijaPretraga.Location = new System.Drawing.Point(381, 42);
            this.txtKategorijaPretraga.Name = "txtKategorijaPretraga";
            this.txtKategorijaPretraga.Size = new System.Drawing.Size(206, 24);
            this.txtKategorijaPretraga.TabIndex = 5;
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrikazi.Location = new System.Drawing.Point(627, 58);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(75, 29);
            this.btnPrikazi.TabIndex = 4;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // dgvOglasi
            // 
            this.dgvOglasi.AllowUserToAddRows = false;
            this.dgvOglasi.AllowUserToDeleteRows = false;
            this.dgvOglasi.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.dgvOglasi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOglasi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VoziloId,
            this.Naslov,
            this.Kategorija,
            this.Proizvodjac,
            this.Model,
            this.Cijena,
            this.DatumPostavljanja,
            this.Korisnik,
            this.Lokacija,
            this.Istaknut});
            this.dgvOglasi.Location = new System.Drawing.Point(0, 116);
            this.dgvOglasi.Name = "dgvOglasi";
            this.dgvOglasi.ReadOnly = true;
            this.dgvOglasi.RowHeadersWidth = 51;
            this.dgvOglasi.RowTemplate.Height = 24;
            this.dgvOglasi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOglasi.Size = new System.Drawing.Size(1417, 471);
            this.dgvOglasi.TabIndex = 7;
            this.dgvOglasi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvOglasi_MouseDoubleClick);
            // 
            // LblPretragaKategorija
            // 
            this.LblPretragaKategorija.AutoSize = true;
            this.LblPretragaKategorija.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPretragaKategorija.Location = new System.Drawing.Point(284, 45);
            this.LblPretragaKategorija.Name = "LblPretragaKategorija";
            this.LblPretragaKategorija.Size = new System.Drawing.Size(74, 18);
            this.LblPretragaKategorija.TabIndex = 8;
            this.LblPretragaKategorija.Text = "Kategorija";
            // 
            // LblPretragaKorisnik
            // 
            this.LblPretragaKorisnik.AutoSize = true;
            this.LblPretragaKorisnik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPretragaKorisnik.Location = new System.Drawing.Point(284, 84);
            this.LblPretragaKorisnik.Name = "LblPretragaKorisnik";
            this.LblPretragaKorisnik.Size = new System.Drawing.Size(62, 18);
            this.LblPretragaKorisnik.TabIndex = 10;
            this.LblPretragaKorisnik.Text = "Korisnik";
            // 
            // txtKorisnikPretraga
            // 
            this.txtKorisnikPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKorisnikPretraga.Location = new System.Drawing.Point(381, 81);
            this.txtKorisnikPretraga.Name = "txtKorisnikPretraga";
            this.txtKorisnikPretraga.Size = new System.Drawing.Size(206, 24);
            this.txtKorisnikPretraga.TabIndex = 9;
            // 
            // LblProizvodjacPretraga
            // 
            this.LblProizvodjacPretraga.AutoSize = true;
            this.LblProizvodjacPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProizvodjacPretraga.Location = new System.Drawing.Point(730, 81);
            this.LblProizvodjacPretraga.Name = "LblProizvodjacPretraga";
            this.LblProizvodjacPretraga.Size = new System.Drawing.Size(83, 18);
            this.LblProizvodjacPretraga.TabIndex = 14;
            this.LblProizvodjacPretraga.Text = "Proizvođač";
            // 
            // txtProizvodjacPretraga
            // 
            this.txtProizvodjacPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProizvodjacPretraga.Location = new System.Drawing.Point(827, 78);
            this.txtProizvodjacPretraga.Name = "txtProizvodjacPretraga";
            this.txtProizvodjacPretraga.Size = new System.Drawing.Size(206, 24);
            this.txtProizvodjacPretraga.TabIndex = 13;
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaslov.Location = new System.Drawing.Point(730, 42);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(54, 18);
            this.lblNaslov.TabIndex = 12;
            this.lblNaslov.Text = "Naslov";
            // 
            // txtNaslovPretraga
            // 
            this.txtNaslovPretraga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNaslovPretraga.Location = new System.Drawing.Point(827, 39);
            this.txtNaslovPretraga.Name = "txtNaslovPretraga";
            this.txtNaslovPretraga.Size = new System.Drawing.Size(206, 24);
            this.txtNaslovPretraga.TabIndex = 11;
            // 
            // VoziloId
            // 
            this.VoziloId.DataPropertyName = "VoziloId";
            this.VoziloId.HeaderText = "VoziloId";
            this.VoziloId.MinimumWidth = 6;
            this.VoziloId.Name = "VoziloId";
            this.VoziloId.ReadOnly = true;
            this.VoziloId.Visible = false;
            this.VoziloId.Width = 90;
            // 
            // Naslov
            // 
            this.Naslov.DataPropertyName = "Naziv";
            this.Naslov.HeaderText = "Naslov";
            this.Naslov.MinimumWidth = 6;
            this.Naslov.Name = "Naslov";
            this.Naslov.ReadOnly = true;
            this.Naslov.Width = 320;
            // 
            // Kategorija
            // 
            this.Kategorija.DataPropertyName = "Kategorija";
            this.Kategorija.HeaderText = "Kategorija";
            this.Kategorija.MinimumWidth = 6;
            this.Kategorija.Name = "Kategorija";
            this.Kategorija.ReadOnly = true;
            this.Kategorija.Width = 112;
            // 
            // Proizvodjac
            // 
            this.Proizvodjac.DataPropertyName = "Proizvodjac";
            this.Proizvodjac.HeaderText = "Proizvođač";
            this.Proizvodjac.MinimumWidth = 6;
            this.Proizvodjac.Name = "Proizvodjac";
            this.Proizvodjac.ReadOnly = true;
            this.Proizvodjac.Width = 120;
            // 
            // Model
            // 
            this.Model.DataPropertyName = "Model";
            this.Model.HeaderText = "Model";
            this.Model.MinimumWidth = 6;
            this.Model.Name = "Model";
            this.Model.ReadOnly = true;
            this.Model.Width = 120;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.MinimumWidth = 6;
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            this.Cijena.Width = 90;
            // 
            // DatumPostavljanja
            // 
            this.DatumPostavljanja.DataPropertyName = "DatumPostavljanja";
            this.DatumPostavljanja.HeaderText = "Datum postavljanja";
            this.DatumPostavljanja.MinimumWidth = 6;
            this.DatumPostavljanja.Name = "DatumPostavljanja";
            this.DatumPostavljanja.ReadOnly = true;
            this.DatumPostavljanja.Width = 150;
            // 
            // Korisnik
            // 
            this.Korisnik.DataPropertyName = "Korisnik";
            this.Korisnik.HeaderText = "Korisnik";
            this.Korisnik.MinimumWidth = 6;
            this.Korisnik.Name = "Korisnik";
            this.Korisnik.ReadOnly = true;
            this.Korisnik.Width = 170;
            // 
            // Lokacija
            // 
            this.Lokacija.DataPropertyName = "Lokacija";
            this.Lokacija.HeaderText = "Lokacija";
            this.Lokacija.MinimumWidth = 6;
            this.Lokacija.Name = "Lokacija";
            this.Lokacija.ReadOnly = true;
            this.Lokacija.Width = 200;
            // 
            // Istaknut
            // 
            this.Istaknut.DataPropertyName = "Istaknuto";
            this.Istaknut.HeaderText = "Istaknut";
            this.Istaknut.MinimumWidth = 6;
            this.Istaknut.Name = "Istaknut";
            this.Istaknut.ReadOnly = true;
            this.Istaknut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Istaknut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Istaknut.Width = 80;
            // 
            // frmOglasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 588);
            this.Controls.Add(this.LblProizvodjacPretraga);
            this.Controls.Add(this.txtProizvodjacPretraga);
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.txtNaslovPretraga);
            this.Controls.Add(this.LblPretragaKorisnik);
            this.Controls.Add(this.txtKorisnikPretraga);
            this.Controls.Add(this.LblPretragaKategorija);
            this.Controls.Add(this.dgvOglasi);
            this.Controls.Add(this.lblPretragaOglasa);
            this.Controls.Add(this.txtKategorijaPretraga);
            this.Controls.Add(this.btnPrikazi);
            this.Name = "frmOglasi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oglasi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOglasi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOglasi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPretragaOglasa;
        private System.Windows.Forms.TextBox txtKategorijaPretraga;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.DataGridView dgvOglasi;
        private System.Windows.Forms.Label LblPretragaKategorija;
        private System.Windows.Forms.Label LblPretragaKorisnik;
        private System.Windows.Forms.TextBox txtKorisnikPretraga;
        private System.Windows.Forms.Label LblProizvodjacPretraga;
        private System.Windows.Forms.TextBox txtProizvodjacPretraga;
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.TextBox txtNaslovPretraga;
        private System.Windows.Forms.DataGridViewTextBoxColumn VoziloId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naslov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kategorija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proizvodjac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumPostavljanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Korisnik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lokacija;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Istaknut;
    }
}