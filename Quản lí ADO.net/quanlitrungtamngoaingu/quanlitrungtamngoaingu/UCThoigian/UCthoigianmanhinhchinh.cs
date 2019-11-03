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
using quanlitrungtamngoaingu.UCThoigian;

namespace quanlitrungtamngoaingu.Thoigian
{
    public partial class UCthoigianmanhinhchinh : UserControl
    {
        public UCthoigianmanhinhchinh()
        {
            InitializeComponent();
        }

        private void lablethoigian_Click(object sender, EventArgs e)
        {
            panelthoigian_MouseClick(null, null);
        }

        private void panelthoigian_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplthoigian.Controls.OfType<UserControl>())
            {
                mplthoigian.Controls.Remove(uc);
            }
           
          UCThoigianBieu  ucc = new UCThoigianBieu();
            ucc.Dock = DockStyle.Fill;
            mplthoigian.Controls.Add(ucc);
            mplthoigian.Controls[0].BringToFront();
        }

        private void lablethoigian_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablethoigian_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void panelthoigian_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void panelthoigian_MouseLeave(object sender, EventArgs e)
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
            foreach (UCthoigianmanhinhchinh plthoigian in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCthoigianmanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plthoigian);
            }
        }

        private void mplgiaovien_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
