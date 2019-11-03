using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data;
using System.Data.SqlClient;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class Danhsachhocvien
    {
        DBMain db = null;
        //public static byte[] anh2 { get; set; }
        public Danhsachhocvien()
        {
            db = new DBMain();
        }
        public DataSet LayHV()
        {
            return db.ExecuteQueryDataSet("select MaHV,HoTenHV,GioiTinh,NgaySinh,DiaChi,Mail,SoDT,DonViCongTac,MaLop,MaKQ from HOCVIEN Where nghihoc =0 ", CommandType.Text);
        }
        public bool themhocvien(string mahv, string hoten, string gioitinh, string sdt, DateTime ngaysinh, string diachi, string mail, string donvi, string malop, string makq, bool thoihoc, ref string err)
        {
            return db.MyExecuteNonQuery2("ThemHV2", CommandType.StoredProcedure, ref err,
             new SqlParameter("@MaHV", mahv),
             new SqlParameter("@HoTenHV", hoten),
             new SqlParameter("@GioiTinh", gioitinh),
             new SqlParameter("@NgaySinh", ngaysinh),
             new SqlParameter("@DiaChi", diachi),
             new SqlParameter("@Mail", mail),
             new SqlParameter("@SoDT", sdt),
             new SqlParameter("@DonViCongTac", donvi),
             new SqlParameter("@MaLop", malop),
             new SqlParameter("@MaKetQua", makq),
             new SqlParameter("@nghihoc", thoihoc))
             ;
        }
        public DataSet kiemtra(string stringkiemtra)
        {
            return db.ExecuteQueryDataSet("Select * From hocvien Where MAHV='" + stringkiemtra + "'", CommandType.Text);
        }
        public bool XoaHV(ref string err, string MaHV)
        {
            return db.MyExecuteNonQuery2("XoaHV", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaHV", MaHV),
                   new SqlParameter("@nghihoc", '1'))
                ;
        }
        public bool CapNhatHV(string mahv, string hoten, string gioitinh, string sdt, DateTime ngaysinh, string diachi, string mail, string donvi, string malop, ref string err)
        {
            return db.MyExecuteNonQuery2("CapNhatHV2", CommandType.StoredProcedure, ref err,
            new SqlParameter("@MaHV", mahv),
            new SqlParameter("@HoTenHV", hoten),
            new SqlParameter("@GioiTinh", gioitinh),
            new SqlParameter("@NgaySinh", ngaysinh),
            new SqlParameter("@DiaChi", diachi),
            new SqlParameter("@Mail", mail),
            new SqlParameter("@SoDT", sdt),
            new SqlParameter("@DonViCongTac", donvi),
            new SqlParameter("@MaLop", malop))
            ;
        }
        public DataSet Find(string TenHV)
        {
            return db.ExecuteQueryDataSet("select MaHV,HoTenHV,GioiTinh,NgaySinh,DiaChi,Mail,SoDT,DonViCongTac,MaLop,MaKQ " +
                "from HOCVIEN  Where HoTenHV like '" + TenHV + "'", CommandType.Text);
        }
    }

}
