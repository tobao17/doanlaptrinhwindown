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

namespace quanlitrungtamngoaingu.UCChungchi
{
    public partial class UCchungchi : UserControl
    {
        bool them = false;
        int co = 1;
        DataTable dtCC = null;
        string err;
        chungchi dbCC = new chungchi();
        public UCchungchi()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                co = 1;
                dtCC = new DataTable();
                dtCC.Clear();
                DataSet ds = dbCC.LoadCC();
                dtCC = ds.Tables[0];
                dgvchungchi.DataSource = dtCC;
                dgvchungchi.AutoResizeColumns();
                dgvchungchi_CellClick(null, null);
                btnCapNhat.Enabled = false;
                btnHuy.Enabled = false;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("loi");
            }
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
            txtmacc.Focus();
        }
        void reset()
        {
            txtmacc.ResetText();
            txttenchungchi.ResetText();
            txthocphi.ResetText();
            txtmota.ResetText();

        }

        private void dgvchungchi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvchungchi.CurrentCell.RowIndex;
            txtmacc.Text = dgvchungchi.Rows[r].Cells[0].Value.ToString();
            txttenchungchi.Text = dgvchungchi.Rows[r].Cells[1].Value.ToString();
            txthocphi.Text = dgvchungchi.Rows[r].Cells[2].Value.ToString();
            txtmota.Text = dgvchungchi.Rows[r].Cells[3].Value.ToString();
        }

        private void UCchungchi_Load(object sender, EventArgs e)
        {
            loaddata();
            
        }

     
        private void btnSua_Click(object sender, EventArgs e)
        {
            them = false;
            dgvchungchi_CellClick(null, null);
            btnHuy.Enabled = true;
            btnCapNhat.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtmacc.Enabled = false;
            //cbxlop.Enabled = false;
            txttenchungchi.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                // Lấy thứ tự record hiện hành
                int r = dgvchungchi.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strGV = dgvchungchi.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                // Hiện thông báo xác nhận việc xóa mẫu tin
                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa chứng chỉ này này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.Yes)
                {
                    chungchi blCC = new chungchi();
                    blCC.XoaCC(strGV, ref err);
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
                    chungchi blCC = new chungchi();
                    blCC.ThemCC(txtmacc.Text, txttenchungchi.Text, txthocphi.Text, txtmota.Text, ref err);
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
                    chungchi blCC = new chungchi();
                    blCC.CapNhatCC(txtmacc.Text, txttenchungchi.Text, txthocphi.Text, txtmota.Text, ref err);
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
            txtmacc.Enabled = true;
            //   cbxlop.Enabled = true;
            loaddata();
        }

       

        private void txtmacc_Leave(object sender, EventArgs e)
        {
            chungchi a = new chungchi();
            DataSet kiemtra = new DataSet();
            kiemtra = a.kiemtra(txtmacc.Text);
            if (kiemtra.Tables[0].Rows.Count != 0)
            {
                MessageBox.Show("Mã học viên đã tồn tại.vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtmacc.ResetText();
                txtmacc.Focus();
            }
        }
    }
}
