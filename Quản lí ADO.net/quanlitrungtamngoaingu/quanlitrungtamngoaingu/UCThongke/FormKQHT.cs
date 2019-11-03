using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlitrungtamngoaingu.UCThongke
{
    public partial class FormKQHT : Form
    {
        public FormKQHT()
        {
            InitializeComponent();
        }

        private void FormKQHT_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetTT.KETQUA' table. You can move, or remove it, as needed.
            this.KETQUATableAdapter.Fill(this.DataSetTT.KETQUA);

            this.reportViewer1.RefreshReport();
        }
    }
}
