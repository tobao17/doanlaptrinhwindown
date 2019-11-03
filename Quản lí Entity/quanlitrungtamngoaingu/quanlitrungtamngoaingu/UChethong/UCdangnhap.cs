using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using quanlitrungtamngoaingu.UCcaidat;
using quanlitrungtamngoaingu.businesslogiclayer;
namespace quanlitrungtamngoaingu.UChethong
{
    public partial class UCdangnhap : UserControl
    {
        public UCdangnhap()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (doimatkhau.kiemtra(txtusername.Text,txtpass.Text))
            {
                foreach (UCdangnhap aa in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCdangnhap>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(aa);
                }
                UCprogressbar ucc = new UCprogressbar();
                ucc.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(ucc);
                for (int i = 0; i <= 1000; i++)
                {
                    Thread.Sleep(5);
                    ucc.giatri = i * 100 / 1000;
                    ucc.hienthi = (i * 100 / 1000).ToString();
                }
                foreach (UCprogressbar aa in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCprogressbar>())
                {
                    Frmmain.Frmain.mpanelcontainer.Controls.Remove(aa);
                }
                //  ucc.Controls.Remove(ucc);

                PCmanhinhchinh mhc = new PCmanhinhchinh();
                mhc.Dock = DockStyle.Fill;
                Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
                Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            }
          else
            {
                MessageBox.Show("Tên đăng nhập/Mật Khẩu bạn nhập không đúng!", "Thông Báo",
               MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtusername.ResetText();
                txtpass.ResetText();
                txtusername.Focus();
            }

        }

        private void txtusername_Click(object sender, EventArgs e)
        {
            txtusername.ResetText();
            txtpass.ResetText();
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
