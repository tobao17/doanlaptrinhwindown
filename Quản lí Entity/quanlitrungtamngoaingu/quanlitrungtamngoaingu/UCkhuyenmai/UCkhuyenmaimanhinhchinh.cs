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

namespace quanlitrungtamngoaingu.UCkhuyenmai
{
    public partial class UCkhuyenmaimanhinhchinh : UserControl
    {
        public UCkhuyenmaimanhinhchinh()
        {
            InitializeComponent();
        }

        private void ptbtrove_Click(object sender, EventArgs e)
        {
            PCmanhinhchinh mhc = new PCmanhinhchinh();
            mhc.Dock = DockStyle.Fill;
            Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
            Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            foreach (UCkhuyenmaimanhinhchinh plkhuyenmai in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCkhuyenmaimanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plkhuyenmai);
            }
        }

        private void lablekhuyenmai_Click(object sender, EventArgs e)
        {
            panelkhuyenmai_MouseClick(null, null);
        }

        private void panelkhuyenmai_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplkhuyemmai.Controls.OfType<UserControl>())
            {
                mplkhuyemmai.Controls.Remove(uc);
            }
            UCkhuyenmaitt ucc = new UCkhuyenmaitt();
            ucc.Dock = DockStyle.Fill;
            mplkhuyemmai.Controls.Add(ucc);
            mplkhuyemmai.Controls[0].BringToFront();
        }

        private void lablekhuyenmai_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablekhuyenmai_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void panelkhuyenmai_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void panelkhuyenmai_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }
    }
}
