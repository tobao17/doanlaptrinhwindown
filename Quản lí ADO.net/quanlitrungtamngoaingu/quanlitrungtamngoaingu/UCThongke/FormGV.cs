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
    public partial class FormGV : Form
    {
        public FormGV()
        {
            InitializeComponent();
        }

        private void FormGV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetTT.GIAOVIEN' table. You can move, or remove it, as needed.
            this.GIAOVIENTableAdapter.Fill(this.DataSetTT.GIAOVIEN);

            this.reportViewer1.RefreshReport();
        }
    }
}
