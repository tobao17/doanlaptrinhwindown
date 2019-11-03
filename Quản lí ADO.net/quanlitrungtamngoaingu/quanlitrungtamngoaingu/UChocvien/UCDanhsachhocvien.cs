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
using System.Data.SqlClient;

namespace quanlitrungtamngoaingu.UChocvien
{
    public partial class UCDanhsachhocvien : UserControl
    {
        bool them = false;
        DataTable dtHV = null;
        string err;
        //bool Them;
        Danhsachhocvien dbHV = new Danhsachhocvien();
        public UCDanhsachhocvien()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                dtHV = new DataTable();
                dtHV.Clear();
                DataSet ds = dbHV.LayHV();
                dtHV = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvHọcvien.DataSource = dtHV;
                dgvHọcvien.AutoResizeColumns();

                btnCapNhat.Enabled = false;
                btnHuy.Enabled = false;
                txtmahv.ResetText();
                txttenhocvien.ResetText();
                txtdienthoai.ResetText();
                txtdiachi.ResetText();
                txtmail.ResetText();
                txtdonvi.ResetText();
                txtmaketqua.ResetText();
                // enabledtextbox();
                //  plthongtin.Enabled = false;
                lớp Lop = new lớp();
                DataTable dtLOP = new DataTable();
                dtLOP.Clear();
                DataSet ds2 = Lop.LoadLop2();
                dtLOP = ds2.Tables[0];
                cbxlop.DataSource = dtLOP;
                cbxlop.ValueMember = "MaLop";
                cbxlop.DisplayMember = "TenLop";
                btnThem.Enabled = true;
                btnsua.Enabled = true;
                //autocompletestring();
                btnXoa.Enabled = true;
                dgvHọcvien_CellClick(null, null);
            }
            catch (Exception a)
            {
                MessageBox.Show("loi");
            }
        }

        private void UCDanhsachhocvien_Load(object sender, EventArgs e)
        {
            loaddata();
            autocompletestring();
        }
        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tenhocvien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvHọcvien.Rows.Count - 1; i++)
                {
                    tenhocvien.Add(dgvHọcvien.Rows[i].Cells[1].Value.ToString());
                }
                txttimkiem.AutoCompleteCustomSource = tenhocvien;
            }
            catch (Exception)
            {
                MessageBox.Show("sai");

            }

        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataView dv;
            dv = new DataView(dtHV);
            dgvHọcvien.DataSource = dv;
            autocompletestring();
            dv.RowFilter = string.Format("[HoTenHV] like '%{0}%'", txttimkiem.Text);
        }

        private void dgvHọcvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvHọcvien.CurrentCell.RowIndex;
                txtmahv.Text = dgvHọcvien.Rows[r].Cells[0].Value.ToString();
                txttenhocvien.Text = dgvHọcvien.Rows[r].Cells[1].Value.ToString();
                txtngaynv.Text = dgvHọcvien.Rows[r].Cells[3].Value.ToString();
                txtdiachi.Text = dgvHọcvien.Rows[r].Cells[4].Value.ToString();
                txtmail.Text = dgvHọcvien.Rows[r].Cells[5].Value.ToString();
                txtdienthoai.Text = dgvHọcvien.Rows[r].Cells[6].Value.ToString();
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
            catch (Exception a)
            {
                MessageBox.Show("sai");
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
            dtHV = new DataTable();
            dtHV.Clear();
            DataSet ds = dbHV.LayHV();
            dtHV = ds.Tables[0];
            DataTable dt = dtHV;
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
            txtmaketqua.Enabled = false;
            btnHuy.Enabled = true;
            btnCapNhat.Enabled = true;
            btnThem.Enabled = false;
            btnsua.Enabled = false;
            btnXoa.Enabled = false;
            txtmahv.Enabled = false;
            txtmaketqua.Enabled = false;
            txttenhocvien.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                // Lấy thứ tự record hiện hành
                int r = dgvHọcvien.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strGV = dgvHọcvien.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                // Hiện thông báo xác nhận việc xóa mẫu tin
                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa học viên này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.Yes)
                {
                    Danhsachhocvien blHV = new Danhsachhocvien();
                    blHV.XoaHV(ref err, strGV);
                    // Cập nhật lại DataGridView
                    loaddata();
                    // Thông báo
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    // Thông báo
                    MessageBox.Show("Không thực hiện việc xóa !");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
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
                    // Thực hiện lệnh
                    Danhsachhocvien blHV = new Danhsachhocvien();
                    ketquahoctap kqht = new ketquahoctap();
                    bool nghihoc = false;
                    kqht.themKQHT2(txtmaketqua.Text, ref err);
                    blHV.themhocvien(txtmahv.Text, txttenhocvien.Text, gioitinh(), txtdienthoai.Text, txtngaynv.Value, txtdiachi.Text, txtmail.Text, txtdonvi.Text, cbxlop.SelectedValue.ToString(), txtmaketqua.Text, nghihoc, ref err);

                    // Load lại dữ liệu trên DataGridView
                    loaddata();
                    // Thông báo
                    MessageBox.Show("Đã thêm xong!");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                try
                {
                    // Thực hiện lệnh
                    Danhsachhocvien blHV = new Danhsachhocvien();
                    ketquahoctap kqht = new ketquahoctap();
                    kqht.CapNhatKQHT(txtmaketqua.Text, null, null, null, null, null, null, ref err);
                    blHV.CapNhatHV(txtmahv.Text, txttenhocvien.Text, gioitinh(), txtdienthoai.Text, txtngaynv.Value, txtdiachi.Text, txtmail.Text, txtdonvi.Text, cbxlop.SelectedValue.ToString(), ref err);

                    // Load lại dữ liệu trên DataGridView
                    loaddata();
                    // Thông báo
                    MessageBox.Show("Đã sửa xong!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại");
                }

            }
            btnsua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txtmaketqua.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtmahv.Enabled = true;
            cbxlop.Enabled = true;
            btnsua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txttimkiem.Enabled = true;
            txttimkiem.ResetText();
            loaddata();
        }

        private void txtmahv_Leave(object sender, EventArgs e)
        {
            Danhsachhocvien a = new Danhsachhocvien();
            DataSet kiemtra = new DataSet();
            kiemtra = a.kiemtra(txtmahv.Text);
            if (kiemtra.Tables[0].Rows.Count != 0)
            {
                MessageBox.Show("Mã học viên đã tồn tại.vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtmahv.ResetText();
                txtmahv.Focus();

            }
        }
        private void txtmaketqua_Leave(object sender, EventArgs e)
        {
         
        }

        private void txtmahv_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
