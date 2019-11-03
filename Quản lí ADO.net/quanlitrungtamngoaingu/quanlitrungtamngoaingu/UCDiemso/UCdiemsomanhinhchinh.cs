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


namespace quanlitrungtamngoaingu.UCDiemso
{
    public partial class UCdiemsomanhinhchinh : UserControl
    {
        public UCdiemsomanhinhchinh()
        {
            InitializeComponent();
        }
      

        private void lablebangdiemso_Click(object sender, EventArgs e)
        {
            mplbangdiemso_MouseClick(null, null);
        }

        private void lablebangdiemso_MouseHover(object sender, EventArgs e)
        {

            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablebangdiemso_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void mplbangdiemso_MouseClick(object sender, MouseEventArgs e)
        {

            foreach (UserControl uc in mpldiemso.Controls.OfType<UserControl>())
            {
                mplbangdiemso.Controls.Remove(uc);
            }
           UCdiemso ucc = new UCdiemso();
            ucc.Dock = DockStyle.Fill;
            mpldiemso.Controls.Add(ucc);
            mpldiemso.Controls[0].BringToFront();
        }

        private void mplbangdiemso_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void mplbangdiemso_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34,75);
        }

        private void ptbtrove_Click(object sender, EventArgs e)
        {
            PCmanhinhchinh mhc = new PCmanhinhchinh();
            mhc.Dock = DockStyle.Fill;
            Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
            Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            foreach (UCdiemsomanhinhchinh plgdiemso in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCdiemsomanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plgdiemso);
            }
        }
    }
}
