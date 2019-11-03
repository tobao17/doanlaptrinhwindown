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
        DataTable dtGVTV = null;
        string err;
        byte[] image = null;
        giaovienthoiviec dbGVTV = new giaovienthoiviec();
        public UCgiaovienthoiviec()
        {
            InitializeComponent();
        }   
        void loadgiaovien()
        {
            dtGVTV = new DataTable();
            dtGVTV.Clear();
            DataSet ds = dbGVTV.LayGV();
            dtGVTV = ds.Tables[0];
            // Đưa dữ liệu lên DataGridView
            dgvgiaovienthoiviec.DataSource = dtGVTV;
            dgvgiaovienthoiviec.Columns["Anh"].Visible = false;
            // Thay đổi độ rộng cột
            dgvgiaovienthoiviec.AutoResizeColumns();
            dgvgiaovienthoiviec_CellClick(null, null);
        }

        private void UCgiaovienthoiviec_Load(object sender, EventArgs e)
        {
            loadgiaovien();
            autocompletestring();
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
            DataView dv;
            dv = new DataView(dtGVTV);
            dgvgiaovienthoiviec.DataSource = dv;
            autocompletestring();
            dv.RowFilter = string.Format("[HoTenGV] like '%{0}%'", txttimkiem.Text);
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
            
        }
    }
}
