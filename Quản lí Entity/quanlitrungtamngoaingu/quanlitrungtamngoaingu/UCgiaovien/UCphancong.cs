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
       // bool co = false; // dung de load cbx
        public UCphancong()
        {
           
            InitializeComponent();
        }
        void loaddata()
        {
            try
            {
                dgvphancong.DataSource = phanconggiangday.loadphancong();
               dgvphancong.AutoResizeColumns();
                dgvphancong_CellClick(null, null);
                cbxlop.DataSource = lớp.loadlop();      
                cbxlop.ValueMember = "Mã Lớp";
                cbxlop.DisplayMember = "Tên Lớp";
                autocompletestring();
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
        }

        private void dgvphancong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvphancong.CurrentCell.RowIndex;
            txtmagv.Text = dgvphancong.Rows[r].Cells[0].Value.ToString();
            txttengiaovien.Text = dgvphancong.Rows[r].Cells[1].Value.ToString();
            txtdienthoai.Text = dgvphancong.Rows[r].Cells[2].Value.ToString();
            txtlop.Text = dgvphancong.Rows[r].Cells[3].Value.ToString();
            txtphong.Text= dgvphancong.Rows[r].Cells[4].Value.ToString();
            picngaygiang.Text = dgvphancong.Rows[r].Cells[5].Value.ToString();

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
            catch (Exception )
            {
                MessageBox.Show("sai");

            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            DataView dv;
           
            if (cbxlop.Text == "")
            {
                dv = new DataView(phanconggiangday.loadphancong());

            }
            else
            {
                dv = new DataView(phanconggiangday.loadphancongtheolop((string)cbxlop.Text));
                
            }
            dgvphancong.DataSource = dv ;
            autocompletestring();
            dv.RowFilter = string.Format("[Họ Tên] like '%{0}%'", txttimkiem.Text);

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
