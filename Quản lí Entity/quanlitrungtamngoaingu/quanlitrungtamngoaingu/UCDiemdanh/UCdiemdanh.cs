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
namespace quanlitrungtamngoaingu.UCDiemdanh
{
    public partial class UCdiemdanh : UserControl
    {
        public UCdiemdanh()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {

                dgvdiemdanh.DataSource = diemdanh.loaddiemdanh();
                dgvdiemdanh.AutoResizeColumns();
                dgvdiemdanh_CellClick(null, null);
              
                autocompletestring();

            }
            catch (Exception)
            {
                MessageBox.Show("loi");
            }
        }
        private void dgvdiemdanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvdiemdanh.CurrentCell.RowIndex;
            txtmahv.Text = dgvdiemdanh.Rows[r].Cells[0].Value.ToString();
            txttenhv.Text = dgvdiemdanh.Rows[r].Cells[1].Value.ToString();
            txtsolancomat.Text = dgvdiemdanh.Rows[r].Cells[2].Value.ToString();
            txtsolanvangmat.Text = dgvdiemdanh.Rows[r].Cells[3].Value.ToString();
            if (dgvdiemdanh.Rows[r].Cells[2].Value.ToString() == "" && dgvdiemdanh.Rows[r].Cells[0].Value.ToString() != "")
            {
                MessageBox.Show("Bạn Cần cập nhật khóa học cho học sinh này!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
               txtsolancomat.Focus();
            }
       
        }

        private void UCdiemdanh_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (diemdanh.kiemtra(txtmahv.Text))
                {
                    diemdanh.themdiemdanh(txtmahv.Text,txtsolancomat.Text,txtsolanvangmat.Text);
                    loaddata();
                    MessageBox.Show("Cập Nhật Thành Công");
                }
                else
                {
                    diemdanh.suadiemdanh(txtmahv.Text, txtsolancomat.Text, txtsolanvangmat.Text);
                    loaddata();
                    MessageBox.Show("Cập Nhật Thành Công");
                }

            }
            catch
            {
                MessageBox.Show("Khong cap nhat duoc.Loi");
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(diemdanh.loaddiemdanh());
           dgvdiemdanh.DataSource = dv;
            dv.RowFilter = string.Format("[Tên HV] like '%{0}%'", txttimkiem.Text);
        }
        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tengiaovien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvdiemdanh.Rows.Count - 1; i++)
                {
                    tengiaovien.Add(dgvdiemdanh.Rows[i].Cells[1].Value.ToString());
                }
                txttimkiem.AutoCompleteCustomSource = tengiaovien;
            }
            catch (Exception)
            {
                MessageBox.Show("sai");

            }
        }

        private void dgvdiemdanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
