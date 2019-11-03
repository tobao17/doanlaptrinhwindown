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
    class giaovien
    {
        public static DataTable loadgiaovien()
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
                          p.NgaySinh,
                          p.DiaChi,
                          p.Mail,
                          p.SoDT,
                          p.DonViCongTac,
                          p.GioiTinh,
                          p.Anh,
                          malop = s.MaLop == null ? "" : s.MaLop,
                          phong = s.Phong == null ? "" : s.Phong,
                          ngayday = s.ngayday,
                      };
          
            DataTable dt = new DataTable();
            dt.Columns.Add("MãGV");
            dt.Columns.Add("Họ Tên");
            dt.Columns.Add(new DataColumn("Ngày sinh", typeof(DateTime)));
            dt.Columns.Add("Địa Chỉ");
            dt.Columns.Add("Mail");
            dt.Columns.Add("Số Điện Thoại");
            dt.Columns.Add("Đơn vị");
            dt.Columns.Add("Giới Tính");
           //dt.Columns.Add("Ảnh");
            dt.Columns.Add(new DataColumn("Ảnh", typeof(byte[])));
            dt.Columns.Add("Mã lớp ");
            dt.Columns.Add("Phòng ");
            dt.Columns.Add(new DataColumn("Ngày Giảng dạy", typeof(DateTime)));
            foreach (var q in gvs)
            {
                dt.Rows.Add(q.MaGV, q.HoTenGV, q.NgaySinh, q.DiaChi, q.Mail, q.SoDT, q.DonViCongTac, q.GioiTinh,q.Anh,q.malop,q.phong,q.ngayday);    
            }
            return dt;
        }
        public static bool kiemtra (string magv)
        {
            int dem = 0;
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.GIAOVIENs
                      where p.MaGV == magv
                      select p;
            DataTable dt = new DataTable();
            foreach ( var p in gvs)
            {
                dem++;
            }
            if (dem == 0)
                return true;
            return false;
        }
        public static bool themgiaovien (string magv, string hoten, DateTime ngaysinh, string diachi, string mail, string sdt, string donvi, string gioitinh, byte[] anh)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            GIAOVIEN gv = new GIAOVIEN();
            gv.MaGV = magv;
            gv.HoTenGV = hoten;
            gv.NgaySinh = ngaysinh;
            gv.DiaChi = diachi;
            gv.Mail = mail;
            gv.SoDT = sdt;
            gv.DonViCongTac = donvi;
            gv.GioiTinh = gioitinh;
            gv.Anh = anh;
            gv.Thoiviec = false;//de mac dinh khong thoi viec
            qltt.GIAOVIENs.Add(gv);
            qltt.SaveChanges();
           return true;
        }
        public static bool xoagiaovien(string magv)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            GIAOVIEN gv = new GIAOVIEN();
             gv.MaGV = magv;
            qltt.GIAOVIENs.Attach(gv);
            //qltt.GIAOVIENs.Remove(gv);
            gv.Thoiviec = true;
            qltt.SaveChanges();
            return true;

        }
        public static bool suagiaovien(string magv, string hoten, DateTime ngaysinh, string diachi, string mail, string sdt, string donvi, string gioitinh, byte[] anh)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var gv = (from GV in qltt.GIAOVIENs 
             where GV.MaGV == magv select GV).SingleOrDefault();
            if (magv!=null)
            {
                gv.HoTenGV = hoten;
                gv.NgaySinh = ngaysinh;
                gv.DiaChi = diachi;
                gv.Mail = mail;
                gv.SoDT = sdt;
                gv.DonViCongTac = donvi;
                gv.GioiTinh = gioitinh;
                gv.Anh = anh;
                qltt.SaveChanges();
            }
            return true;
        }      
    }
}
