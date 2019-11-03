namespace quanlitrungtamngoaingu
{
    partial class Frmmain
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
            this.mcontainer = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // mcontainer
            // 
            this.mcontainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mcontainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mcontainer.HorizontalScrollbarBarColor = true;
            this.mcontainer.HorizontalScrollbarHighlightOnWheel = false;
            this.mcontainer.HorizontalScrollbarSize = 10;
            this.mcontainer.Location = new System.Drawing.Point(20, 60);
            this.mcontainer.Name = "mcontainer";
            this.mcontainer.Size = new System.Drawing.Size(1103, 457);
            this.mcontainer.TabIndex = 0;
            this.mcontainer.UseCustomBackColor = true;
            this.mcontainer.VerticalScrollbarBarColor = true;
            this.mcontainer.VerticalScrollbarHighlightOnWheel = false;
            this.mcontainer.VerticalScrollbarSize = 10;
            this.mcontainer.Paint += new System.Windows.Forms.PaintEventHandler(this.mcontainer_Paint);
            // 
            // Frmmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 557);
            this.Controls.Add(this.mcontainer);
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "Frmmain";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Quản lí trung tâm Ngoại Ngữ";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel mcontainer;
    }
}