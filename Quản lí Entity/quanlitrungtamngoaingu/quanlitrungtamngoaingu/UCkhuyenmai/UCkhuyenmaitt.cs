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

namespace quanlitrungtamngoaingu.UCkhuyenmai
{
    public partial class UCkhuyenmaitt : UserControl
    {
        bool them = false;
        int co = 1;
        public UCkhuyenmaitt()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                co = 1;

               dgvkhuyenmai.DataSource = Khuyenmai.loadkhuyenmai();
                dgvkhuyenmai.AutoResizeColumns();
                dgvkhuyenmai_CellClick(null, null);
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

        private void dgvkhuyenmai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvkhuyenmai.CurrentCell.RowIndex;
            txtmakm.Text =dgvkhuyenmai.Rows[r].Cells[0].Value.ToString();
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
                int r = dgvkhuyenmai.CurrentCell.RowIndex;
            
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    Khuyenmai.xoakhuyenmai(txtmakm.Text);
                    loaddata();
                    MessageBox.Show("Đã xóa xong!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không xóa được,lỗi!");
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (them)
            {
                try
                {
                    Khuyenmai.themkhuyenmai(txtmakm.Text, txttenkhuyenmai.Text, datebatdau.Value, dateketthuc.Value);
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
                    Khuyenmai.suakhuyenmai(txtmakm.Text, txttenkhuyenmai.Text, datebatdau.Value, dateketthuc.Value);
                    loaddata();
                    MessageBox.Show("sửa thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
        }

        private void txtmakm_Leave(object sender, EventArgs e)
        {
            if (co == 2 && !Khuyenmai.kiemtra(txtmakm.Text))
            {
                MessageBox.Show("Mã chứng chỉ đã tồn tại.Mời bạn nhập lại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtmakm.ResetText();
                txtmakm.Focus();
            }
        }
    }
}
