using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using quanlitrungtamngoaingu.Dataaccesslayer;
using System.Data.SqlClient;

namespace quanlitrungtamngoaingu.businesslogiclayer
{
    class giaovien
    {
        DBMain db = null;
        public static byte[] anh2 { get; set; }
        public giaovien()
        {
            db = new DBMain();
        }
        public DataSet LayGV()
        {
            //return db.ExecuteQueryDataSet("select GIAOVIEN.MaGV,HoTenGV,NgaySinh,DiaChi,Mail,SoDT,DonViCongTac,GioiTinh,Anh,MaLop,Phong,ngayday"+ 
            //    "from GIAOVIEN inner join PHANCONG on GIAOVIEN.MaGV = PHANCONG.MaGV Where Thoiviec = 0", CommandType.Text);
            return db.ExecuteQueryDataSet("select GIAOVIEN.MaGV,HoTenGV,NgaySinh,DiaChi,Mail,SoDT,DonViCongTac,GioiTinh,Anh,MaLop,Phong,ngayday" +
                " from GIAOVIEN left outer join PHANCONG on GIAOVIEN.MaGV = PHANCONG.MaGV where Thoiviec =0 ", CommandType.Text);
        }
        public bool ThemGV(string magv, string hoten, DateTime ngaysinh, string diachi, string mail, string sdt, string donvi, string gioitinh, byte[] anh, bool thoiviec, ref string err)
        {
            return db.MyExecuteNonQuery2("ThemGV2", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaGV", magv),
                new SqlParameter("@HoTenGV", hoten),
                 new SqlParameter("@NgaySinh", ngaysinh),
                  new SqlParameter("@DiaChi", diachi),
                   new SqlParameter("@Mail", mail),
                    new SqlParameter("@SoDT", sdt),
                     new SqlParameter("@DonViCongTac", donvi),
                      new SqlParameter("@GioiTinh", gioitinh),
                       new SqlParameter("@Anh", anh),
                          new SqlParameter("@Thoiviec", thoiviec))
           ;
        }
        public DataSet kiemtra(string stringkiemtra)
        {
            return db.ExecuteQueryDataSet("Select * From giaovien Where MAGV='" + stringkiemtra + "'", CommandType.Text);
        }
        public bool XoaGV(ref string err, string MaGV)
        {
            return db.MyExecuteNonQuery2("XoaGV2", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaGV", MaGV),
                   new SqlParameter("@Thoiviec", '1'))
                ;
        }
        public bool CapNhatGV(string MaGV, string TenGV, string DiaChi, DateTime NgaySinh, string Mail, string SoDT, string DonViCongTac, string GioiTinh, byte[] anh, ref string err)
        {
            return db.MyExecuteNonQuery2("CapNhatGV2", CommandType.StoredProcedure, ref err,
              new SqlParameter("@MaGV", MaGV),
              new SqlParameter("@HoTenGV", TenGV),
               new SqlParameter("@NgaySinh", NgaySinh),
                new SqlParameter("@DiaChi", DiaChi),
                 new SqlParameter("@Mail", Mail),
                  new SqlParameter("@SoDT", SoDT),
                   new SqlParameter("@DonViCongTac", DonViCongTac),
                    new SqlParameter("@GioiTinh", GioiTinh),
                     new SqlParameter("@Anh", anh))
                     ;
        }
        public DataSet Find(string TenGV)
        {
            return db.ExecuteQueryDataSet("select GIAOVIEN.MaGV,HoTenGV,NgaySinh,DiaChi,Mail,SoDT,DonViCongTac,GioiTinh,Anh,MaLop,Phong " +
                "from GIAOVIEN inner join PHANCONG on GIAOVIEN.MaGV = PHANCONG.MaGV  Where HoTenGV like '" + TenGV + "'", CommandType.Text);
        }

    }
}
