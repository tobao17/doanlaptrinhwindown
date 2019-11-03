using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;


namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class lớp
    {
        public static DataTable loadlop()
        {
            QuanLyTrungTamAnhVanEntities1 qltrungtamentity = new QuanLyTrungTamAnhVanEntities1();
            var gvs = from p in qltrungtamentity.LOPs
                       select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Lớp");
            dt.Columns.Add("Tên Lớp");
            dt.Columns.Add("Chứng Chỉ");
            dt.Columns.Add("Phòng");
            dt.Columns.Add("Thời Gian Học");
           
            dt.Columns.Add("Sỉ số");
            dt.Columns.Add("khuyến mãi");
           

            foreach (var q in gvs)
            {
                try
                {
                    dt.Rows.Add(q.MaLop, q.TenLop, q.CHUNGCHI.TenChungChi, q.PHONGHOC.TenPhong, q.THOIGIANHOC.ThoiGianHoc1,  q.SiSo, q.KHUYENMAI.TenKM);
                }
                catch(Exception)
                {
                    return null;
                }
               
            }
            return dt;
        }
        public static bool sualop(string malop, string tenlop, string siso, string Makhuyenmai, string maphong, string machungchi, string mathoigian)
        {
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var newlop = (from  lop in qltt.LOPs
                      where lop.MaLop == malop
                      select lop).SingleOrDefault();
            if (malop!= null)
            {
                newlop.TenLop = tenlop;
                newlop.SiSo = siso;
                newlop.MaKM = Makhuyenmai;
                newlop.MaPhong = maphong;
                newlop.MaChungChi = machungchi;
                newlop.MaThoiGian = mathoigian;
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
        public static bool kiemtraphong(string maphong,string mathoigian)
        {
            int dem = 0;
            QuanLyTrungTamAnhVanEntities1 qltt = new QuanLyTrungTamAnhVanEntities1();
            var newlop = from p in qltt.LOPs
                          where p.MaPhong == maphong && p.MaThoiGian == mathoigian
                          select p;
            foreach(var p in newlop)
            {
                dem++;
            }
            if (dem == 0)
                return true;
            else
                return false;

        }
    }
}
