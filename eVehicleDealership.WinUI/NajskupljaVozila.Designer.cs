namespace eVehicleDealership.WinUI
{
    partial class NajskupljaVozila
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.NajskupljaVozilaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._170073DataSet = new eVehicleDealership.WinUI._170073DataSet();
            this.LblKategorija = new System.Windows.Forms.Label();
            this.cmbKategorije = new System.Windows.Forms.ComboBox();
            this.BtnShow = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.NajskupljaVozilaTableAdapter = new eVehicleDealership.WinUI._170073DataSetTableAdapters.NajskupljaVozilaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.NajskupljaVozilaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._170073DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // NajskupljaVozilaBindingSource
            // 
            this.NajskupljaVozilaBindingSource.DataMember = "NajskupljaVozila";
            this.NajskupljaVozilaBindingSource.DataSource = this._170073DataSet;
            // 
            // _170073DataSet
            // 
            this._170073DataSet.DataSetName = "_170073DataSet";
            this._170073DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LblKategorija
            // 
            this.LblKategorija.AutoSize = true;
            this.LblKategorija.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblKategorija.Location = new System.Drawing.Point(12, 50);
            this.LblKategorija.Name = "LblKategorija";
            this.LblKategorija.Size = new System.Drawing.Size(240, 18);
            this.LblKategorija.TabIndex = 0;
            this.LblKategorija.Text = "Odabir kategorije [opcionalno]:";
            // 
            // cmbKategorije
            // 
            this.cmbKategorije.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbKategorije.FormattingEnabled = true;
            this.cmbKategorije.Location = new System.Drawing.Point(258, 46);
            this.cmbKategorije.Name = "cmbKategorije";
            this.cmbKategorije.Size = new System.Drawing.Size(140, 28);
            this.cmbKategorije.TabIndex = 1;
            this.cmbKategorije.SelectedIndexChanged += new System.EventHandler(this.cmbKategorije_SelectedIndexChanged);
            // 
            // BtnShow
            // 
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.Location = new System.Drawing.Point(443, 46);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(75, 28);
            this.BtnShow.TabIndex = 2;
            this.BtnShow.Text = "Prikaži";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.NajskupljaVozilaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eVehicleDealership.WinUI.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 94);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1080, 484);
            this.reportViewer1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(403, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Prikaz top 10 najskupljih vozila";
            // 
            // NajskupljaVozilaTableAdapter
            // 
            this.NajskupljaVozilaTableAdapter.ClearBeforeFill = true;
            // 
            // NajskupljaVozila
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 590);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.BtnShow);
            this.Controls.Add(this.cmbKategorije);
            this.Controls.Add(this.LblKategorija);
            this.Name = "NajskupljaVozila";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top 10 najskupljih vozila na sistemu";
            this.Load += new System.EventHandler(this.NajskupljaVozila_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NajskupljaVozilaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._170073DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblKategorija;
        private System.Windows.Forms.ComboBox cmbKategorije;
        private System.Windows.Forms.Button BtnShow;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource NajskupljaVozilaBindingSource;
        private _170073DataSet _170073DataSet;
        private _170073DataSetTableAdapters.NajskupljaVozilaTableAdapter NajskupljaVozilaTableAdapter;
    }
}