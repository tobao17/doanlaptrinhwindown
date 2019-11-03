using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class Danhsachhocvien
    {
        public static DataTable loadhocvien()
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.HOCVIENs
                      where p.nghihoc!=true
                      select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Học Viên");
            dt.Columns.Add("Tên Học Viên");
            dt.Columns.Add("Giới Tính");
            dt.Columns.Add("Điện Thoại");
            dt.Columns.Add(new DataColumn("Ngày sinh", typeof(DateTime)));
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("Mail");
            dt.Columns.Add("Đơn Vị");
            dt.Columns.Add("Mã Lớp");
            dt.Columns.Add("Mã kết quả");

            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaHV, q.HoTenHV, q.GioiTinh, q.SoDT, q.NgaySinh, q.DiaChi,
                    q.Mail, q.DonViCongTac, q.MaLop, q.MaKQ);
            }
            return dt;
        }
        public static bool themhocvien(string mahv, string hoten, string gioitinh, string sdt, DateTime ngaysinh,
            string diachi, string mail,  string donvi,  string malop ,string makq)
        {
            try
            {
                QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
                HOCVIEN hv = new HOCVIEN();
                hv.MaHV = mahv;
                hv.HoTenHV = hoten;
                hv.GioiTinh = gioitinh;
                hv.SoDT = sdt;
                hv.NgaySinh = ngaysinh;
                hv.DiaChi = diachi;
                hv.Mail = mail;
                hv.DonViCongTac = donvi;
                hv.MaLop = malop;
                hv.MaKQ = makq;
                hv.nghihoc = false;//de mac dinh khong nghi hoc
                qltt.HOCVIENs.Add(hv);
                qltt.SaveChanges();
                hv.nghihoc = null;


            }
            catch(Exception  )
            {
                
            }
            return true;

        }
        public static bool xoahocvien(string mahv)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            HOCVIEN hv = new HOCVIEN();
            hv.MaHV = mahv;
            qltt.HOCVIENs.Attach(hv);
            //qltt.GIAOVIENs.Remove(gv);
            hv.nghihoc = true;
            qltt.SaveChanges();
            return true;

        }
      
        public static bool suahocvien(string mahv, string hoten, string gioitinh, string sdt, DateTime ngaysinh,
           string diachi, string mail, string donvi, string malop, string makq)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var hv = (from hvien in qltt.HOCVIENs
                      where hvien.MaHV == mahv
                      select hvien).SingleOrDefault();
            if (mahv != null)
            {
                hv.HoTenHV = hoten;
                hv.GioiTinh = gioitinh;
                hv.SoDT = sdt;
                hv.NgaySinh = ngaysinh;
                hv.DiaChi = diachi;
                hv.Mail = mail;
                hv.DonViCongTac = donvi;
                hv.MaLop = malop;
                hv.MaKQ = makq;
                qltt.SaveChanges();
            }
            return true;
        }
        public static bool kiemtrahocvien(string mahv)
        {
            int dem = 0;
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.HOCVIENs
                      where p.MaHV == mahv
                      select p;
          //  DataTable dt = new DataTable();
            foreach (var p in gvs)
            {
                dem++;
            }
            if (dem == 0)
                return true;
            return false;
        }
        public static bool kiemtraMaketqua(string makq)
        {
            int dem = 0;
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.HOCVIENs
                      where p.MaKQ == makq
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
    }

}
