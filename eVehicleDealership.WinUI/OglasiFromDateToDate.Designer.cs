namespace eVehicleDealership.WinUI
{
    partial class OglasiFromDateToDate
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.OglasiByDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._170073DataSet = new eVehicleDealership.WinUI._170073DataSet();
            this.DatumDo = new System.Windows.Forms.DateTimePicker();
            this.LblDo = new System.Windows.Forms.Label();
            this.BtnShow = new System.Windows.Forms.Button();
            this.DatumOd = new System.Windows.Forms.DateTimePicker();
            this.LblOd = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OglasiByDateTableAdapter = new eVehicleDealership.WinUI._170073DataSetTableAdapters.OglasiByDateTableAdapter();
            this.LblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OglasiByDateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._170073DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // OglasiByDateBindingSource
            // 
            this.OglasiByDateBindingSource.DataMember = "OglasiByDate";
            this.OglasiByDateBindingSource.DataSource = this._170073DataSet;
            // 
            // _170073DataSet
            // 
            this._170073DataSet.DataSetName = "_170073DataSet";
            this._170073DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DatumDo
            // 
            this.DatumDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatumDo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatumDo.Location = new System.Drawing.Point(275, 63);
            this.DatumDo.Name = "DatumDo";
            this.DatumDo.Size = new System.Drawing.Size(146, 27);
            this.DatumDo.TabIndex = 12;
            // 
            // LblDo
            // 
            this.LblDo.AutoSize = true;
            this.LblDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDo.Location = new System.Drawing.Point(234, 66);
            this.LblDo.Name = "LblDo";
            this.LblDo.Size = new System.Drawing.Size(35, 18);
            this.LblDo.TabIndex = 11;
            this.LblDo.Text = "Do:";
            // 
            // BtnShow
            // 
            this.BtnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShow.Location = new System.Drawing.Point(476, 63);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(75, 27);
            this.BtnShow.TabIndex = 10;
            this.BtnShow.Text = "Prikaži";
            this.BtnShow.UseVisualStyleBackColor = true;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // DatumOd
            // 
            this.DatumOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DatumOd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DatumOd.Location = new System.Drawing.Point(67, 63);
            this.DatumOd.Name = "DatumOd";
            this.DatumOd.Size = new System.Drawing.Size(146, 27);
            this.DatumOd.TabIndex = 9;
            // 
            // LblOd
            // 
            this.LblOd.AutoSize = true;
            this.LblOd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblOd.Location = new System.Drawing.Point(26, 66);
            this.LblOd.Name = "LblOd";
            this.LblOd.Size = new System.Drawing.Size(35, 18);
            this.LblOd.TabIndex = 8;
            this.LblOd.Text = "Od:";
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.OglasiByDateBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "eVehicleDealership.WinUI.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 119);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1059, 435);
            this.reportViewer1.TabIndex = 13;
            // 
            // OglasiByDateTableAdapter
            // 
            this.OglasiByDateTableAdapter.ClearBeforeFill = true;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInfo.Location = new System.Drawing.Point(309, 9);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(512, 25);
            this.LblInfo.TabIndex = 14;
            this.LblInfo.Text = "Izvještaj o postavljenim oglasima za određeni period";
            // 
            // OglasiFromDateToDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 566);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.DatumDo);
            this.Controls.Add(this.LblDo);
            this.Controls.Add(this.BtnShow);
            this.Controls.Add(this.DatumOd);
            this.Controls.Add(this.LblOd);
            this.Name = "OglasiFromDateToDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Oglasi postavljeni u određenom vremenskom periodu";
            ((System.ComponentModel.ISupportInitialize)(this.OglasiByDateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._170073DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DatumDo;
        private System.Windows.Forms.Label LblDo;
        private System.Windows.Forms.Button BtnShow;
        private System.Windows.Forms.DateTimePicker DatumOd;
        private System.Windows.Forms.Label LblOd;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OglasiByDateBindingSource;
        private _170073DataSet _170073DataSet;
        private _170073DataSetTableAdapters.OglasiByDateTableAdapter OglasiByDateTableAdapter;
        private System.Windows.Forms.Label LblInfo;
    }
}