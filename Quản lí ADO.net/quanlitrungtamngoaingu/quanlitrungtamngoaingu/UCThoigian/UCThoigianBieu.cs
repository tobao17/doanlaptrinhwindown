using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using quanlitrungtamngoaingu.businesslogiclayer;
namespace quanlitrungtamngoaingu.UCThoigian
{
    public partial class UCThoigianBieu : UserControl
    {
        DataTable dtTGB = null;
        string err;
        Thoigianhoc dbTGB = new Thoigianhoc();
        public UCThoigianBieu()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                dtTGB = new DataTable();
                dtTGB.Clear();
                DataSet ds = dbTGB.LoadTGH();
                dtTGB = ds.Tables[0];
                dgvthoigian.DataSource = dtTGB;
                dgvthoigian.AutoResizeColumns();
                dgvthoigian_CellClick(null, null);
                autocompletestring();

            }
            catch (Exception)
            {
                MessageBox.Show("loi");
            }
        }
        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tengiaovien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvthoigian.Rows.Count - 1; i++)
                {
                    tengiaovien.Add(dgvthoigian.Rows[i].Cells[0].Value.ToString());
                }
                txttimkiem.AutoCompleteCustomSource = tengiaovien;
            }
            catch (Exception)
            {
                MessageBox.Show("sai");

            }
        }
        private void dgvthoigian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvthoigian.CurrentCell.RowIndex;
            txtlop.Text = dgvthoigian.Rows[r].Cells[0].Value.ToString();
            txtphong.Text = dgvthoigian.Rows[r].Cells[1].Value.ToString();
            txtmathoigian.Text = dgvthoigian.Rows[r].Cells[2].Value.ToString();
            txtthoigian.Text = dgvthoigian.Rows[r].Cells[3].Value.ToString();
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataView dv;
            dv = new DataView(dtTGB);
            dgvthoigian.DataSource = dv;
            autocompletestring();
            dv.RowFilter = string.Format("[TenLop] like '%{0}%'", txttimkiem.Text);
        }

        private void UCThoigianBieu_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
