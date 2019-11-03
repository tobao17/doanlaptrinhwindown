namespace quanlitrungtamngoaingu.UCcaidat
{
    partial class UCdoimatkhau
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
            this.pldoimatkhau = new System.Windows.Forms.Panel();
            this.btntimkiem = new MetroFramework.Controls.MetroButton();
            this.txtnewpass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtoldpass = new System.Windows.Forms.TextBox();
            this.txttendangnhap = new System.Windows.Forms.TextBox();
            this.pldoimatkhau.SuspendLayout();
            this.SuspendLayout();
            // 
            // pldoimatkhau
            // 
            this.pldoimatkhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(34)))), ((int)(((byte)(75)))));
            this.pldoimatkhau.Controls.Add(this.txtnewpass);
            this.pldoimatkhau.Controls.Add(this.btntimkiem);
            this.pldoimatkhau.Controls.Add(this.label4);
            this.pldoimatkhau.Controls.Add(this.label1);
            this.pldoimatkhau.Controls.Add(this.label2);
            this.pldoimatkhau.Controls.Add(this.txtoldpass);
            this.pldoimatkhau.Controls.Add(this.txttendangnhap);
            this.pldoimatkhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pldoimatkhau.Location = new System.Drawing.Point(0, 0);
            this.pldoimatkhau.Name = "pldoimatkhau";
            this.pldoimatkhau.Size = new System.Drawing.Size(794, 417);
            this.pldoimatkhau.TabIndex = 2;
            this.pldoimatkhau.Paint += new System.Windows.Forms.PaintEventHandler(this.pldoimatkhau_Paint);
            // 
            // btntimkiem
            // 
            this.btntimkiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntimkiem.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btntimkiem.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btntimkiem.ForeColor = System.Drawing.Color.White;
            this.btntimkiem.Location = new System.Drawing.Point(478, 242);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(100, 30);
            this.btntimkiem.TabIndex = 156;
            this.btntimkiem.Text = "Cập Nhật";
            this.btntimkiem.UseCustomBackColor = true;
            this.btntimkiem.UseCustomForeColor = true;
            this.btntimkiem.UseSelectable = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // txtnewpass
            // 
            this.txtnewpass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewpass.Location = new System.Drawing.Point(271, 176);
            this.txtnewpass.Multiline = true;
            this.txtnewpass.Name = "txtnewpass";
            this.txtnewpass.Size = new System.Drawing.Size(307, 25);
            this.txtnewpass.TabIndex = 169;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(139, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 137;
            this.label4.Text = "Mật khẩu mới:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(139, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 130;
            this.label1.Text = "Mật Khẩu cũ:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(139, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 131;
            this.label2.Text = "Tên Đăng Nhập:";
            // 
            // txtoldpass
            // 
            this.txtoldpass.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtoldpass.Location = new System.Drawing.Point(271, 125);
            this.txtoldpass.Multiline = true;
            this.txtoldpass.Name = "txtoldpass";
            this.txtoldpass.Size = new System.Drawing.Size(307, 25);
            this.txtoldpass.TabIndex = 136;
            this.txtoldpass.Leave += new System.EventHandler(this.txtoldpass_Leave);
            // 
            // txttendangnhap
            // 
            this.txttendangnhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttendangnhap.Location = new System.Drawing.Point(271, 76);
            this.txttendangnhap.Multiline = true;
            this.txttendangnhap.Name = "txttendangnhap";
            this.txttendangnhap.Size = new System.Drawing.Size(307, 25);
            this.txttendangnhap.TabIndex = 135;
            // 
            // UCdoimatkhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pldoimatkhau);
            this.Name = "UCdoimatkhau";
            this.Size = new System.Drawing.Size(794, 417);
            this.pldoimatkhau.ResumeLayout(false);
            this.pldoimatkhau.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pldoimatkhau;
        private System.Windows.Forms.TextBox txtnewpass;
        private MetroFramework.Controls.MetroButton btntimkiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtoldpass;
        private System.Windows.Forms.TextBox txttendangnhap;
    }
}
