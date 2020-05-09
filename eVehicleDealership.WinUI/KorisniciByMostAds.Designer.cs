namespace eVehicleDealership.WinUI
{
    partial class KorisniciByMostAds
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
            this.LblInfo = new System.Windows.Forms.Label();
            this.BtnShow = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this._170073DataSet = new eVehicleDealership.WinUI._170073DataSet();
            this.KorisniciSaNajviseOglasaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KorisniciSaNajviseOglasaTableAdapter = new eVehicleDealership.WinUI._170073DataSetTableAdapters.KorisniciSaNajviseOglasaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this._170073DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KorisniciSaNajviseOglasaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.Location = new System.Drawing.Point(162, 18);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(491, 25);
            this.LblInfo.TabIndex = 0;
            this.LblInfo.Text = "Prikaz top 10 korisnika sa najvećim brojem oglasa";
            // 
            // BtnShow
            // 
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.Location = new System.Drawing.Point(325, 55);
            this.BtnShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(105, 37);
            this.BtnShow.TabIndex = 1;
            this.BtnShow.Text = "Prikaži";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.KorisniciSaNajviseOglasaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eVehicleDealership.WinUI.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(13, 140);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(718, 412);
            this.reportViewer1.TabIndex = 2;
            // 
            // _170073DataSet
            // 
            this._170073DataSet.DataSetName = "_170073DataSet";
            this._170073DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // KorisniciSaNajviseOglasaBindingSource
            // 
            this.KorisniciSaNajviseOglasaBindingSource.DataMember = "KorisniciSaNajviseOglasa";
            this.KorisniciSaNajviseOglasaBindingSource.DataSource = this._170073DataSet;
            // 
            // KorisniciSaNajviseOglasaTableAdapter
            // 
            this.KorisniciSaNajviseOglasaTableAdapter.ClearBeforeFill = true;
            // 
            // KorisniciByMostAds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 564);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.BtnShow);
            this.Controls.Add(this.LblInfo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "KorisniciByMostAds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top 10 korisnika";
            ((System.ComponentModel.ISupportInitialize)(this._170073DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KorisniciSaNajviseOglasaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Button BtnShow;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource KorisniciSaNajviseOglasaBindingSource;
        private _170073DataSet _170073DataSet;
        private _170073DataSetTableAdapters.KorisniciSaNajviseOglasaTableAdapter KorisniciSaNajviseOglasaTableAdapter;
    }
}