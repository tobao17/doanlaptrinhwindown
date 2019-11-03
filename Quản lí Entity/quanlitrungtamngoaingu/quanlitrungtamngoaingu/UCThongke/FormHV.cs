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
    public partial class FormHV : Form
    {
        public FormHV()
        {
            InitializeComponent();
        }

        private void FormHV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetTT.HOCVIEN' table. You can move, or remove it, as needed.
            this.HOCVIENTableAdapter.Fill(this.DataSetTT.HOCVIEN);

            this.reportViewer1.RefreshReport();
        }
    }
}
