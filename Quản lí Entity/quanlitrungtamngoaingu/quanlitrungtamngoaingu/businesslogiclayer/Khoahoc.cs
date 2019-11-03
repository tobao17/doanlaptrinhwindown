using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class Khoahoc
    {
        
        public static DataTable loadkhoahoc()
        {

            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.HOCVIENs
                      join q in qltrungtamentity.KHOAs
                      on p.MaHV equals q.MaHV into gv
                      from s in gv.DefaultIfEmpty()
                      where p.nghihoc != true
                      //where p.MaGV == q.MaGV
                      select new
                      {
                          p.MaHV,
                          p.HoTenHV,
                          makhoa=s.MaKhoa==null?"":s.MaKhoa,
                          tenkoa=s.Khoa1==null?"":s.Khoa1,
                          ngaybatdau=s.NgayBatDau==null?"":s.NgayBatDau,
                          ngayketthuc=s.NgayKetThuc==null?"":s.NgayKetThuc
                      };

            DataTable dt = new DataTable();
            dt.Columns.Add("Mahs");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Mã KQ");
            
            dt.Columns.Add("Tên Khóa");
            dt.Columns.Add("Ngày Bắt Đầu");
            dt.Columns.Add("Ngày Kết Thúc");
         
            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaHV,q.HoTenHV, q.makhoa, q.tenkoa,  q.ngaybatdau, q.ngayketthuc);
            }
            return dt;
        }
        public static bool kiemtra(string mahv)
        {
            int dem = 0;
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.KHOAs
                      where p.MaKhoa == mahv
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
    
        public static DataTable loadkhoahoctheolop(string a)
        {

            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.HOCVIENs
                      join q in qltrungtamentity.KHOAs
                      on p.MaHV equals q.MaHV into gv
                      from s in gv.DefaultIfEmpty()
                      where p.nghihoc != true && s.Khoa1 == a
                      //where p.MaGV == q.MaGV
                      select new
                      {
                          p.MaHV,
                          p.HoTenHV,
                          makhoa = s.MaKhoa == null ? "" : s.MaKhoa,
                          tenkoa = s.Khoa1 == null ? "" : s.Khoa1,
                          ngaybatdau = s.NgayBatDau == null ? "" : s.NgayBatDau,
                          ngayketthuc = s.NgayKetThuc == null ? "" : s.NgayKetThuc
                      };

            DataTable dt = new DataTable();
            dt.Columns.Add("Mahs");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add("Mã KQ");

            dt.Columns.Add("Tên Khóa");
            dt.Columns.Add("Ngày Bắt Đầu");
            dt.Columns.Add("Ngày Kết Thúc");

            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaHV, q.HoTenHV, q.makhoa, q.tenkoa, q.ngaybatdau, q.ngayketthuc);
            }
            return dt;
        }
        public static bool suakhoahoc(string makhoa, string tenkhoa, string ngaybatdau, string ngayketthuc, string mahocvien)

        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var pc = (from PC in qltt.KHOAs
                      where PC.MaKhoa == makhoa
                      //   where PC.MaLop = malop
                      select PC).SingleOrDefault();
            if (makhoa != null)
            {

                // pc.MaLop = malop;
                pc.Khoa1 = tenkhoa;
                pc.NgayBatDau = ngaybatdau;
                pc.NgayKetThuc = ngayketthuc;
                pc.MaHV = mahocvien;
                qltt.SaveChanges();

            }
            return true;
        }
        public static bool themKhoahoc(string makhoa, string tenkhoa, string ngaybatdau,string ngayketthuc,string mahocvien)

        {
            try
            {
                QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
                KHOA kh = new KHOA();
                kh.MaKhoa = makhoa;
                kh.Khoa1 = tenkhoa;
                kh.NgayBatDau = ngaybatdau;
                kh.NgayKetThuc = ngayketthuc;
                kh.MaHV = mahocvien;
                qltt.KHOAs.Add(kh);
                qltt.SaveChanges();
            }
            catch (Exception a)
            {
                return true;
            }
            return true;

        }
    }
}
