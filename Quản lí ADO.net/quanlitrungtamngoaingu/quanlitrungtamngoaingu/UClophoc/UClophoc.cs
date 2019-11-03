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
        DataTable dtLOP = null;
        string err;
        bool Them;
        int co = 1;
        lớp dbLOP = new lớp();
        public UClophoc()
        {
           
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                dtLOP = new DataTable();
                dtLOP.Clear();
                DataSet ds = dbLOP.LoadLop();
                dtLOP = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvlophoc.DataSource = dtLOP; ;
                dgvlophoc.AutoResizeColumns();
                //cbxPhonhHoc 
                Phonghoc PH = new Phonghoc();
                DataTable dtPH = new DataTable();
                dtPH.Clear();
                DataSet ds1 = PH.Layphonghoc();
                dtPH = ds1.Tables[0];
                cbxphong.DataSource = dtPH;
                cbxphong.ValueMember = "MaPhong";
                cbxphong.DisplayMember = "TenPhong";
                //cbxChungChi
                chungchi ChungChi = new chungchi();
                DataTable dtCC = new DataTable();
                dtCC.Clear();
                DataSet ds2 = ChungChi.LoadChungChi2();
                dtCC = ds2.Tables[0];
                cbxchungchi.DataSource = dtCC;
                cbxchungchi.ValueMember = "MaChungChi";
                cbxchungchi.DisplayMember = "TenChungChi";
                //cbxKhuyenMai
                Khuyenmai KM = new Khuyenmai();
                DataTable dtKM = new DataTable();
                dtKM.Clear();
                DataSet ds3 = KM.LoadKM2();
                dtKM = ds3.Tables[0];
                cbxkhuyenmai.DataSource = dtKM;
                cbxkhuyenmai.ValueMember = "MaKM";
                cbxkhuyenmai.DisplayMember = "TenKM";
                //cbxThoiGianHoc
                Thoigianhoc TGH = new Thoigianhoc();
                DataTable dtTGH = new DataTable();
                dtTGH.Clear();
                DataSet ds4 = TGH.LoadTGH2();
                dtTGH = ds4.Tables[0];
                cbxthoigian.DataSource = dtTGH;
                cbxthoigian.ValueMember = "MaThoiGian";
                cbxthoigian.DisplayMember = "ThoiGianHoc";
                //cbxthoigian.BindingContext = this.BindingContext;
                btnCapNhat.Enabled = false;
                //btnHuy.Enabled = false;
                dgvlophoc_CellClick(null, null);
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
            autocompletestring();
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
            txtmalop.Enabled = false;
            btnsua.Enabled = false;
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
        }
        public bool KiemTra(string x, string y)
        {
            for (int i = 0; i < dgvlophoc.Rows.Count - 2; i++)
                if (x == dgvlophoc.Rows[i].Cells[3].Value.ToString() && y == dgvlophoc.Rows[i].Cells[4].Value.ToString())
                    return false;
            return true;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra(cbxphong.Text, cbxthoigian.Text) == false)
                {
                    MessageBox.Show("Thời Gian và Phòng bạn đã chọn bị Trùng,vui lòng chọn Lại!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    lớp blLop = new lớp();
                    blLop.CapNhatLop(txtmalop.Text, txttenlop.Text, txtsiso.Text, cbxkhuyenmai.SelectedValue.ToString(), cbxphong.SelectedValue.ToString(), cbxchungchi.SelectedValue.ToString(), cbxthoigian.SelectedValue.ToString(), ref err);
                    loaddata();
                    MessageBox.Show("Sửa Thành Công!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sửa Thất Bại!");
            }
            btnsua.Enabled = true;
        }
        public void loadlop(int trang)
        {
            int sodongtrentrang = 6;
            numsotrang.Minimum = 1;
            int skiprows = (trang - 1) * sodongtrentrang;
            dtLOP = new DataTable();
            dtLOP.Clear();
            DataSet ds = dbLOP.LoadLop();
            dtLOP = ds.Tables[0];
            DataTable dt = dtLOP;
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
            DataView dv;
            dv = new DataView(dtLOP);
            dgvlophoc.DataSource = dv;
            autocompletestring();
            dv.RowFilter = string.Format("[TenLop] like '%{0}%'", txttimkiem.Text);
            txttimkiem.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txttimkiem.Enabled = true;
            txttimkiem.ResetText();
            btnsua.Enabled = true;
            txtmalop.Enabled = true;
            loaddata();
        }
    }
}
