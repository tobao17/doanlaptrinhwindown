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
namespace quanlitrungtamngoaingu.UCgiaovien
{
    public partial class Ucgiaovienmanhinhchinh : UserControl
    {
        public Ucgiaovienmanhinhchinh()
        {
            InitializeComponent();
        }

        private void ptbtrove_Click(object sender, EventArgs e)
        {
            PCmanhinhchinh mhc = new PCmanhinhchinh();
           mhc.Dock = DockStyle.Fill;
            Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
            Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            foreach (Ucgiaovienmanhinhchinh plgiaovien in Frmmain.Frmain.mpanelcontainer.Controls.OfType<Ucgiaovienmanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plgiaovien);
            }
        }
        private void metroPanel_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
           mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1,96,164);

        }

        private void metroPanel_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1,34,75);

        }

        private void metroLabel_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl =(MetroPanel) mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1,34,75);
        }

        private void metroLabel_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void mpldanhsachgiaovien_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplgiaovien.Controls.OfType<UserControl>())
            {
                mplgiaovien.Controls.Remove(uc);
            }
            //Ucdanhsachgiaovien ucc = new Ucdanhsachgiaovien();
            //ucc.Dock = DockStyle.Fill;
            //mplgiaovien.Controls.Add(ucc);
            //mplgiaovien.Controls[0].BringToFront();
            //UCprogressbar ucc = new UCprogressbar();
            //ucc.Dock = DockStyle.Fill;
            //mplgiaovien.Controls.Add(ucc);
            //mplgiaovien.Controls[0].BringToFront();
            //for (int i = 0; i <= 1000; i++)
            //{
            //    Thread.Sleep(8);
            //    ucc.giatri = i * 100 / 1000;
            //    ucc.hienthi = (i * 100 / 1000).ToString();
            //}
            //mplgiaovien.Controls.Remove(ucc);
            Ucdanhsachgiaovien ucd = new Ucdanhsachgiaovien();
            ucd.Dock = DockStyle.Fill;
            mplgiaovien.Controls.Add(ucd);
            mplgiaovien.Controls[0].BringToFront();
        }

        private void lbldsgv_Click(object sender, EventArgs e)
        {
            mpldanhsachgiaovien_MouseClick(null, null);
        }
        private void mplphanconggiangday_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplgiaovien.Controls.OfType<UserControl>())
            {
                mplgiaovien.Controls.Remove(uc);
            }
            UCphancong ucc = new UCphancong();
            ucc.Dock = DockStyle.Fill;
            mplgiaovien.Controls.Add(ucc);
            mplgiaovien.Controls[0].BringToFront();
        }
        private void mlbphancong_Click(object sender, EventArgs e)
        {
            mplphanconggiangday_MouseClick(null, null);
        }

        private void mlblichgiang_Click(object sender, EventArgs e)
        {
            panelgiaoviennghiviec_MouseClick(null, null);
          
           
        }

        private void panelgiaoviennghiviec_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplgiaovien.Controls.OfType<UserControl>())
            {
                mplgiaovien.Controls.Remove(uc);
            }

            UCgiaovienthoiviec ucc = new UCgiaovienthoiviec();
            ucc.Dock = DockStyle.Fill;
            mplgiaovien.Controls.Add(ucc);
            mplgiaovien.Controls[0].BringToFront();
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mplgiaovien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panelgiaoviennghiviec_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plphancong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mpldanhsachgiaovien_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
