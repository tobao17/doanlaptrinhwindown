using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using quanlitrungtamngoaingu.Dataaccesslayer;
namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class chungchi
    {
        public static DataTable loadchungchi()
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.CHUNGCHIs
                      where p.Mota!= "DA XOA"
                      select new
                      {
                          p.MaChungChi,
                          p.TenChungChi,
                          p.HocPhi,
                          p.Mota
                      };

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Chứng Chỉ");
            dt.Columns.Add("Tên Chứng Chỉ");
            dt.Columns.Add("Học Phí");
            dt.Columns.Add("Mô Tả");

            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaChungChi, q.TenChungChi, q.HocPhi, q.Mota);
            }
            return dt;
        }

        public static bool kiemtra(string macc)
        {
            int dem = 0;
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.CHUNGCHIs
                      where p.MaChungChi == macc
                      select p;
            DataTable dt = new DataTable();
            foreach (var p in gvs)
            {
                dem++;
            }
            if (dem == 0)
                return true;
            return false;


        }
        public static bool themchungchi(string macc, string tenchungchi, string hocphi, string mota)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            CHUNGCHI gv = new CHUNGCHI();
            gv.MaChungChi = macc;
            gv.TenChungChi = tenchungchi;
            gv.HocPhi = hocphi;
            gv.Mota = mota;
            qltt.CHUNGCHIs.Add(gv);
            qltt.SaveChanges();
            return true;
        }
        public static bool xoachungchi(string macc)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            CHUNGCHI gv = new CHUNGCHI();
            gv.MaChungChi = macc;
            qltt.CHUNGCHIs.Attach(gv);
            gv.Mota= "DA XOA";
            qltt.SaveChanges();
            return true;

        }
        public static bool suachungchi(string macc, string tenchungchi, string hocphi, string mota)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var gv = (from GV in qltt.CHUNGCHIs
                      where GV.MaChungChi == macc
                      select GV).SingleOrDefault();
            if (macc != null)
            {
                gv.TenChungChi = tenchungchi;
                gv.HocPhi = hocphi;
                gv.Mota = mota;

                qltt.SaveChanges();
            }
            return true;
        }
    }
}
