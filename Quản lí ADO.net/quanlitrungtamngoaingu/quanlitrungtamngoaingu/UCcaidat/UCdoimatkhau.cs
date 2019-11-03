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

namespace quanlitrungtamngoaingu.UCcaidat
{
    public partial class UCdoimatkhau : UserControl
    {
        public UCdoimatkhau()
        {
            InitializeComponent();
        }

        private void pldoimatkhau_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtoldpass_Leave(object sender, EventArgs e)
        {
            doimatkhau a = new doimatkhau();
            DataSet b = new DataSet();
            b = a.kiemtramatkhau(txttendangnhap.Text, txtoldpass.Text);
            if (b.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("Tên tài khoản/Mật khẩu không chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    doimatkhau.suamk(txttendangnhap.Text, txtnewpass.Text);
            //    MessageBox.Show("Đổi Mật Khẩu Thành Công");
            //}
            //catch
            //{
            //    MessageBox.Show("Không Đổi được!lỗi rồi ");
            //}
           
        }
    }
}
