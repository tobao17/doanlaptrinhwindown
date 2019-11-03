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

namespace quanlitrungtamngoaingu.UClophoc
{
    public partial class UClophocmanhinhchinh : UserControl
    {
        public UClophocmanhinhchinh()
        {
            InitializeComponent();
        }


        private void lbldshv_Click(object sender, EventArgs e)
        {

        }

        private void ptbtrove_Click_1(object sender, EventArgs e)
        {

          
        }

        private void ptbtrove_Click_2(object sender, EventArgs e)
        {
            PCmanhinhchinh mhc = new PCmanhinhchinh();
            mhc.Dock = DockStyle.Fill;
            Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
            Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            foreach (UClophocmanhinhchinh plgiaovien in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UClophocmanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(plgiaovien);
            }
        }

        private void lbdanhsachlop_MouseLeave(object sender, EventArgs e)
        {

            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);

        }

      

        private void lbdanhsachlop_MouseHover(object sender, EventArgs e)
        {

            MetroLabel mlb = (MetroLabel)sender;
            MetroPanel mpl = (MetroPanel)mlb.Parent;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);

        }
        private void mpldanhsachlop_MouseHover(object sender, EventArgs e)
        {

            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 96, 164);

        }

        private void mpldanhsachlop_MouseLeave(object sender, EventArgs e)
        {

            MetroPanel mpl = (MetroPanel)sender;
            mpl.UseCustomBackColor = true;
            mpl.BackColor = Color.FromArgb(1, 34, 75);

        }
        private void lbdanhsachlop_Click(object sender, EventArgs e)
        {
            mpldanhsachlop_MouseClick(null, null);
        }
        private void mpldanhsachlop_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (UserControl uc in pllophoc.Controls.OfType<UserControl>())
            {
                pllophoc.Controls.Remove(uc);
            }
           UClophoc ucc = new UClophoc();
            ucc.Dock = DockStyle.Fill;
           pllophoc.Controls.Add(ucc);
            pllophoc.Controls[0].BringToFront();
        }

        private void pllophoc_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mpldanhsachlop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void plphancong_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelgiaoviennghiviec_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
