using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using quanlitrungtamngoaingu.UChethong;

namespace quanlitrungtamngoaingu
{
    public partial class Frmmain : MetroFramework.Forms.MetroForm
    {
        public Frmmain()
        {
            InitializeComponent();
        }
        public static Frmmain _frmain;
        public static Frmmain Frmain
        {
            get
            {
                if (_frmain == null)
                    _frmain = new Frmmain();
                return _frmain;
            }
        }
        public MetroPanel mpanelcontainer
        {
            get
            {
                return mcontainer;
            }
            set
            {
                mcontainer = value;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _frmain = this;
            UCdangnhap mhc = new UCdangnhap();
            mhc.Dock = DockStyle.Fill;
            _frmain.mpanelcontainer.Controls.Add(mhc);
            _frmain.mpanelcontainer.Controls["UCdangnhap"].BringToFront();
        }

        private void mcontainer_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
