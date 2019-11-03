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
namespace quanlitrungtamngoaingu.UCChungchi
{
    public partial class UCchungchi : UserControl
    {
        bool them = false;
        int co = 1;
        public UCchungchi()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                co = 1;

                dgvchungchi.DataSource = chungchi.loadchungchi();
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
                int r = dgvchungchi.CurrentCell.RowIndex;
                string strmachungchi = dgvchungchi.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    chungchi.xoachungchi(strmachungchi);
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
                    chungchi.themchungchi(txtmacc.Text, txttenchungchi.Text, txthocphi.Text,
                        txtmota.Text);
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
                    chungchi.suachungchi(txtmacc.Text, txttenchungchi.Text, txthocphi.Text,
                        txtmota.Text);
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
            if (co == 2 && !chungchi.kiemtra(txtmacc.Text))
            {
                MessageBox.Show("Mã chứng chỉ đã tồn tại.Mời bạn nhập lại!","Thông Báo",
                    MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                txtmacc.ResetText();
                txtmacc.Focus();
            }
        }
    }
}
