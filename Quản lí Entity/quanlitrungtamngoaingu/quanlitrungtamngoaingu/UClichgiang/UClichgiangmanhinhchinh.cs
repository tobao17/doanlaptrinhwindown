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
using quanlitrungtamngoaingu.UCgiaovien;


namespace quanlitrungtamngoaingu.UClichgiang
{
    public partial class UClichgiangmanhinhchinh : UserControl
    {
        public UClichgiangmanhinhchinh()
        {
            InitializeComponent();
        }

        private void lablelichgiang_Click(object sender, EventArgs e)
        {
            panellichgiang_MouseClick(null, null);
        }

        private void panellichgiang_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in mplichgiang.Controls.OfType<UserControl>())
            {
               mplichgiang.Controls.Remove(uc);
            }
            UCphancong ucc = new UCphancong();
            ucc.Dock = DockStyle.Fill;
            mplichgiang.Controls.Add(ucc);
            mplichgiang.Controls[0].BringToFront();
        }

        private void lablelichgiang_MouseHover(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void lablelichgiang_MouseLeave(object sender, EventArgs e)
        {
            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);
        }

        private void panellichgiang_MouseHover(object sender, EventArgs e)
        {
            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);
        }

        private void panellichgiang_MouseLeave(object sender, EventArgs e)
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
            foreach (UClichgiangmanhinhchinh pllichgiang in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UClichgiangmanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(pllichgiang);
            }
        }
    }
}
