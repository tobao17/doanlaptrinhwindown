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



namespace quanlitrungtamngoaingu.UCgiaovien
{
  
    public partial class Ucdanhsachgiaovien : UserControl
    {
        bool them = false;
        byte[] image = null;
        DataView dv = null;
        public Ucdanhsachgiaovien()
        {
            InitializeComponent();
        }
       
        void loaddata()
        {
            try
            {
                dgvgiaovien.DataSource = giaovien.loadgiaovien();
                dgvgiaovien.Columns["Ảnh"].Visible = false;
              //  dgvgiaovien.Columns["MãGV"].Width= 3000;
               dgvgiaovien.AutoResizeColumns();
                dgvgiaovien_CellClick_1(null, null);
                dv = new DataView(giaovien.loadgiaovien());
                cbxphong.DataSource = Phonghoc.loadphonghoc();
                cbxphong.ValueMember =  "Mã Phòng";
                cbxphong.DisplayMember = "Tên Phòng";
                // enabledtextbox();
                autocompletestring();
                cbxlop.DataSource = lớp.loadlop();
                cbxlop.ValueMember = "Mã Lớp";
                cbxlop.DisplayMember = "Tên Lớp";
                btnCapNhat.Enabled = false;
                btnHuy.Enabled = false;
                //  plthongtin.Enabled = false;
                txtdiachi.Enabled = false;
                plphancong.Enabled = false;
                btnThem.Enabled = true;
                btnsua.Enabled = true;
                //.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch(Exception)
            {
                MessageBox.Show("loi");
            }
        }

        private void Ucdanhsachgiaovien_Load(object sender, EventArgs e)
        {
            loaddata();
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
            cbxlop.SelectedValue= dgvgiaovien.Rows[r].Cells[9].Value.ToString();
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
            if (them)
            {
                try
                {
                    giaovien.themgiaovien(txtmagv.Text, txttengiaovien.Text, txtngaynv.Value, txtdiachi.Text,
                        txtmail.Text, txtdienthoai.Text, txtdonvi.Text, gioitinh(), image);
                    phancong.themphancong(txtmagv.Text, cbxlop.SelectedValue.ToString(), cbxphong.SelectedValue.ToString(), picngaygiang.Value);
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
                    phancong.suaphancong(txtmagv.Text, cbxlop.SelectedValue.ToString(), cbxphong.SelectedValue.ToString(), picngaygiang.Value);
                    giaovien.suagiaovien(txtmagv.Text, txttengiaovien.Text, txtngaynv.Value, txtdiachi.Text,
                        txtmail.Text, txtdienthoai.Text, txtdonvi.Text, gioitinh(), image);
         
                    loaddata();
                    MessageBox.Show("sửa thành công!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Sửa thất bại");
                }
            }
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
            them = false;
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
            loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvgiaovien.CurrentCell.RowIndex;
                string strmagiaovien = dgvgiaovien.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi==DialogResult.Yes)
                {
                    giaovien.xoagiaovien(strmagiaovien);
                    loaddata();
                    MessageBox.Show("Đã xóa xong!");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Không xóa được,lỗi!");
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
            dgvgiaovien.DataSource = dv;
            dv.RowFilter=string.Format("[Họ Tên] like '%{0}%'", txttimkiem.Text);
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
            catch(Exception ce)
            {
                MessageBox.Show("sai");

            }
           
        }

        public void loadsotrang()
        {
            int sodongtrentrang = 6;
            int sotrang = dgvgiaovien.RowCount / sodongtrentrang + 1;
            numsotrang.Minimum = 1;
            numsotrang.Maximum = sotrang;

        }
        public void loadgiaovien(int trang)
        {

            int sodongtrentrang = 6;
            int skiprows = (trang - 1) * sodongtrentrang;
            DataTable dt = giaovien.loadgiaovien();
            DataTable dtt = new DataTable();
            dtt = dt.Select().Skip(skiprows).Take(sodongtrentrang).CopyToDataTable();
            dgvgiaovien.DataSource=dtt;
        
        }

        private void numsotrang_ValueChanged(object sender, EventArgs e)
        {
            loadsotrang();
            int sotrang = Convert.ToInt32(numsotrang.Value);
            loadgiaovien(sotrang);
        }

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
