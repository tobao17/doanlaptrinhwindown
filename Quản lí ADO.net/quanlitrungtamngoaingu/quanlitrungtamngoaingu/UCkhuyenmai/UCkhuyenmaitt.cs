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
using System.Data.SqlClient;

namespace quanlitrungtamngoaingu.UCkhuyenmai
{
    public partial class UCkhuyenmaitt : UserControl
    {
        bool them = false;
        int co = 1;
        DataTable dtKM = null;
        string err;
        Khuyenmai dbKM = new Khuyenmai();
        public UCkhuyenmaitt()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            dtKM = new DataTable();
            dtKM.Clear();
            DataSet ds = dbKM.LoadKM();
            dtKM = ds.Tables[0];

            dgvkhuyenmai.DataSource = dtKM;
            dgvkhuyenmai.AutoResizeColumns();
            dgvkhuyenmai_CellClick(null, null);
            btnCapNhat.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void dgvkhuyenmai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvkhuyenmai.CurrentCell.RowIndex;
            txtmakm.Text = dgvkhuyenmai.Rows[r].Cells[0].Value.ToString();
            txttenkhuyenmai.Text = dgvkhuyenmai.Rows[r].Cells[1].Value.ToString();
            datebatdau.Text = dgvkhuyenmai.Rows[r].Cells[2].Value.ToString();
            dateketthuc.Text = dgvkhuyenmai.Rows[r].Cells[3].Value.ToString();
        }

        private void UCkhuyenmaitt_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            them = true;
            co = 2;
            reset();
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtmakm.Focus();
        }
        void reset()
        {
            txtmakm.ResetText();
            txttenkhuyenmai.ResetText();
            datebatdau.ResetText();
            dateketthuc.ResetText();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            dgvkhuyenmai_CellClick(null, null);
            btnHuy.Enabled = true;
            btnCapNhat.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtmakm.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                // Lấy thứ tự record hiện hành
                int r = dgvkhuyenmai.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strGV = dgvkhuyenmai.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                // Hiện thông báo xác nhận việc xóa mẫu tin
                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa khuyến mãi này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.Yes)
                {
                    Khuyenmai blKM = new Khuyenmai();
                    blKM.XoaKM(strGV, ref err);
                    // Cập nhật lại DataGridView
                    loaddata();
                    // Thông báo
                    MessageBox.Show("Đã xóa xong!");
                }
                else
                {
                    // Thông báo
                    MessageBox.Show("Không thực hiện việc xóa giáo viên!");
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Không xóa được. Lỗi rồi!");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    Khuyenmai blKM = new Khuyenmai();
                    blKM.ThemKM(txtmakm.Text, txttenkhuyenmai.Text, datebatdau.Value, dateketthuc.Value, ref err);
                    // lớp.themlop( cbxlop.SelectedValue.ToString(), cbxtenlop.SelectedValue.ToString());
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
                    //lớp.sualop(cbxlop.SelectedValue.ToString(), cbxtenlop.SelectedValue.ToString());
                    Khuyenmai blKM = new Khuyenmai();
                    blKM.CapNhatKM(txtmakm.Text, txttenkhuyenmai.Text, datebatdau.Value, dateketthuc.Value, ref err);
                    loaddata();
                    MessageBox.Show("sửa thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
            btnSua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void txtmakm_Leave(object sender, EventArgs e)
        {
            Khuyenmai a = new Khuyenmai();
            DataSet kiemtra = new DataSet();
            kiemtra = a.kiemtra(txtmakm.Text);
            if (kiemtra.Tables[0].Rows.Count != 0)
            {
                MessageBox.Show("Mã học viên đã tồn tại.vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtmakm.ResetText();
                txtmakm.Focus();
            }
        }
    }
}
