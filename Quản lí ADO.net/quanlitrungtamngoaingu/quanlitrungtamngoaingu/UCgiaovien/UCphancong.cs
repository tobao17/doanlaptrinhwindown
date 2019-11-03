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

namespace quanlitrungtamngoaingu.UCgiaovien
{
    public partial class UCphancong : UserControl
    {
        bool them = false;
        DataTable dtPCGD = null;
        string err;
        //bool Them;
        phanconggiangday dbPCGD = new phanconggiangday();
        // bool co = false; // dung de load cbx
        public UCphancong()
        {
           
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                dtPCGD = new DataTable();
                dtPCGD.Clear();
                DataSet ds = dbPCGD.LoadPhanCong();
                dtPCGD = ds.Tables[0];
                // Đưa dữ liệu lên DataGridView
                dgvphancong.DataSource = dtPCGD;
                dgvphancong.AutoResizeColumns();
                lớp Lop = new lớp();
                DataTable dtLOP = new DataTable();
                dtLOP.Clear();
                DataSet ds2 = Lop.LoadLop2();
                dtLOP = ds2.Tables[0];
                cbxlop.DataSource = dtLOP;
                cbxlop.ValueMember = "MaLop";
                cbxlop.DisplayMember = "TenLop";
                dgvphancong_CellClick(null, null);
            }
            catch (Exception)
            {
                MessageBox.Show("loi");
            }
        }

        private void UCphancong_Load(object sender, EventArgs e)
        {
            loaddata();
            cbxlop.ResetText();
            autocompletestring();
        }

        private void dgvphancong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int r = dgvphancong.CurrentCell.RowIndex;
                txtmagv.Text = dgvphancong.Rows[r].Cells[0].Value.ToString();
                txttengiaovien.Text = dgvphancong.Rows[r].Cells[1].Value.ToString();
                txtdienthoai.Text = dgvphancong.Rows[r].Cells[2].Value.ToString();
                txtlop.Text = dgvphancong.Rows[r].Cells[3].Value.ToString();
                txtphong.Text = dgvphancong.Rows[r].Cells[4].Value.ToString();
                picngaygiang.Text = dgvphancong.Rows[r].Cells[5].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("lỗi");
            }

        }
        void autocompletestring()
        {
            try
            {
                AutoCompleteStringCollection tengiaovien = new AutoCompleteStringCollection();
                for (int i = 0; i < dgvphancong.Rows.Count - 1; i++)
                {
                    tengiaovien.Add(dgvphancong.Rows[i].Cells[1].Value.ToString());
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
           // dv = new DataView(dtPCGD);
            if (cbxlop.Text == "")
            {
                dtPCGD = new DataTable();
                dtPCGD.Clear();
                DataSet ds = dbPCGD.LoadPhanCong();
                dtPCGD = ds.Tables[0];
                dv = new DataView(dtPCGD);

            }
            else
            {
                dtPCGD = new DataTable();
                dtPCGD.Clear();
                DataSet ds1 = dbPCGD.LoadPhanCongTheoLop(cbxlop.Text);
                dtPCGD = ds1.Tables[0];
                dv = new DataView(dtPCGD);
                
                
            }
            dgvphancong.DataSource = dv ;
            autocompletestring();
            dv.RowFilter = string.Format("[hotenGV] like '%{0}%'", txttimkiem.Text);

        }
      
        
        private void cbxlop_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataView dv;
            //dv = new DataView(phanconggiangday.loadphancongtheolop(cbxlop.Text));
            //dgvphancong.DataSource = dv;
            //autocompletestring();


        }

        private void cbxlop_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
