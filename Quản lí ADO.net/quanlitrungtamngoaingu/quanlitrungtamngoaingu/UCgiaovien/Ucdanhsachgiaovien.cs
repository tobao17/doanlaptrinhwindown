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

namespace quanlitrungtamngoaingu.UCgiaovien
{
  
    public partial class Ucdanhsachgiaovien : UserControl
    {
        DataTable dtGV = null;
        string err;
        bool Them;
        int co = 1;
        byte[] image = null;
        giaovien dbGV = new giaovien();
        public Ucdanhsachgiaovien()
        {
            InitializeComponent();
        }
       
        void loaddata()
        {
                try
                {
                    co = 1;
                    dtGV = new DataTable();
                    dtGV.Clear();
                    DataSet ds = dbGV.LayGV();
                    dtGV = ds.Tables[0];
                    // Đưa dữ liệu lên DataGridView
                    dgvgiaovien.DataSource = dtGV;
                    dgvgiaovien.Columns["Anh"].Visible = false;
                    // Thay đổi độ rộng cột
                    dgvgiaovien.AutoResizeColumns();
                    // Xóa trống các đối tượng trong Panel
                    this.txtmagv.ResetText();
                    this.txttengiaovien.ResetText();
                    this.txtmail.ResetText();
                    this.txtdienthoai.ResetText();
                    this.txtdiachi.ResetText();
                    this.txtdonvi.ResetText();
                    Phonghoc PH = new Phonghoc();
                    DataTable dtPH = new DataTable();
                    dtPH.Clear();
                    DataSet ds1 = PH.Layphonghoc();
                    dtPH = ds1.Tables[0];
                    cbxphong.DataSource = dtPH;
                    cbxphong.ValueMember = "MaPhong";
                    cbxphong.DisplayMember = "TenPhong";
                    lớp Lop = new lớp();
                    DataTable dtLOP = new DataTable();
                    dtLOP.Clear();
                    DataSet ds2 = Lop.LoadLop2();
                    dtLOP = ds2.Tables[0];
                    cbxlop.DataSource = dtLOP;
                    cbxlop.ValueMember = "MaLop";
                    cbxlop.DisplayMember = "TenLop";
                    btnHuy.Enabled = false;
                    btnCapNhat.Enabled = false;
                    dgvgiaovien_CellClick_1(null, null);
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.ToString());
                }
         }

        private void Ucdanhsachgiaovien_Load(object sender, EventArgs e)
        {
            loaddata();
            autocompletestring();
        }


        public static Bitmap bytetoimage (byte []anh )
        {
            MemoryStream memostream = new MemoryStream();
            memostream.Write(anh, 0, Convert.ToInt32(anh.Length));
            Bitmap bm = new Bitmap(memostream, false);
            memostream.Dispose();
            return bm;
        }

     

        string gioitinh ()
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
 

        private void dgvgiaovien_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            int r = dgvgiaovien.CurrentCell.RowIndex;
            txtmagv.Text = dgvgiaovien.Rows[r].Cells[0].Value.ToString();
            txttengiaovien.Text = dgvgiaovien.Rows[r].Cells[1].Value.ToString();
            txtngaynv.Text = dgvgiaovien.Rows[r].Cells[2].Value.ToString();
            txtdiachi.Text = dgvgiaovien.Rows[r].Cells[3].Value.ToString();
            txtmail.Text = dgvgiaovien.Rows[r].Cells[4].Value.ToString();
            txtdienthoai.Text = dgvgiaovien.Rows[r].Cells[5].Value.ToString();
            txtdonvi.Text = dgvgiaovien.Rows[r].Cells[6].Value.ToString();
            cbxlop.SelectedValue = dgvgiaovien.Rows[r].Cells[9].Value.ToString();
            cbxphong.SelectedValue = dgvgiaovien.Rows[r].Cells[10].Value.ToString();
            picngaygiang.Text = dgvgiaovien.Rows[r].Cells[11].Value.ToString();

            if (dgvgiaovien.Rows[r].Cells[8].Value is DBNull)
            {
                picgiaovien.Image = null;
                image = null;
            }
            else
            {
                picgiaovien.SizeMode = PictureBoxSizeMode.Zoom;
                picgiaovien.Image = bytetoimage((byte[])dgvgiaovien.Rows[r].Cells[8].Value);
                image = (byte[])dgvgiaovien.Rows[r].Cells[8].Value;
            }


