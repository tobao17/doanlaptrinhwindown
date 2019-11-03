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

namespace quanlitrungtamngoaingu.UCGiupdo
{
    public partial class UCgiupdomanhinhchinh : UserControl
    {
        public UCgiupdomanhinhchinh()
        {
            InitializeComponent();
        }

        private void UCgiupdomanhinhchinh_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ptbtrove_Click(object sender, EventArgs e)
        {
            PCmanhinhchinh mhc = new PCmanhinhchinh();
            mhc.Dock = DockStyle.Fill;
            Frmmain.Frmain.mpanelcontainer.Controls.Add(mhc);
            Frmmain.Frmain.mpanelcontainer.Controls["PCmanhinhchinh"].BringToFront();
            foreach (UCgiupdomanhinhchinh pl in Frmmain.Frmain.mpanelcontainer.Controls.OfType<UCgiupdomanhinhchinh>())
            {
                Frmmain.Frmain.mpanelcontainer.Controls.Remove(pl);
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ptbtrove_Click_1(object sender, EventArgs e)
        {

        }
    }
}
