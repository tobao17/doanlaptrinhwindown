using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using quanlitrungtamngoaingu.Dataaccesslayer;
namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class phanconggiangday
    {
        public static DataTable loadphancong( )
        {
      
                QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.GIAOVIENs
                      join q in qltrungtamentity.PHANCONGs
                      on p.MaGV equals q.MaGV into gv
                      from s in gv.DefaultIfEmpty()                          
                          where p.Thoiviec != true
                          //where p.MaGV == q.MaGV
                          select new
                          {
                              p.MaGV,
                              p.HoTenGV,
                              p.SoDT,
                              malop = s.LOP.TenLop == null ? "" : s.LOP.TenLop,
                              phong = s.PHONGHOC.TenPhong == null ? "" : s.PHONGHOC.TenPhong,
                              ngayday = s.ngayday,
                          };
            DataTable dt = new DataTable();
            dt.Columns.Add("MãGV");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Số Điện Thoại");
            dt.Columns.Add("Tên lớp ");
            dt.Columns.Add("Phòng ");
            dt.Columns.Add(new DataColumn("Ngày Giảng dạy", typeof(DateTime)));
            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaGV, q.HoTenGV,  q.SoDT,  q.malop, q.phong, q.ngayday);
            }
            return dt;
        }

        public static DataTable loadphancongtheolop(string a)
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.GIAOVIENs
                      join q in qltrungtamentity.PHANCONGs
                      on p.MaGV equals q.MaGV into gv
                      from s in gv.DefaultIfEmpty()
                      where p.Thoiviec != true && s.LOP.TenLop== a
                      //where p.MaGV == q.MaGV
                      select new
                      {
                          p.MaGV,
                          p.HoTenGV,
                          p.SoDT,
                          malop = s.LOP.TenLop == null ? "" : s.LOP.TenLop,
                          phong = s.PHONGHOC.TenPhong == null ? "" : s.PHONGHOC.TenPhong,
                          ngayday = s.ngayday,
                      };
            DataTable dt = new DataTable();
            dt.Columns.Add("MãGV");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Số Điện Thoại");
            dt.Columns.Add("Tên lớp ");
            dt.Columns.Add("Phòng ");
            dt.Columns.Add(new DataColumn("Ngày Giảng dạy", typeof(DateTime)));
            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaGV, q.HoTenGV, q.SoDT, q.malop, q.phong, q.ngayday);
            }
            return dt;
        }
    }
}
