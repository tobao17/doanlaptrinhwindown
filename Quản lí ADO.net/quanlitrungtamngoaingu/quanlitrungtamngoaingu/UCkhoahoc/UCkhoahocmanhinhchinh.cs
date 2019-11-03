using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using quanlitrungtamngoaingu.UChethong;
using quanlitrungtamngoaingu.UChocvien;

namespace quanlitrungtamngoaingu.UCkhoahoc
{
    public partial class UCkhoahocmanhinhchinh : UserControl
    {
        public UCkhoahocmanhinhchinh()
        {
            InitializeComponent();
        }

        private void lablekhoahoc_Click(object sender, EventArgs e)
        {
            panelkhoahoc_MouseClick(null, null);
        }

        private void lablekhoahoc_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablekhoahoc_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void panelkhoahoc_MouseHover(object sender, EventArgs e)
        {

            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void panelkhoahoc_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void panelkhoahoc_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplkhoahoc.Controls.OfType<UserControl>())
            {
                mplkhoahoc.Controls.Remove(uc);
            }
          UCkhoahoc2 ucc = new UCkhoahoc2();
            ucc.Dock = DockStyle.Fill;
            mplkhoahoc.Controls.Add(ucc);
            mplkhoahoc.Controls[0].BringToFront();
        }

        private void ptbtrove_Click(object sender, EventArgs e)
        {
            PCmanhinhchinh mhc = new PCmanhinhchinh();
            mhc.Dock = DockStyle.Fill;
            Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
            Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            foreach (UCkhoahocmanhinhchinh plgiaovien in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCkhoahocmanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plgiaovien);
            }
        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelkhoahoc_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plphancong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelgiaoviennghiviec_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void mplgiaovien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
