using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using quanlitrungtamngoaingu.businesslogiclayer;

namespace quanlitrungtamngoaingu.UChocvien
{
    public partial class UCDanhsachhocvien : UserControl
    {
        bool them = false;
        public UCDanhsachhocvien()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                
                dgvHọcvien.DataSource = Danhsachhocvien.loadhocvien();
                dgvHọcvien.AutoResizeColumns();
                dgvHọcvien_CellClick(null, null);
                btnCapNhat.Enabled = false;
                btnHuy.Enabled = false;
                // enabledtextbox();
                //  plthongtin.Enabled = false;
                cbxlop.DataSource = lớp.loadlop();
                cbxlop.ValueMember = "Mã Lớp";
                cbxlop.DisplayMember = "Tên Lớp";
                btnThem.Enabled = true;
                btnsua.Enabled = true;
                autocompletestring();
                btnXoa.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("loi");
            }
        }

        private void UCDanhsachhocvien_Load(object sender, EventArgs e)
        {
            loaddata();
        }
        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tengiaovien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvHọcvien.Rows.Count - 1; i++)
                {
                    tengiaovien.Add(dgvHọcvien.Rows[i].Cells[1].Value.ToString());
                }
                txttimkiem.AutoCompleteCustomSource = tengiaovien;
            }
            catch (Exception )
            {
                MessageBox.Show("sai");

            }

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(Danhsachhocvien.loadhocvien());
           dgvHọcvien.DataSource = dv;
            dv.RowFilter = string.Format("[Tên Học Viên] like '%{0}%'", txttimkiem.Text);
        }

        private void dgvHọcvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHọcvien.CurrentCell.RowIndex;
            txtmahv.Text = dgvHọcvien.Rows[r].Cells[0].Value.ToString();
            txttenhocvien.Text = dgvHọcvien.Rows[r].Cells[1].Value.ToString();
            txtngaynv.Text = dgvHọcvien.Rows[r].Cells[4].Value.ToString();
            txtdiachi.Text = dgvHọcvien.Rows[r].Cells[5].Value.ToString();
            txtmail.Text = dgvHọcvien.Rows[r].Cells[6].Value.ToString();
            txtdienthoai.Text = dgvHọcvien.Rows[r].Cells[3].Value.ToString();
            txtdonvi.Text = dgvHọcvien.Rows[r].Cells[7].Value.ToString();
            cbxlop.SelectedValue = dgvHọcvien.Rows[r].Cells[8].Value.ToString();
            txtmaketqua.Text = dgvHọcvien.Rows[r].Cells[9].Value.ToString();
            if (dgvHọcvien.Rows[r].Cells[2].Value.ToString() == "Nam")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }
        }
        public void loadsotrang()
        {
            int sodongtrentrang = 6;
            int sotrang = dgvHọcvien.RowCount / sodongtrentrang + 1;
            numsotrang.Minimum = 1;
            numsotrang.Maximum = sotrang;

        }
        public void loadhocvien(int trang)
        {

            int sodongtrentrang = 6;
            int skiprows = (trang - 1) * sodongtrentrang;
            DataTable dt = Danhsachhocvien.loadhocvien();
            DataTable dtt = new DataTable();
            dtt = dt.Select().Skip(skiprows).Take(sodongtrentrang).CopyToDataTable();
           dgvHọcvien.DataSource = dtt;

        }

        private void numsotrang_ValueChanged(object sender, EventArgs e)
        {
            loadsotrang();
            int sotrang = Convert.ToInt32(numsotrang.Value);
            loadhocvien(sotrang);
        }
        void reset()
        {
            txtdiachi.ResetText();
            txtdienthoai.ResetText();
            txtdonvi.ResetText();
            txtmahv.ResetText();
            txtmail.ResetText();
            txtngaynv.ResetText();
            txttenhocvien.ResetText();
            txtdiachi.ResetText();
            cbxlop.ResetText();
            txtmaketqua.ResetText();
          
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            reset();

            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
            plthongtin.Enabled = true;
            btnThem.Enabled = false;
            btnsua.Enabled = false;
            btnXoa.Enabled = false;
            txtmahv.Focus();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
            dgvHọcvien_CellClick(null, null);
            btnHuy.Enabled = true;
            btnCapNhat.Enabled = true;
            btnThem.Enabled = false;
            btnsua.Enabled = false;
            btnXoa.Enabled = false;
           txtmahv.Enabled = false;
           txttenhocvien.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvHọcvien.CurrentCell.RowIndex;
                string strmahocvien = dgvHọcvien.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                   Danhsachhocvien.xoahocvien(strmahocvien);
                    loaddata();
                    MessageBox.Show("Đã xóa xong!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không xóa được,lỗi!");
            }

        }
        string gioitinh()
        {
            string gioi;
            if (rdbNam.Checked == true)
            {
                gioi = "Nam";

            }
            else
                gioi = "Nu";
            return gioi;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    ketquahoctap.themmakq(txtmaketqua.Text,null,null,null,null,null,null,null);
                    Danhsachhocvien.themhocvien(txtmahv.Text, txttenhocvien.Text, gioitinh(), txtdienthoai.Text,
                       txtngaynv.Value, txtdiachi.Text, txtmail.Text, txtdonvi.Text, cbxlop.SelectedValue.ToString(),
                       txtmaketqua.Text);
                    loaddata();
                    MessageBox.Show("Them Thanh Cong!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Them That Bai");
                }
            }
            else
            {
                try
                {
                    ketquahoctap.suaketquahoctap(txtmaketqua.Text, null, null, null,
                        null, null, null);
                    Danhsachhocvien.suahocvien(txtmahv.Text, txttenhocvien.Text, gioitinh(), txtdienthoai.Text,
                       txtngaynv.Value, txtdiachi.Text, txtmail.Text, txtdonvi.Text, cbxlop.SelectedValue.ToString(),
                       txtmaketqua.Text);
                    loaddata();
                    MessageBox.Show("sửa thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtmahv.Enabled = true;
            loaddata();
        }

        private void txtmahv_Leave(object sender, EventArgs e)
        {
            if (Danhsachhocvien.kiemtrahocvien(txtmahv.Text) == false)
            {
                MessageBox.Show("Học viên đã tồn tại!", "Thông báo");
                txtmahv.ResetText();
                txtmahv.Focus();
            }
        }

        private void txtmaketqua_Leave(object sender, EventArgs e)
        {

            if (Danhsachhocvien.kiemtraMaketqua(txtmaketqua.Text) == false)
            {
                MessageBox.Show("Mã Kết Quả đã tồn tại!", "Thông báo");
                txtmaketqua.ResetText();
                txtmaketqua.Focus();
            }
        }

        private void txtmahv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
