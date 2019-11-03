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
    public partial class UCgiaovienthoiviec : UserControl
    {
        public UCgiaovienthoiviec()
        {
            InitializeComponent();
        }   
        void loadgiaovien()
        {
            dgvgiaovienthoiviec.DataSource =giaovienthoiviec.loadgiaovien ();
            dgvgiaovienthoiviec.Columns["Ảnh"].Visible = false;
            //  dgvgiaovien.Columns["MãGV"].Width= 3000;
            dgvgiaovienthoiviec.AutoResizeColumns();
            dgvgiaovienthoiviec_CellClick(null, null);
            autocompletestring();
        }

        private void UCgiaovienthoiviec_Load(object sender, EventArgs e)
        {
            loadgiaovien();
        }

        private void dgvgiaovienthoiviec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvgiaovienthoiviec.CurrentCell.RowIndex;
            txtmagv.Text = dgvgiaovienthoiviec.Rows[r].Cells[0].Value.ToString();
            txttengiaovien.Text = dgvgiaovienthoiviec.Rows[r].Cells[1].Value.ToString();
            txtdiachi.Text = dgvgiaovienthoiviec.Rows[r].Cells[2].Value.ToString();
           txtdienthoai.Text = dgvgiaovienthoiviec.Rows[r].Cells[3].Value.ToString();
            txtdonvi.Text = dgvgiaovienthoiviec.Rows[r].Cells[4].Value.ToString();
      
            if (dgvgiaovienthoiviec.Rows[r].Cells[5].Value is DBNull)
            {
                picgiaovien.Image = null;
             
            }
            else
            {
                picgiaovien.SizeMode = PictureBoxSizeMode.Zoom;
                picgiaovien.Image = bytetoimage((byte[])dgvgiaovienthoiviec.Rows[r].Cells[5].Value);
            }
        }
        public static Bitmap bytetoimage(byte[] anh)
        {
            MemoryStream memostream = new MemoryStream();
            memostream.Write(anh, 0, Convert.ToInt32(anh.Length));
            Bitmap bm = new Bitmap(memostream, false);
            memostream.Dispose();
            return bm;
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataView dv = new DataView(giaovienthoiviec.loadgiaovien());
            dgvgiaovienthoiviec.DataSource = dv;
            dv.RowFilter = string.Format("[Họ Tên] like'%{0}%'", txttimkiem.Text);
        }
        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tengiaovien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvgiaovienthoiviec.Rows.Count - 1; i++)
                {
                    tengiaovien.Add(dgvgiaovienthoiviec.Rows[i].Cells[1].Value.ToString());
                }
                txttimkiem.AutoCompleteCustomSource = tengiaovien;
            }
            catch (Exception  )
            {
                MessageBox.Show("sai");

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int r = dgvgiaovienthoiviec.CurrentCell.RowIndex;
                string strmagiaovien = dgvgiaovienthoiviec.Rows[r].Cells[0].Value.ToString();
                DialogResult traloi;
                traloi = MessageBox.Show("Bạn có chắc xóa vĩnh viễn giáo viên này không? ", "Thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (traloi == DialogResult.Yes)
                {
                    giaovienthoiviec.xoagiaovien(strmagiaovien);
                    loadgiaovien();
                    MessageBox.Show("Đã xóa xong!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không xóa được,lỗi!");
            }
        }
    }
}
