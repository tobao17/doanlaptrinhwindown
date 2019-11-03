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
    class Khoahoc
    {
        DBMain db = null;
        public Khoahoc()
        {
            db = new DBMain();
        }
        public DataSet LayKH()
        {
            return db.ExecuteQueryDataSet("select HOCVIEN.MaHV,HoTenHV,MaKhoa,Khoa,NgayBatDau,NgayKetThuc " +
                "from HOCVIEN right outer join KHOA on HOCVIEN.MaHV = KHOA.MaHV Where nghihoc = 0", CommandType.Text);
        }
        public DataSet LoadKhoaHocTheoLop(string Khoa)
        {
            return db.ExecuteQueryDataSet("select HOCVIEN.MaHV,HoTenHV,MaKhoa,Khoa,NgayBatDau,NgayKetThuc " +
                "from HOCVIEN inner join KHOA on HOCVIEN.MaHV = KHOA.MaHV Where Khoa = '" + Khoa + "'", CommandType.Text);
        }
        public bool CapNhatKH(string makh, string khoa, string ngaybatdau, string ngaykethuc, ref string err)
        {
            return db.MyExecuteNonQuery2("ThemKH", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MaKH", makh),
                new SqlParameter("@Khoa", khoa),
                 new SqlParameter("@NgayBatDau", ngaybatdau),
                  new SqlParameter("@NgayKetThuc", ngaykethuc))
                  ;
        }
    }
}
