using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;
namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class Khuyenmai
    {
        public static DataTable loadkhuyenmai()
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.KHUYENMAIs
                      where p.TenKM!= "DA XOA"
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Khuyến Mãi");
            dt.Columns.Add("Tên Khuyến Mãi");
            dt.Columns.Add(new DataColumn("Ngày Bắt Đầu", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("Ngày Kết Thúc", typeof(DateTime)));
            foreach (var q in gvs)
            {
                try
                {
                    dt.Rows.Add(q.MaKM, q.TenKM, q.NgayBatDauKM, q.NgayKetThucKM);
                }
                catch (Exception)
                {
                    return null;
                }

            }
            return dt;

        }
        public static bool kiemtra(string maKM)
        {
            int dem = 0;
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.KHUYENMAIs
                      where p.MaKM==maKM
                      select p;
          
            foreach (var p in gvs)
            {
                dem++;
            }
            if (dem == 0)
                return true;
            return false;


        }
        public static bool themkhuyenmai(string maKM, string TenKm, DateTime ngaybatdau, DateTime ngaykethuc)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            KHUYENMAI gv = new KHUYENMAI();
            gv.MaKM = maKM;
            gv.TenKM = TenKm;
            gv.NgayBatDauKM = ngaybatdau;
            gv.NgayKetThucKM= ngaykethuc;
            qltt.KHUYENMAIs.Add(gv);
            qltt.SaveChanges();
            return true;
        }
        public static bool xoakhuyenmai(string macc)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            KHUYENMAI km = new KHUYENMAI();
            km.MaKM = macc;
            qltt.KHUYENMAIs.Attach(km);
            km.TenKM = "DA XOA";
            qltt.SaveChanges();
            return true;

        }
        public static bool suakhuyenmai(string makm, string tenkhuyenmai, DateTime ngaybatdau, DateTime ngayketthuc)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var gv = (from GV in qltt.KHUYENMAIs
                      where GV.MaKM == makm
                      select GV).SingleOrDefault();
            if (makm != null)
            {
                gv.TenKM= tenkhuyenmai;
                gv.NgayBatDauKM = ngaybatdau;
                gv.NgayKetThucKM= ngayketthuc;

                qltt.SaveChanges();
            }
            return true;
        }
    }
}
