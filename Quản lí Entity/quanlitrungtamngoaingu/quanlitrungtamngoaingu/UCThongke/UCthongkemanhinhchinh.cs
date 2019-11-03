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

namespace quanlitrungtamngoaingu.UCThongke
{
    public partial class UCthongkemanhinhchinh : UserControl
    {
        public UCthongkemanhinhchinh()
        {
            InitializeComponent();
        }

        private void ptbtrove_Click(object sender, EventArgs e)
        {
            PCmanhinhchinh mhc = new PCmanhinhchinh();
            mhc.Dock = DockStyle.Fill;
            Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
            Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            foreach (UCthongkemanhinhchinh plgiaovien in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCthongkemanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plgiaovien);
            }
        }

        private void lablegiaovien_Click(object sender, EventArgs e)
        {
            panelgiaovien_MouseClick(null, null);
        }

        private void lablegiaovien_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablegiaovien_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
           //panelgiaovien_MouseLeave(null, null);
        }

        private void panelgiaovien_MouseClick(object sender, MouseEventArgs e)
        {
            //foreach (UserControl uc in mplthongke.Controls.OfType<UserControl>())
            //{
            //    mplthongke.Controls.Remove(uc);
            //}

            //UserControlthongkegiaovien ucc = new UserControlthongkegiaovien();
            //ucc.Dock = DockStyle.Fill;
            //mplthongke.Controls.Add(ucc);
            //mplthongke.Controls[0].BringToFront();
            FormGV f = new FormGV();
            f.Show();
        }

        private void panelgiaovien_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void panelgiaovien_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void mplthongke_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lablehocvien_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablehocvien_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void lablehocvien_MouseClick(object sender, MouseEventArgs e)
        {
            panelhocvien_MouseClick(null, null);
        }

        private void panelhocvien_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void panelhocvien_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void panelhocvien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelhocvien_MouseClick(object sender, MouseEventArgs e)
        {
            FormHV f = new FormHV();
            f.Show();
        }

        private void lablediemso_MouseHover(object sender, EventArgs e)
        {

            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablediemso_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void lablediemso_MouseClick(object sender, MouseEventArgs e)
        {
            paneldienso_MouseClick(null, null);
        }

        private void paneldienso_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void paneldienso_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void paneldienso_MouseClick(object sender, MouseEventArgs e)
        {
            FormKQHT f = new FormKQHT();
            f.Show();
        }
    }
}
