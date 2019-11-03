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

namespace quanlitrungtamngoaingu.UChocvien
{
    public partial class UCkhoahoc2 : UserControl
    {
        DataTable dtKH = null;
        string err;
        bool Them;
        Khoahoc dbKH = new Khoahoc();
        int them = 0;
        public UCkhoahoc2()
        {
            InitializeComponent();
        }

        void loaddata()
        {
            try
            {
                dtKH = new DataTable();
                dtKH.Clear();
                DataSet ds = dbKH.LayKH();
                dtKH = ds.Tables[0];
                dgvkhoahoc.DataSource = dtKH;
                // Thay đổi độ rộng cột
                dgvkhoahoc.AutoResizeColumns();
                dgvkhoahoc_CellClick(null, null);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }
        
        private void UCkhoahoc_Load(object sender, EventArgs e)
        {
            loaddata();
            autocompletestring();
        }

        private void dgvkhoahoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvkhoahoc.CurrentCell.RowIndex;
            txtmahv.Text = dgvkhoahoc.Rows[r].Cells[0].Value.ToString();
            txttenhocvien.Text = dgvkhoahoc.Rows[r].Cells[1].Value.ToString();
            txtmakhoa.Text = dgvkhoahoc.Rows[r].Cells[2].Value.ToString();
            cbxKhoa.Text = dgvkhoahoc.Rows[r].Cells[3].Value.ToString();
            txtngaybatdau.Text = dgvkhoahoc.Rows[r].Cells[4].Value.ToString();
            txtngayketthuc.Text = dgvkhoahoc.Rows[r].Cells[5].Value.ToString();
            if (dgvkhoahoc.Rows[r].Cells[2].Value.ToString() == "")
            {
                MessageBox.Show("Bạn Cần cập nhật khóa học cho học sinh này!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtmakhoa.Focus();
                them = 1;
            }
            else
            {
                them = 2;
            }

        }

        private void cbxKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKhoa.Text=="Khoa1")
            {
                txtngaybatdau.Text = "15-2-2018";
                txtngayketthuc.Text = "15-4-2018";
            }
            else
            {
                txtngaybatdau.Text = "17-2-2019";
                txtngayketthuc.Text = "17-4-2019";
            }
        }
        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tengiaovien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvkhoahoc.Rows.Count - 1; i++)
                {
                    tengiaovien.Add(dgvkhoahoc.Rows[i].Cells[1].Value.ToString());
                }
                txttimkiem.AutoCompleteCustomSource = tengiaovien;
            }
            catch (Exception)
            {
                MessageBox.Show("sai");
            }
        }
        private void btntimkiem_Click_1(object sender, EventArgs e)
        {

            DataView dv;
            if (cbxKhoa.Text =="")
            {
                dtKH = new DataTable();
                dtKH.Clear();
                DataSet ds = dbKH.LayKH();
                dtKH = ds.Tables[0];
                dgvkhoahoc.DataSource = dtKH;
                dv = new DataView(dtKH);
            }
            else
            {
                dtKH = new DataTable();
                dtKH.Clear();
                DataSet ds = dbKH.LoadKhoaHocTheoLop(cbxKhoatimkiem.Text);
                dtKH = ds.Tables[0];
                dgvkhoahoc.DataSource = dtKH;
                dv = new DataView(dtKH);
            }
            dgvkhoahoc.DataSource = dv;
            autocompletestring();
            dv.RowFilter = string.Format("[HoTenHV] like '%{0}%'", txttimkiem.Text);
     
        }

        private void cbxKhoatimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv;
            dtKH = new DataTable();
            dtKH.Clear();
            DataSet ds = dbKH.LoadKhoaHocTheoLop(cbxKhoatimkiem.Text);
            dtKH = ds.Tables[0];
            dgvkhoahoc.DataSource = dtKH;
            dv = new DataView(dtKH);
            dgvkhoahoc.DataSource = dv;
            autocompletestring();
        }

        private void txtmakhoa_Leave(object sender, EventArgs e)
        {
            //if (Khoahoc.kiemtra(txtmakhoa.Text)==false)
            //{
            //    MessageBox.Show("Mã Khóa học đã tồn tại,vui lòng nhập lại", "Thông Báo",
            //        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //}
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Khoahoc.kiemtra(txtmakhoa.Text))
            //    {
            //        Khoahoc.themKhoahoc(txtmakhoa.Text,cbxKhoa.Text,txtngaybatdau.Text,txtngayketthuc.Text, txtmahv.Text);
            //        loaddata();
            //        MessageBox.Show("Cập Nhật Thành Công");
            //    }
            //    else 
            //    {
            //        Khoahoc.suakhoahoc(txtmakhoa.Text, cbxKhoa.Text, txtngaybatdau.Text, txtngayketthuc.Text, txtmahv.Text);
            //        loaddata();
            //        MessageBox.Show("Cập Nhật Thành Công");
            //    }
               
            //}
            //catch
            //{
            //    MessageBox.Show("Khong cap nhat duoc.Loi");
            //}
        }
    }
}
