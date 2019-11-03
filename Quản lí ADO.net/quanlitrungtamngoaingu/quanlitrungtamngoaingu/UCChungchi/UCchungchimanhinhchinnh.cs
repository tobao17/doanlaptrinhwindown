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
namespace quanlitrungtamngoaingu.UCChungchi
{
    public partial class UCchungchimanhinhchinnh : UserControl
    {
        public UCchungchimanhinhchinnh()
        {
            InitializeComponent();
        }

        private void ptbtrove_Click(object sender, EventArgs e)
        {
            PCmanhinhchinh mhc = new PCmanhinhchinh();
            mhc.Dock = DockStyle.Fill;
            Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
            Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            foreach (UCchungchimanhinhchinnh plchungchi in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCchungchimanhinhchinnh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plchungchi);
            }
        }

        private void lablechungchi_MouseHover(object sender, EventArgs e)
        {

            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }
        private void lablechungchi_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }
        private void lablechungchi_Click(object sender, EventArgs e)
        {
            panelchungchi_MouseClick(null, null);
        }

     

        private void panelchungchi_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplgiaovien.Controls.OfType<UserControl>())
            {
                mplgiaovien.Controls.Remove(uc);
            }
            UCchungchi ucc = new UCchungchi();
            ucc.Dock = DockStyle.Fill;
            mplgiaovien.Controls.Add(ucc);
            mplgiaovien.Controls[0].BringToFront();
        }

        private void panelchungchi_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void panelchungchi_MouseLeave(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }
    }
}
