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
using quanlitrungtamngoaingu.UCThongke;

namespace quanlitrungtamngoaingu.UChocvien
{

    public partial class UCdiemso : UserControl
    {
        int them ;
        public UCdiemso()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                dgvdiemso.DataSource = ketquahoctap.loadketqua();
                dgvdiemso.AutoResizeColumns();
                dgvdiemso_CellClick(null, null);
                //  plthongtin.Enabled = false;
                txtmaketqua.Enabled = false;
                txttenhocvien.Enabled = false;
                autocompletestring();
            }
            catch (Exception)
            {
                MessageBox.Show("loi");
            }
        }

        private void dgvdiemso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
           // txtxeploai.Text = dgvdiemso.Rows[r].Cells[8].Value.ToString();
        }

        private void UCdiemso_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void btncapnhat_Click(object sender, EventArgs e)
        {
           // ketquahoctap.suaketquahoctap(txtmaketqua,)
           try
            {
                ketquahoctap.suaketquahoctap(txtmaketqua.Text, txtnguphap.Text, txtgiaotiep.Text,
                    txtchuyencan.Text, txtkynang.Text, txtbaitap.Text, txtdinhky.Text);
                loaddata();
                MessageBox.Show("Cập nhật Thành Công!");
            }
            catch
            {
                MessageBox.Show("không cập nhật được.Lỗi!");
            }
        }
 
        private void dgvdiemso_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            int r = dgvdiemso.CurrentCell.RowIndex;
            txtmaketqua.Text = dgvdiemso.Rows[r].Cells[0].Value.ToString();
            txttenhocvien.Text = dgvdiemso.Rows[r].Cells[1].Value.ToString();
            txtnguphap.Text = dgvdiemso.Rows[r].Cells[2].Value.ToString();
            txtgiaotiep.Text = dgvdiemso.Rows[r].Cells[3].Value.ToString();
            txtchuyencan.Text = dgvdiemso.Rows[r].Cells[4].Value.ToString();
            txtkynang.Text = dgvdiemso.Rows[r].Cells[5].Value.ToString();
            txtbaitap.Text = dgvdiemso.Rows[r].Cells[6].Value.ToString();
            txtdinhky.Text = dgvdiemso.Rows[r].Cells[7].Value.ToString();
            txtxeploai.Text= dgvdiemso.Rows[r].Cells[8].Value.ToString();
            if (dgvdiemso.Rows[r].Cells[2].Value.ToString() == ""&& dgvdiemso.Rows[r].Cells[0].Value.ToString() != "")
            {
                txtxeploai.ResetText();
                MessageBox.Show("Bạn Cần cập nhật điểm số cho học sinh này!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txtnguphap.Focus();
                them = 1;
                
            }
            else
            {
                them = 2;
            }
        }
        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tengiaovien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvdiemso.Rows.Count - 1; i++)
                {
                    tengiaovien.Add(dgvdiemso.Rows[i].Cells[1].Value.ToString());
                }
                txttimkiem.AutoCompleteCustomSource = tengiaovien;
            }
            catch (Exception)
            {
                MessageBox.Show("sai");

            }
        }

    


        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataView dv;

            dv = new DataView(ketquahoctap.loadketqua());
            dgvdiemso.DataSource = dv;
            autocompletestring();
            dv.RowFilter = string.Format("[Họ Tên] like '%{0}%'", txttimkiem.Text);
        }

        private void btnbangdiem_Click(object sender, EventArgs e)
        {
            
            FormKQHT f = new FormKQHT();
            f.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
