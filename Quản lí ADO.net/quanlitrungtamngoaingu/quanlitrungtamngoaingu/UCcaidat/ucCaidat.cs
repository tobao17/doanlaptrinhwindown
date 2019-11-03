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
using quanlitrungtamngoaingu.UCcaidat;

namespace quanlitrungtamngoaingu
{
    public partial class ucCaidat : UserControl
    {
        public ucCaidat()
        {
            InitializeComponent();
        }

        private void lablecaidat_Click(object sender, EventArgs e)
        {
            panelcaidat_MouseClick(null, null);
        }

        private void lablecaidat_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablecaidat_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void panelcaidat_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplgiaovien.Controls.OfType<UserControl>())
            {
                mplgiaovien.Controls.Remove(uc);
            }

            UCdoimatkhau ucc = new UCdoimatkhau();
            ucc.Dock = DockStyle.Fill;
            mplgiaovien.Controls.Add(ucc);
            mplgiaovien.Controls[0].BringToFront();
        }

        private void panelcaidat_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void panelcaidat_MouseLeave(object sender, EventArgs e)
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
            foreach (ucCaidat plchungchi in Frmmain.Frmain.mpanelcontainer.Controls.OfType<ucCaidat>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plchungchi);
            }
        }
    }
}
