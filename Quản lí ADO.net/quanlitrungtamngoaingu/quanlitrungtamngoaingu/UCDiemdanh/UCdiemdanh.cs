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
        DataTable dtDD = null;
        string err;
        diemdanh dbDD = new diemdanh();
        public UCdiemdanh()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                dtDD = new DataTable();
                dtDD.Clear();
                DataSet ds = dbDD.LoadDD();
                dtDD = ds.Tables[0];
                dgvdiemdanh.DataSource = dtDD;
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
            //try
            //{
            //    diemdanh blDD = new diemdanh();
            //    blDD.CapNhatDD(txtmahv.Text, txtsolancomat.Text, txtsolanvangmat.Text, ref err);
            //    loaddata();
            //    MessageBox.Show("Cập nhật Thành Công!");
            //}
            //catch
            //{
            //    MessageBox.Show("không cập nhật được.Lỗi!");
            //}
            //txttimkiem.Enabled = false;
            try
            {
                diemdanh a = new diemdanh();
                DataSet b = new DataSet();
                b = a.kiemtra(txtmahv.Text);
                 if (b.Tables[0].Rows.Count==0)
                {
                    diemdanh blDD = new diemdanh();
                    blDD.ThemDD(txtmahv.Text, txtsolancomat.Text, txtsolanvangmat.Text, ref err);
                    loaddata();
                    MessageBox.Show("Cập Nhật Thành Công");
                }
                else
                {
                    diemdanh blDD = new diemdanh();
                    blDD.CapNhatDD(txtmahv.Text, txtsolancomat.Text, txtsolanvangmat.Text, ref err);
                    loaddata();
                    MessageBox.Show("Cập nhật Thành Công!");
                }
            }


            catch
            {
                MessageBox.Show("Khong cap nhat duoc.Loi");
                //}
            }
        }
        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataView dv;
            dv = new DataView(dtDD);
            dgvdiemdanh.DataSource = dv;
            autocompletestring();
            dv.RowFilter = string.Format("[HoTenHV] like '%{0}%'", txttimkiem.Text);
            //txttimkiem.Enabled = false;
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