            if (dgvgiaovien.Rows[r].Cells[7].Value.ToString() == "Nam")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }


        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (Them)
            {
                try
                {
                    // Thực hiện lệnh
                    giaovien blGV = new giaovien();
                    phancong pcGV = new phancong();
                    bool thoiviec = false;
                    blGV.ThemGV(this.txtmagv.Text, this.txttengiaovien.Text, this.txtngaynv.Value, this.txtdiachi.Text, this.txtmail.Text, this.txtdienthoai.Text, this.txtdonvi.Text, gioitinh(), image, thoiviec, ref err);
                    pcGV.themphancong(txtmagv.Text, cbxlop.SelectedValue.ToString(), cbxphong.SelectedValue.ToString(), picngaygiang.Value, ref err);
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
                    giaovien blGV = new giaovien();
                    phancong pcGV = new phancong();
                    pcGV.suaphancong(txtmagv.Text, cbxlop.SelectedValue.ToString(), cbxphong.SelectedValue.ToString(), picngaygiang.Value, ref err);
                    blGV.CapNhatGV(this.txtmagv.Text, this.txttengiaovien.Text, this.txtdiachi.Text, this.txtngaynv.Value, this.txtmail.Text, this.txtdienthoai.Text, this.txtdonvi.Text, gioitinh(), image, ref err); ;

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
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Them = true;
            co = 2;
            reset();
            btnCapNhat.Enabled = true;
            btnHuy.Enabled = true;
            plthongtin.Enabled = true;
            btnThem.Enabled = false;
            btnsua.Enabled = false;
            btnXoa.Enabled = false;
            plphancong.Enabled = true;
            txtmagv.Focus();


        }
        void reset()
        {
            txtdiachi.ResetText();
            txtdienthoai.ResetText();
            txtdonvi.ResetText();
            txtmagv.ResetText();
            txtmail.ResetText();
            txtngaynv.ResetText();
            txttengiaovien.ResetText();
            picgiaovien.Image = null;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {


            Them = false;
            co = 2;
            plthongtin.Enabled = true;
            plphancong.Enabled = true;
            dgvgiaovien_CellClick_1(null, null);
            btnHuy.Enabled = true;
            btnCapNhat.Enabled = true;
            btnThem.Enabled = false;
            btnsua.Enabled = false;
            btnXoa.Enabled = false;
            txtmagv.Enabled = false;
            cbxlop.Enabled = false;
            txttengiaovien.Focus();
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtmagv.Enabled = true;
            cbxlop.Enabled = true;
            btnsua.Enabled = true;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            txttimkiem.Enabled = true;
            txttimkiem.ResetText();
            loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Thực hiện lệnh
                // Lấy thứ tự record hiện hành
                int r = dgvgiaovien.CurrentCell.RowIndex;
                // Lấy MaKH của record hiện hành
                string strGV = dgvgiaovien.Rows[r].Cells[0].Value.ToString();
                // Viết câu lệnh SQL
                // Hiện thông báo xác nhận việc xóa mẫu tin
                // Khai báo biến traloi
                DialogResult traloi;
                // Hiện hộp thoại hỏi đáp
                traloi = MessageBox.Show("Chắc xóa giáo viên này không?", "Trả lời",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra có nhắp chọn nút Ok không?
                if (traloi == DialogResult.Yes)
                {
                    giaovien blGV = new giaovien();
                    blGV.XoaGV(ref err, strGV);
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

        private void picgiaovien_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All file|*.*";
            string path = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.FileName.ToString();
                picgiaovien.SizeMode = PictureBoxSizeMode.Zoom;
                //  picgiaovien.ImageLocation = path;

            }
            if (path != "")
            {
                //  FileStream stream =FileStream()
                FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
                BinaryReader docfile = new BinaryReader(stream);
                image = docfile.ReadBytes((int)stream.Length);
                picgiaovien.Image = bytetoimage(image);

            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataView dv;
            dv = new DataView(dtGV);
            dgvgiaovien.DataSource = dv;
            autocompletestring();
            dv.RowFilter = string.Format("[HoTenGV] like '%{0}%'", txttimkiem.Text);
        }

        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tengiaovien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvgiaovien.Rows.Count-1; i++)
                {
                    tengiaovien.Add(dgvgiaovien.Rows[i].Cells[1].Value.ToString());
                }
                txttimkiem.AutoCompleteCustomSource = tengiaovien;
            }
            catch(Exception )
            {
                MessageBox.Show("sai");

            }
           
        }

       
        public void loadgiaovien(int trang)
        {
            int sodongtrentrang = 6;
            numsotrang.Minimum = 1;
            int skiprows = (trang - 1) * sodongtrentrang;
            dtGV = new DataTable();
            dtGV.Clear();
            DataSet ds = dbGV.LayGV();
            dtGV = ds.Tables[0];
            DataTable dt = dtGV;
            int sotrang = dt.Rows.Count/ sodongtrentrang + 1;
            numsotrang.Maximum = sotrang;
            DataTable dtt = new DataTable();
            dtt = dt.Select().Skip(skiprows).Take(sodongtrentrang).CopyToDataTable();
            dgvgiaovien.DataSource=dtt;
        
        }

        private void numsotrang_ValueChanged(object sender, EventArgs e)
        {

            int sotrang = Convert.ToInt32(numsotrang.Value);
            loadgiaovien(sotrang);
        }
        private void txtmagv_Leave(object sender, EventArgs e)
        {
            giaovien a = new giaovien();
            DataSet kiemtra = new DataSet();
            kiemtra = a.kiemtra(txtmagv.Text);
            if (kiemtra.Tables[0].Rows.Count != 0)
            {
                MessageBox.Show("Mã Giáo Viên đã tồn tại.vui lòng nhập lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtmagv.ResetText();
                txtmagv.Focus();

            }
        }

        private void txtmagv_TextChanged(object sender, EventArgs e)
        {

        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
