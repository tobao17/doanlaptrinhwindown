namespace quanlitrungtamngoaingu.UCThongke
{
    partial class UserControlthongkegiaovien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.DataSetTT = new quanlitrungtamngoaingu.UCThongke.DataSetTT();
            this.GIAOVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GIAOVIENTableAdapter = new quanlitrungtamngoaingu.UCThongke.DataSetTTTableAdapters.GIAOVIENTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GIAOVIENBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataSetTT
            // 
            this.DataSetTT.DataSetName = "DataSetTT";
            this.DataSetTT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // GIAOVIENBindingSource
            // 
            this.GIAOVIENBindingSource.DataMember = "GIAOVIEN";
            this.GIAOVIENBindingSource.DataSource = this.DataSetTT;
            // 
            // GIAOVIENTableAdapter
            // 
            this.GIAOVIENTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 476);
            this.panel1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.GIAOVIENBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "quanlitrungtamngoaingu.UCThongke.ReportGV.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(957, 476);
            this.reportViewer1.TabIndex = 0;
            // 
            // UserControlthongkegiaovien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UserControlthongkegiaovien";
            this.Size = new System.Drawing.Size(957, 476);
            this.Load += new System.EventHandler(this.UserControlthongkegiaovien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSetTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GIAOVIENBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource GIAOVIENBindingSource;
        private DataSetTT DataSetTT;
        private DataSetTTTableAdapters.GIAOVIENTableAdapter GIAOVIENTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
