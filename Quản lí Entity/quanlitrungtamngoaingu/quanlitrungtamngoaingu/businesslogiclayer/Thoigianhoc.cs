using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class Thoigianhoc
    {
        public static DataTable loadthoigian()
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.THOIGIANHOCs
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Thời Gian");
            dt.Columns.Add("Thời Gian");
            foreach (var q in gvs)
            {
                try
                {
                    dt.Rows.Add(q.MaThoiGian,q.ThoiGianHoc1);
                }
                catch (Exception)
                {
                    return null;
                }

            }
            return dt;
        }
        public static DataTable loadthoigianbieucholop()
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.LOPs
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Lớp");
            dt.Columns.Add("Phòng");
            dt.Columns.Add("Mã Thời Gian");
            dt.Columns.Add("Thời Gian");
          

            foreach (var q in gvs)
            {
                try
                {
                    dt.Rows.Add(q.TenLop,q.PHONGHOC.TenPhong,q.THOIGIANHOC.MaThoiGian,q.THOIGIANHOC.ThoiGianHoc1);
                }
                catch (Exception)
                {
                    return null;
                }

            }
            return dt;
        }
    }
}
