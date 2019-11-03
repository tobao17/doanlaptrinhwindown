using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlitrungtamngoaingu.UChethong;
using MetroFramework.Controls;
using MetroFramework;
using System.Threading;
namespace quanlitrungtamngoaingu.UChocvien
{
    public partial class UCHocvienmanhinhchinh : UserControl
    {
        public UCHocvienmanhinhchinh()
        {
            InitializeComponent();
        }

        private void lbldsgv_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lbldsgv_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);

        }

        private void lbldsgv_Click(object sender, EventArgs e)
        {
            paneldanhsachhocvien_MouseClick(null, null);

        }

        private void lbphanconggiangday_Click(object sender, EventArgs e)
        {
            paneldiemso_MouseClick(null, null);

        }

        private void lbphanconggiangday_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);

        }

        private void lbphanconggiangday_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);

        }

        private void labelgiaoviennghi_Click(object sender, EventArgs e)
        {
            panelKhoahoc_MouseClick(null, null);

        }

        private void labelgiaoviennghi_MouseHover(object sender, EventArgs e)
        {

            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);

        }

        private void labelgiaoviennghi_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);

        }

        private void paneldanhsachhocvien_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);

        }

        private void paneldanhsachhocvien_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);

        }

        private void paneldiemso_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void paneldiemso_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);

        }

        private void panellichhoc_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);

        }

        private void panellichhoc_MouseLeave(object sender, EventArgs e)
        {

            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);

        }

        private void ptbtrove_Click(object sender, EventArgs e)
        {
            PCmanhinhchinh mhc = new PCmanhinhchinh();
            mhc.Dock = DockStyle.Fill;
            Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
            Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            foreach (UCHocvienmanhinhchinh plhocvien in  Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCHocvienmanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plhocvien);
            }
        }

        private void paneldiemso_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in plhocvien.Controls.OfType<UserControl>())
            {
               plhocvien.Controls.Remove(uc);
            }
           UCdiemso ucc = new UCdiemso();
            ucc.Dock = DockStyle.Fill;
           plhocvien.Controls.Add(ucc);
            plhocvien.Controls[0].BringToFront();

        }

        private void paneldanhsachhocvien_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in plhocvien.Controls.OfType<UserControl>())
            {
                plhocvien.Controls.Remove(uc);
            }
            UCDanhsachhocvien ucc = new UCDanhsachhocvien();
            ucc.Dock = DockStyle.Fill;
            plhocvien.Controls.Add(ucc);
            plhocvien.Controls[0].BringToFront();
        }

      

        private void panelKhoahoc_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in plhocvien.Controls.OfType<UserControl>())
            {
                plhocvien.Controls.Remove(uc);
            }
            UCkhoahoc2 ucc = new UCkhoahoc2();
            ucc.Dock = DockStyle.Fill;
            plhocvien.Controls.Add(ucc);
            plhocvien.Controls[0].BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelKhoahoc_Paint(object sender, PaintEventArgs e)
        {

        }

        private void paneldiemso_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void paneldanhsachhocvien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mplgiaovien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plhocsinh_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
