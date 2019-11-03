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
namespace quanlitrungtamngoaingu.UCDiemdanh
{
    public partial class UCDiemdanhmanhinhchinh : UserControl
    {
        public UCDiemdanhmanhinhchinh()
        {
            InitializeComponent();
        }

        private void lablediemdanh_Click(object sender, EventArgs e)
        {
            paneldiemdanh_MouseClick(null, null);
        }

        private void lablediemdanh_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablediemdanh_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void paneldiemdanh_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplgiaovien.Controls.OfType<UserControl>())
            {
                mplgiaovien.Controls.Remove(uc);
            }

            UCdiemdanh ucc = new UCdiemdanh();
            ucc.Dock = DockStyle.Fill;
           mplgiaovien.Controls.Add(ucc);
           mplgiaovien.Controls[0].BringToFront();
        }

        private void paneldiemdanh_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void paneldiemdanh_MouseLeave(object sender, EventArgs e)
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
            foreach (UCDiemdanhmanhinhchinh plchungchi in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCDiemdanhmanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plchungchi);
            }
        }
    }
}
