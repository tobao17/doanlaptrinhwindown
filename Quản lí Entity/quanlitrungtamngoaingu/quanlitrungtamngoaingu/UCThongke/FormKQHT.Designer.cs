namespace quanlitrungtamngoaingu.UCThongke
{
    partial class FormKQHT
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
            this.KETQUABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetTT = new quanlitrungtamngoaingu.UCThongke.DataSetTT();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.KETQUATableAdapter = new quanlitrungtamngoaingu.UCThongke.DataSetTTTableAdapters.KETQUATableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.KETQUABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetTT)).BeginInit();
            this.SuspendLayout();
            // 
            // KETQUABindingSource
            // 
            this.KETQUABindingSource.DataMember = "KETQUA";
            this.KETQUABindingSource.DataSource = this.DataSetTT;
            // 
            // DataSetTT
            // 
            this.DataSetTT.DataSetName = "DataSetTT";
            this.DataSetTT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.KETQUABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "quanlitrungtamngoaingu.UCThongke.ReportKQ.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(975, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // KETQUATableAdapter
            // 
            this.KETQUATableAdapter.ClearBeforeFill = true;
            // 
            // FormKQHT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(975, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormKQHT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormKQHT";
            this.Load += new System.EventHandler(this.FormKQHT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KETQUABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetTT)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource KETQUABindingSource;
        private DataSetTT DataSetTT;
        private DataSetTTTableAdapters.KETQUATableAdapter KETQUATableAdapter;
    }
}