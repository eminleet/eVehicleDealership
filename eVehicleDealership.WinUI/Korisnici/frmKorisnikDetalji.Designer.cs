namespace eVehicleDealership.WinUI.Korisnici
{
    partial class frmKorisnikDetalji
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
            this.txtIme = new System.Windows.Forms.TextBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.lblLozinka = new System.Windows.Forms.Label();
            this.txtLozinka = new System.Windows.Forms.TextBox();
            this.lblLozinkaPotvrda = new System.Windows.Forms.Label();
            this.txtLozinkaPotvrda = new System.Windows.Forms.TextBox();
            this.btnSnimi = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.clbUloge = new System.Windows.Forms.CheckedListBox();
            this.lblKorisnikUloge = new System.Windows.Forms.Label();
            this.pbSlikaKorisnika = new System.Windows.Forms.PictureBox();
            this.btnUploadSliku = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaKorisnika)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(14, 59);
            this.txtIme.Margin = new System.Windows.Forms.Padding(4);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(360, 27);
            this.txtIme.TabIndex = 0;
            this.txtIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtIme_Validating);
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(14, 32);
            this.lblIme.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(36, 19);
            this.lblIme.TabIndex = 1;
            this.lblIme.Text = "Ime";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(13, 112);
            this.lblPrezime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(69, 19);
            this.lblPrezime.TabIndex = 3;
            this.lblPrezime.Text = "Prezime";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(13, 139);
            this.txtPrezime.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(360, 27);
            this.txtPrezime.TabIndex = 2;
            this.txtPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrezime_Validating);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(14, 190);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(49, 19);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(14, 217);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(360, 27);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(14, 271);
            this.lblTelefon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(60, 19);
            this.lblTelefon.TabIndex = 7;
            this.lblTelefon.Text = "Telefon";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(14, 298);
            this.txtTelefon.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(360, 27);
            this.txtTelefon.TabIndex = 6;
            this.txtTelefon.Validating += new System.ComponentModel.CancelEventHandler(this.txtTelefon_Validating);
            // 
            // lblLozinka
            // 
            this.lblLozinka.AutoSize = true;
            this.lblLozinka.Location = new System.Drawing.Point(13, 354);
            this.lblLozinka.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLozinka.Name = "lblLozinka";
            this.lblLozinka.Size = new System.Drawing.Size(65, 19);
            this.lblLozinka.TabIndex = 9;
            this.lblLozinka.Text = "Lozinka";
            // 
            // txtLozinka
            // 
            this.txtLozinka.Location = new System.Drawing.Point(13, 381);
            this.txtLozinka.Margin = new System.Windows.Forms.Padding(4);
            this.txtLozinka.Name = "txtLozinka";
            this.txtLozinka.PasswordChar = '*';
            this.txtLozinka.Size = new System.Drawing.Size(360, 27);
            this.txtLozinka.TabIndex = 8;
            this.txtLozinka.Validating += new System.ComponentModel.CancelEventHandler(this.txtLozinka_Validating);
            // 
            // lblLozinkaPotvrda
            // 
            this.lblLozinkaPotvrda.AutoSize = true;
            this.lblLozinkaPotvrda.Location = new System.Drawing.Point(13, 435);
            this.lblLozinkaPotvrda.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLozinkaPotvrda.Name = "lblLozinkaPotvrda";
            this.lblLozinkaPotvrda.Size = new System.Drawing.Size(123, 19);
            this.lblLozinkaPotvrda.TabIndex = 11;
            this.lblLozinkaPotvrda.Text = "Lozinka potvrda";
            // 
            // txtLozinkaPotvrda
            // 
            this.txtLozinkaPotvrda.Location = new System.Drawing.Point(13, 462);
            this.txtLozinkaPotvrda.Margin = new System.Windows.Forms.Padding(4);
            this.txtLozinkaPotvrda.Name = "txtLozinkaPotvrda";
            this.txtLozinkaPotvrda.PasswordChar = '*';
            this.txtLozinkaPotvrda.Size = new System.Drawing.Size(360, 27);
            this.txtLozinkaPotvrda.TabIndex = 10;
            this.txtLozinkaPotvrda.Validating += new System.ComponentModel.CancelEventHandler(this.txtLozinkaPotvrda_Validating);
            // 
            // btnSnimi
            // 
            this.btnSnimi.Location = new System.Drawing.Point(13, 517);
            this.btnSnimi.Margin = new System.Windows.Forms.Padding(4);
            this.btnSnimi.Name = "btnSnimi";
            this.btnSnimi.Size = new System.Drawing.Size(873, 38);
            this.btnSnimi.TabIndex = 12;
            this.btnSnimi.Text = "Sačuvaj";
            this.btnSnimi.UseVisualStyleBackColor = true;
            this.btnSnimi.Click += new System.EventHandler(this.btnSnimi_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // clbUloge
            // 
            this.clbUloge.FormattingEnabled = true;
            this.clbUloge.Location = new System.Drawing.Point(522, 59);
            this.clbUloge.Margin = new System.Windows.Forms.Padding(4);
            this.clbUloge.Name = "clbUloge";
            this.clbUloge.Size = new System.Drawing.Size(364, 114);
            this.clbUloge.TabIndex = 13;
            // 
            // lblKorisnikUloge
            // 
            this.lblKorisnikUloge.AutoSize = true;
            this.lblKorisnikUloge.Location = new System.Drawing.Point(518, 32);
            this.lblKorisnikUloge.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKorisnikUloge.Name = "lblKorisnikUloge";
            this.lblKorisnikUloge.Size = new System.Drawing.Size(135, 19);
            this.lblKorisnikUloge.TabIndex = 14;
            this.lblKorisnikUloge.Text = "Korisničke uloge:";
            // 
            // pbSlikaKorisnika
            // 
            this.pbSlikaKorisnika.Image = global::eVehicleDealership.WinUI.Properties.Resources.imgPlaceholder;
            this.pbSlikaKorisnika.Location = new System.Drawing.Point(588, 226);
            this.pbSlikaKorisnika.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbSlikaKorisnika.MinimumSize = new System.Drawing.Size(100, 100);
            this.pbSlikaKorisnika.Name = "pbSlikaKorisnika";
            this.pbSlikaKorisnika.Size = new System.Drawing.Size(200, 200);
            this.pbSlikaKorisnika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlikaKorisnika.TabIndex = 149;
            this.pbSlikaKorisnika.TabStop = false;
            // 
            // btnUploadSliku
            // 
            this.btnUploadSliku.Location = new System.Drawing.Point(621, 458);
            this.btnUploadSliku.Name = "btnUploadSliku";
            this.btnUploadSliku.Size = new System.Drawing.Size(150, 31);
            this.btnUploadSliku.TabIndex = 154;
            this.btnUploadSliku.Text = "Upload sliku";
            this.btnUploadSliku.UseVisualStyleBackColor = true;
            this.btnUploadSliku.Click += new System.EventHandler(this.btnUploadSliku_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // frmKorisnikDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 591);
            this.Controls.Add(this.btnUploadSliku);
            this.Controls.Add(this.pbSlikaKorisnika);
            this.Controls.Add(this.lblKorisnikUloge);
            this.Controls.Add(this.clbUloge);
            this.Controls.Add(this.btnSnimi);
            this.Controls.Add(this.lblLozinkaPotvrda);
            this.Controls.Add(this.txtLozinkaPotvrda);
            this.Controls.Add(this.lblLozinka);
            this.Controls.Add(this.txtLozinka);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.txtIme);
            this.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKorisnikDetalji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Korisnički detalji";
            this.Load += new System.EventHandler(this.frmKorisnikDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaKorisnika)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblLozinka;
        private System.Windows.Forms.TextBox txtLozinka;
        private System.Windows.Forms.Label lblLozinkaPotvrda;
        private System.Windows.Forms.TextBox txtLozinkaPotvrda;
        private System.Windows.Forms.Button btnSnimi;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label lblKorisnikUloge;
        private System.Windows.Forms.CheckedListBox clbUloge;
        private System.Windows.Forms.PictureBox pbSlikaKorisnika;
        private System.Windows.Forms.Button btnUploadSliku;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}