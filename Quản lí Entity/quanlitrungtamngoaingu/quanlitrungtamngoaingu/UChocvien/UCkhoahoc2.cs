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
        int them = 0;
        bool co = false;
        public UCkhoahoc2()
        {
            InitializeComponent();
        }

        void loaddata()
        {
            try
            {
                dgvkhoahoc.DataSource =Khoahoc.loadkhoahoc();
                dgvkhoahoc.AutoResizeColumns();
                dgvkhoahoc_CellClick(null, null);
                autocompletestring();
              //  cbxKhoa.DataSource = Khoahoc.loadkhoahoc();
               // autocompletestring();
                //cbxlop.ResetText();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }
        
        private void UCkhoahoc_Load(object sender, EventArgs e)
        {
            loaddata();
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
            if (dgvkhoahoc.Rows[r].Cells[2].Value.ToString()==""&& dgvkhoahoc.Rows[r].Cells[0].Value.ToString()!="")
            {
                MessageBox.Show("Bạn Cần cập nhật khóa học cho học sinh này!", "Thông Báo",
                    MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
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

            DataView dv= new DataView(Khoahoc.loadkhoahoc());
            if (cbxKhoa.Text ==null)
            {
                dv = new DataView(Khoahoc.loadkhoahoc());
            }
            if (co == true) 
            {
                dv = new DataView(Khoahoc.loadkhoahoctheolop(cbxKhoatimkiem.Text));
                co = false;
            }
            dgvkhoahoc.DataSource = dv;
            autocompletestring();
            dv.RowFilter = string.Format("[Họ Tên] like '%{0}%'", txttimkiem.Text);
     
        }

        private void cbxKhoatimkiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView dv;
            dv = new DataView(Khoahoc.loadkhoahoctheolop(cbxKhoatimkiem.Text));
            dgvkhoahoc.DataSource = dv;
            autocompletestring();
            co = true;
        }

        private void txtmakhoa_Leave(object sender, EventArgs e)
        {
            if (Khoahoc.kiemtra(txtmakhoa.Text)==false)
            {
                MessageBox.Show("Mã Khóa học đã tồn tại,vui lòng nhập lại", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Khoahoc.kiemtra(txtmakhoa.Text))
                {
                    Khoahoc.themKhoahoc(txtmakhoa.Text,cbxKhoa.Text,txtngaybatdau.Text,txtngayketthuc.Text, txtmahv.Text);
                    loaddata();
                    MessageBox.Show("Cập Nhật Thành Công");
                }
                else 
                {
                    Khoahoc.suakhoahoc(txtmakhoa.Text, cbxKhoa.Text, txtngaybatdau.Text, txtngayketthuc.Text, txtmahv.Text);
                    loaddata();
                    MessageBox.Show("Cập Nhật Thành Công");
                }
               
            }
            catch
            {
                MessageBox.Show("Khong cap nhat duoc.Loi");
            }
        }
    }
}
