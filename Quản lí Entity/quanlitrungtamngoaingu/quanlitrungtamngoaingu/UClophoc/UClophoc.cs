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

namespace quanlitrungtamngoaingu.UClophoc
{
    public partial class UClophoc : UserControl
    {
        DataView dv;
        public UClophoc()
        {
           
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {

                dgvlophoc.DataSource = lớp.loadlop();
                dgvlophoc.AutoResizeColumns();
                
                btnCapNhat.Enabled = false;
                btnHuy.Enabled = false;
                dgvlophoc_CellClick(null, null);
                autocompletestring();
                dv = new DataView(lớp.loadlop());
                cbxphong.DataSource = Phonghoc.loadphonghoc();
                cbxphong.ValueMember = "Mã Phòng";
                cbxphong.DisplayMember = "Tên Phòng";
                cbxchungchi.DataSource = chungchi.loadchungchi();
                cbxchungchi.ValueMember = "Mã Chứng Chỉ";
                cbxchungchi.DisplayMember = "Tên Chứng Chỉ";
                cbxkhuyenmai.DataSource = Khuyenmai.loadkhuyenmai();
                cbxkhuyenmai.ValueMember = "Mã Khuyến Mãi";
                cbxkhuyenmai.DisplayMember = "Tên Khuyến Mãi";
                cbxthoigian.DataSource = Thoigianhoc.loadthoigian();
                cbxthoigian.ValueMember = "Mã Thời Gian";
                cbxthoigian.DisplayMember = "Thời Gian";
            }
            catch (Exception)
            {
                MessageBox.Show("loi");
            }
        }
        private void txtmahv_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void UClophoc_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void dgvlophoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvlophoc.CurrentCell.RowIndex;
            txtmalop.Text = dgvlophoc.Rows[r].Cells[0].Value.ToString();
            txttenlop.Text = dgvlophoc.Rows[r].Cells[1].Value.ToString();
            cbxchungchi.Text = dgvlophoc.Rows[r].Cells[2].Value.ToString();
            cbxphong.Text = dgvlophoc.Rows[r].Cells[3].Value.ToString();
            cbxthoigian.Text = dgvlophoc.Rows[r].Cells[4].Value.ToString();
            txtsiso.Text = dgvlophoc.Rows[r].Cells[5].Value.ToString();
            cbxkhuyenmai.Text = dgvlophoc.Rows[r].Cells[6].Value.ToString();
        }

        private void txtkhuyenmai_TextChanged(object sender, EventArgs e)
        {

        }

        private void plthongtin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(lớp.kiemtraphong(cbxphong.SelectedValue.ToString(), cbxthoigian.SelectedValue.ToString())))
                {
                    MessageBox.Show("Thời Gian và Phòng bạn đã chọn bị Trùng,vui lòng chọn Lại!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    lớp.sualop(txtmalop.Text, txttenlop.Text, txtsiso.Text, cbxkhuyenmai.SelectedValue.ToString(), cbxphong.SelectedValue.ToString(), cbxchungchi.SelectedValue.ToString(), cbxthoigian.SelectedValue.ToString());
                    loaddata();
                    MessageBox.Show("Sửa Thành Công!");
                }
            
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa Thất Bại!");
            }
        }
        public void loadlop(int trang)
        {
            int sodongtrentrang = 6;
            numsotrang.Minimum = 1;
            int skiprows = (trang - 1) * sodongtrentrang;
            DataTable dt = lớp.loadlop();
            int sotrang = dt.Rows.Count / sodongtrentrang + 1;
            numsotrang.Maximum = sotrang;
            DataTable dtt = new DataTable();
            dtt = dt.Select().Skip(skiprows).Take(sodongtrentrang).CopyToDataTable();
            dgvlophoc.DataSource = dtt;

        }
        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tengiaovien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvlophoc.Rows.Count - 1; i++)
                {
                    tengiaovien.Add(dgvlophoc.Rows[i].Cells[1].Value.ToString());
                }
                txttimkiem.AutoCompleteCustomSource = tengiaovien;
            }
            catch (Exception)
            {
                MessageBox.Show("sai");

            }
        }
        private void numsotrang_ValueChanged(object sender, EventArgs e)
        {
            int sotrang = Convert.ToInt32(numsotrang.Value);
            loadlop(sotrang);
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
             dgvlophoc.DataSource = dv;
            dv.RowFilter = string.Format("[Tên Lớp] like '%{0}%'", txttimkiem.Text);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
