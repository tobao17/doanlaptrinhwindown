using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;
namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class Phonghoc
    {
        public static DataTable loadphonghoc()
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.PHONGHOCs
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Phòng");
            dt.Columns.Add("Tên Phòng");
            dt.Columns.Add("Số lượng ghế");
            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaPhong, q.TenPhong, q.SoLuongGhe);
            }
            return dt;

        }
    }
}
